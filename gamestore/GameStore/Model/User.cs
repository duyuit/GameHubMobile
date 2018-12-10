using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class User : IdentityUser<Guid>
    {

        public virtual ICollection<UserGame> Games { get; set; }
        public string Hobbies { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<WishGame> WishGames { get; set; }
        public ImageUser ImageUser { get; set; }
        public float Money { get; set; }
        public User()
        {
            this.Money = 0f;
            this.Games = new Collection<UserGame>();
            this.WishGames = new Collection<WishGame>();
        }
    }
}
