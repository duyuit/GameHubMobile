using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class SavedCategoryDTOs
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
