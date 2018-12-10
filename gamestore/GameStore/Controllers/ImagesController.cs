using AutoMapper;
using GameStore.Common;
using GameStore.Data;
using GameStore.Exceptions;
using GameStore.Model;
using GameStore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Controllers
{
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCommon _unitOfWork;
        private readonly ILogger<ImagesController> _logger;

        public ImagesController(IUnitOfWorkCommon unitOfWork, ApplicationDbContext context, IMapper mapper, ILogger<ImagesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        [HttpPost("game")]
        [AllowAnonymous]
        public async Task<IServiceResult> PostImageGame([FromBody] ImageGame imageGame)
        {
            try
            {
                _context.ImageGames.Add(imageGame);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(imageGame));
                }
                _logger.LogInformation($"Image {imageGame.Id}  created.");
                return new ServiceResult(payload: imageGame.UrlOnline);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a image  of game  {imageGame.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }



        [HttpPost("user")]
        [AllowAnonymous]
        public async Task<IServiceResult> PostImageUser([FromBody] ImageUser imageUser)
        {
            try
            {
                _context.ImageUsers.Add(imageUser);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(imageUser));
                }
                _logger.LogInformation($"Image {imageUser.Id}  created.");
                return new ServiceResult(payload: imageUser.UrlOnline);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a image  of game  {imageUser.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }


        [HttpPost("publisher")]
        [AllowAnonymous]
        public async Task<IServiceResult> PostImagePublisher([FromBody] ImagePublisher imagePublisher)
        {
            try
            {
                _context.ImagePublishers.Add(imagePublisher);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(imagePublisher));
                }
                _logger.LogInformation($"Image {imagePublisher.Id}  created.");
                return new ServiceResult(payload: imagePublisher.UrlOnline);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a image  of game  {imagePublisher.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }
    }
}
