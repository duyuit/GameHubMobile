using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class ImageUser :Image
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
