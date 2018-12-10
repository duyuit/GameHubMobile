using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class ImagePublisher:Image
    {
        public virtual  Publisher Publisher { get; set; }
        public Guid PublisherId { get; set; }

    }
}
