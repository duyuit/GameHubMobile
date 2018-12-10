using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class ImageCategory:Image
    {
        //public Category Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
