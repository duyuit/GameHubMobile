using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class SavedGameDTOs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublisherId { get; set; }
        public virtual ICollection<Guid> Members { get; set; }
        public virtual ICollection<Guid> FavoriteMembers { get; set; }
        public float Rating { get; set; }
        public string Logo { get; set; }
        public string VideoUrl { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Guid> Categories { get; set; }
        public DateTime PurchaseDate { get; set; }
        //public virtual ICollection <Guid> ImageGames { get; set; }
        public float Price { get; set; }
    }
}
