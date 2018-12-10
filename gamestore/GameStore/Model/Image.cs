using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class Image
    {
        public Guid Id { get; set; }
        public string UrlOnline { get; set; }
        public string UrlLocal { get; set; }
        public Image()
        {
            Id = Guid.NewGuid();
        }
    }
}
