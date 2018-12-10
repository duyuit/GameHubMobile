using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class WishGame
    {
        public  Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
