using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class SavedFreeCodeDTOs
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid GameId { get; set; }
    }
}
