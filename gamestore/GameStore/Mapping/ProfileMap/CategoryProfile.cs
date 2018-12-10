using GameStore.DTOs;
using GameStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Mapping.ProfileMap
{
    public class CategoryProfile : BaseProfile
    {
        protected override void CreateMap()
        {
            CreateMap<Category, CategoryDTOs>()
             .ForMember(pr => pr.Games, opt => opt.MapFrom(p => p.Games));

            CreateMap<CategoryDTOs, Category>();
            CreateMap<SavedCategoryDTOs, Category>();
            CreateMap<Category, SavedCategoryDTOs>();
        }
    }
}
