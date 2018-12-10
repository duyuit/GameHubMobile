using AutoMapper;
using GameStore.Common;
using GameStore.Data;
using GameStore.DTOs;
using GameStore.Exceptions;
using GameStore.Model;
using GameStore.UnitOfWork.Interfaces;
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
    public class FreeCodesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkCommon _unitOfWork;
        private readonly ILogger<FreeCodesController> _logger;
        public FreeCodesController(IUnitOfWorkCommon unitOfWork, ApplicationDbContext context, IMapper mapper, ILogger<FreeCodesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IServiceResult> GetFreeCodes()
        {
            try
            {
                var freeCodes = await _context.FreeCodes.ToListAsync();
                var freeCodesDto = _mapper.Map<IEnumerable<FreeCode>, IEnumerable<FreeCodeDTOs>>(freeCodes);
                return new ServiceResult(payload: freeCodesDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't get all free codes. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        [HttpGet("{gameId}")]
        [AllowAnonymous]
        public async Task<IServiceResult> GetFreeCodeByGameId([FromRoute] Guid gameId)
        {
            try
            {
                var freeCode = await _context.FreeCodes.Where(f => f.GameId == gameId).ToListAsync();
                var freeCodesDto = _mapper.Map<IEnumerable<FreeCode>, IEnumerable<FreeCodeDTOs>>(freeCode);
                return new ServiceResult(payload: freeCodesDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't get free codes of {gameId}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResult> PostFreeCode([FromBody] SavedFreeCodeDTOs savedFreeCodeDTOs)
        {
            try
            {
                var freeCode = _mapper.Map<SavedFreeCodeDTOs, FreeCode>(savedFreeCodeDTOs);
                _context.FreeCodes.Add(freeCode);
                if (!await _unitOfWork.CompleteAsync())
                {
                    throw new SaveFailedException(nameof(freeCode));
                }
                _logger.LogInformation($"Freecode {freeCode.Code} with game id: {freeCode.GameId} created.");
                return new ServiceResult(payload: freeCode.Code);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can't create  a free code {savedFreeCodeDTOs.Id}. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }
    }
}
