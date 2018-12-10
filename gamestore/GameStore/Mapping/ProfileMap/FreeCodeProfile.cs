using GameStore.DTOs;
using GameStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Mapping.ProfileMap
{
    public class FreeCodeProfile : BaseProfile
    {
        protected override void CreateMap()
        {
            CreateMap<FreeCode, FreeCodeDTOs>();
            CreateMap<FreeCodeDTOs, FreeCode>();

            CreateMap<SavedFreeCodeDTOs, FreeCode>();
            CreateMap<FreeCode, SavedFreeCodeDTOs>();
        }
    }
}
