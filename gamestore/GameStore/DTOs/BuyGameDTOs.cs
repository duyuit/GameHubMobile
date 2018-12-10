using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class BuyGameDTOs
    {
        public Guid Id { get; set; }
        public virtual ICollection<Guid> IDGames { get; set; }
        public BuyGameDTOs()
        {
            IDGames = new Collection<Guid>();
        }
    }
}
