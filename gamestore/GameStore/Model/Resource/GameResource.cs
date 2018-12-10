using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model.Resource
{
    public class GameResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublisherId { get; set; }
        public ICollection<User> Members { get; set; }
        public float Rating { get; set; }
        public string Logo { get; set; }
        public string VideoUrl { get; set; }
        public string Content { get; set; }
        public ICollection<Category> Categories { get; set; }
        public DateTime PurchaseDate { get; set; }
        public ICollection<FreeCode> FreeCode { get; set; }
        public GameResource()
        {
            Members = new Collection<User>();
            FreeCode = new Collection<FreeCode>();
            Categories = new Collection<Category>();
            PurchaseDate = DateTime.Now;
        }
    }
}
