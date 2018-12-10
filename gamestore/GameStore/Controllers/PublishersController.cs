using AutoMapper;
using GameStore.Common;
using GameStore.Data;
using GameStore.DTOs;
using GameStore.Exceptions;
using GameStore.Model;
using GameStore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCommon _unitOfWork;
        private readonly ILogger<PublishersController> _logger;
        public PublishersController(IUnitOfWorkCommon unitOfWork, ApplicationDbContext context, IMapper mapper, ILogger<PublishersController> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IServiceResult> GetPublisher()
        {
            try
            {
                var publishers = await _context.Publishers.Include(c => c.Games).Include(p=>p.ImagePublisher).ToListAsync();
                var publishersDto = _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDTOs>>(publishers);
                return new ServiceResult(payload: publishersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't get all publsiher because {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IServiceResult> GetPublisherById([FromRoute] Guid id)
        {
            try
            {
                var publisher = await _context.Publishers.Include(p => p.Games).SingleOrDefaultAsync(g => g.Id == id);
                if (publisher == null)
                {
                    throw new NotFoundException(nameof(publisher), id);
                }
                var publishersDto = _mapper.Map<Publisher, PublisherDTOs>(publisher);
                return new ServiceResult(payload: publishersDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't get publisher by id {id} because {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResult> PostPublisher([FromBody] SavedPublisherDTOs savedPublisherDTOs)
        {
            try
            {
                var publisher = _mapper.Map<SavedPublisherDTOs, Publisher>(savedPublisherDTOs);
                _context.Publishers.Add(publisher);

                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(publisher));
                }
                publisher = await _context.Publishers.Include(p => p.Games).SingleOrDefaultAsync(g => g.Id == publisher.Id);
                var publisherDto = _mapper.Map<Publisher, PublisherDTOs>(publisher);
                _logger.LogInformation($"Publisher {publisherDto.Name}  created.");
                return new ServiceResult(payload: publisherDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't add  {savedPublisherDTOs.Name} because {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IServiceResult> PutPublisher([FromRoute] Guid id, [FromBody] SavedPublisherDTOs savedPublisherDTOs)
        {
            if (id != savedPublisherDTOs.Id)
            {
                throw new NotFoundException(nameof(savedPublisherDTOs), id);
            }
            try
            {
                var publisher = _mapper.Map<SavedPublisherDTOs, Publisher>(savedPublisherDTOs);
                _context.Entry(publisher).State = EntityState.Modified;
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(publisher));
                }
                _context.Entry(publisher).State = EntityState.Modified;
                // return value 
                publisher = await _context.Publishers.Include(p => p.Games).SingleOrDefaultAsync(g => g.Id == publisher.Id);
                var publisherDto = _mapper.Map<Publisher, PublisherDTOs>(publisher);
                _logger.LogInformation($"Publisher {publisherDto.Name}  modified.");
                return new ServiceResult(payload: publisherDto);
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!PublisherExists(id))
                {
                    throw new NotFoundException(nameof(savedPublisherDTOs), id);
                }
                _logger.LogError($"Can't post pubisher {id} because {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IServiceResult> DeletePublisher([FromRoute] Guid id)
        {
            try
            {
                var publisher = await _context.Publishers.SingleOrDefaultAsync(m => m.Id == id);
                if (publisher == null)
                {
                    throw new NotFoundException(nameof(publisher), id);
                }
                _context.Publishers.Remove(publisher);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(publisher));
                }
                _logger.LogInformation($"Publisher {publisher.Name}  has deleted.");
                return new ServiceResult(true, message: $"{publisher.Name} has deleted");
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't delete {id}  because {e.Message}");
                return new ServiceResult(false, message: $"Can't delete {id}  because {e.Message}");
            }
        }

        private bool PublisherExists(Guid id)
        {
            return _context.Publishers.Any(e => e.Id == id);
        }
    }
}
