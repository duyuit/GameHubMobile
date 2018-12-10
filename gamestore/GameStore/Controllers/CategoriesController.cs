using AutoMapper;
using GameStore.Common;
using GameStore.Data;
using GameStore.DTOs;
using GameStore.Model;
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
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ApplicationDbContext context, IMapper mapper, ILogger<CategoriesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IServiceResult> GetCategories()
        {
            try
            {
                var categories = await _context.Categories.Include(c => c.Games).ThenInclude(g => g.Game).ToListAsync();
                var categoriesDto = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTOs>>(categories);

                return new ServiceResult(payload: categoriesDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Can get all categories. {e.Message}");
                return new ServiceResult(false, message: e.Message);
            }
        }


        
    }
}
