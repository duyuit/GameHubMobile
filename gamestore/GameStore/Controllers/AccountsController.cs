using AutoMapper;
using GameStore.Common;
using GameStore.Data;
using GameStore.DTOs;
using GameStore.Exceptions;
using GameStore.Extention;
using GameStore.Model;
using GameStore.Model.Resource;
using GameStore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IUnitOfWorkCommon _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        public AccountsController(IUnitOfWorkCommon unitOfWork,
                                  UserManager<User> userManager,
                                  SignInManager<User> signInManager,
                                  ApplicationDbContext context,
                                  IMapper mapper,
                                  ILogger<AccountsController> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResult> Register([FromBody] UserSaved register)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(register.Email);
                if (user != null) return new ServiceResult(false, message: "Duplicate user");
                user = _mapper.Map<UserSaved, User>(register);
                var result = await _userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(user.UserName);
                    var role = await _userManager.AddToRoleAsync(currentUser, "User");
                    _logger.LogInformation($"User {user.Email} with id: {user.Id} created.");
                    return new ServiceResult(payload: currentUser.UserName);
                }
                return new ServiceResult(false, message: " Duplicate UserName ");
            }
            catch (Exception e)
            {
                _logger.LogError($"Can not create user {register.Email}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IServiceResult> GetUsersAsync()
        {
            try
            {
                var users = await _context.Users
                    .Include(u => u.WishGames)
                    .ThenInclude(g => g.Game)
                    .ThenInclude(g => g.ImageGames)
                    .Include(u => u.Games)
                     .ThenInclude(g => g.Game)
                    .Include(u => u.ImageUser).ToListAsync();

                var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTOs>>(users);
                return new ServiceResult(payload: usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can not get all users. {e.Message}");
                return new ServiceResult(false, e.Message);
            }
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.WishGames)
                    .ThenInclude(g => g.Game)
                     .ThenInclude(g => g.ImageGames)
                    .Include(u => u.Games)
                    .ThenInclude(g => g.Game)
                     .ThenInclude(g => g.ImageGames)
                     .Include(u => u.ImageUser)
                    .SingleOrDefaultAsync(u => u.Id == id);
                var usersDto = _mapper.Map<User, UserDTOs>(user);
                return new ServiceResult(payload: usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can not get all users. {e.Message}");
                return new ServiceResult(false, e.Message);
            }
        }

        // wrong model but  api is true when input haven't  inforation of user 
        [HttpPut("edit-game/{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> EditGameAsync([FromRoute] string id, [FromBody] RegisterDTOs registerDTOs)
        {
            try
            {
                var userId = id.ToGuid();
                var user = await _context.Users.Where(u => u.Id == userId).Include(u => u.WishGames).Include(u => u.Games).SingleAsync();

                _mapper.Map<RegisterDTOs, User>(registerDTOs, user);

                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(user));
                }

                user = await _userManager.FindByIdAsync(id);
                var usersDto = _mapper.Map<User, UserDTOs>(user);
                return new ServiceResult(payload: usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can not edit user {registerDTOs.Email} because  {e.Message}");
                return new ServiceResult(false, e.Message);
            }
        }
        // wrong model but  api is true when input haven't  inforation of game 
        [HttpPut("edit-user/{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> EditUserAsync([FromRoute] string id, [FromBody] RegisterDTOs registerDTOs)
        {
            try
            {
                // check duplicate  user 
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return new ServiceResult(false, " User not exited on system");
                if (user.Email != registerDTOs.Email)
                {
                    if ((await _userManager.FindByEmailAsync(registerDTOs.Email) != null))
                    {
                        return new ServiceResult(false, " Email exited on db");
                    }
                }

                if (user.UserName != registerDTOs.UserName)
                {
                    if ((await _userManager.FindByNameAsync(registerDTOs.UserName) != null))
                    {
                        return new ServiceResult(false, "Username exited on db");
                    }
                }

                user.UserName = registerDTOs.UserName;
                user.PhoneNumber = registerDTOs.PhoneNumber;
                user.Email = registerDTOs.Email;
                user.SecurityStamp = (Guid.NewGuid()).ToString();
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerDTOs.Password);
                user.FullName = registerDTOs.FullName;
                user.Hobbies = registerDTOs.Hobbies;
                await _userManager.UpdateAsync(user);
                await _unitOfWork.CompleteAsync();
                user = await _userManager.FindByIdAsync(id);
                var usersDto = _mapper.Map<User, UserDTOs>(user);
                return new ServiceResult(payload: usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can not edit user {registerDTOs.Email} because  {e.Message}");
                return new ServiceResult(false, e.Message);
            }
        }


        [HttpPut("recharge/{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> RechargeAsync([FromRoute] string id, [FromBody] MoneyDto MoneyDto)
        {
            try
            {
                var userId = id.ToGuid();
                var user = await _context.Users.Where(u => u.Id == userId).SingleAsync();

                user.Money = MoneyDto.Money;

                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(user));
                }

                user = await _userManager.FindByIdAsync(id);
                var usersDto = _mapper.Map<User, UserDTOs>(user);
                return new ServiceResult(payload: usersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"User {id} can't recharge  {e.Message}");
                return new ServiceResult(false, e.Message);
            }
        }

        [HttpPost("buy/{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> BuyGameAsync([FromRoute] string id, [FromBody] LikeGameDTOs LikeGameDTOs)
        {
            try
            {
                // add game  and user  into user game table 
                var userId = id.ToGuid();
                var game = await _context.Games.SingleOrDefaultAsync(g=>g.Id==LikeGameDTOs.Id);
                UserGame userGame = new UserGame() { GameId = LikeGameDTOs.Id, PurchaseDate = DateTime.Now, UserId = userId };
                _context.UserGames.Add(userGame);
                // update money for publisher
                Publisher publisher = await _context.Publishers.SingleOrDefaultAsync(p => p.Id == game.PublisherId);
                publisher.Money += game.Price;
                // update money for user 
                User user = await _context.Users.SingleOrDefaultAsync(p => p.Id == userId);
                user.Money -= game.Price;

               if(user.Money<0) return new ServiceResult(false, message: "Your account don't enought money to buy this game");
                // save change 
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(userGame));
                }
                _logger.LogInformation($"User  {userGame.UserId} bought game id: {userGame.GameId} .");
                return new ServiceResult(payload: userGame.GameId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a free code {LikeGameDTOs.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }




        [HttpPost("like/{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> LikeGameAsync([FromRoute] string id, [FromBody] LikeGameDTOs LikeGameDTOs)
        {
            try
            {
                var userId = id.ToGuid();
                WishGame wishGame = new WishGame() { GameId = LikeGameDTOs.Id, UserId = userId };
                _context.WishGame.Add(wishGame);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(wishGame));
                }
                _logger.LogInformation($"User  {wishGame.UserId} like game id: {wishGame.GameId} .");
                return new ServiceResult(payload: wishGame.GameId);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a free code {LikeGameDTOs.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

    }


}
