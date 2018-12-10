using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class TitlePublisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public int Reliability { get; set; }
    }
}
