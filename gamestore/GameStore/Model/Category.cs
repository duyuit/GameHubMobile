using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        //public virtual ImageCategory ImageCategory { get; set; }
        //public Guid ImageCategoryId { get; set; }
        public virtual ICollection<CategoryGame> Games { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            Games = new Collection<CategoryGame>();
        }
    }
}
