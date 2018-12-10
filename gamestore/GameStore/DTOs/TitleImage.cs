using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class TitleImage
    {
        public Guid Id { get; set; }
        public string UrlOnline { get; set; }
        public string UrlLocal { get; set; }
    }
}
