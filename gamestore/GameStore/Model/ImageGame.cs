using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class ImageGame:Image
    {
        public virtual Game Game { get; set; }
        public Guid GameId { get; set; }
    }
}
