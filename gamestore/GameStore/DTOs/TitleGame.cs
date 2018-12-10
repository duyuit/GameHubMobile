using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class TitleGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TitleImage> ImageGames { get; set; }
        public DateTime ReleaseDate { get; set; }
      
    }
}
