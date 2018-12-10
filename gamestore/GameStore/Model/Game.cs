using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<UserGame> Members { get; set; }
        public virtual ICollection<WishGame> FavoriteMembers { get; set; }
        public float Rating { get; set; }
        public ICollection<ImageGame> ImageGames { get; set; }
       
        public string VideoUrl { get; set; }
        public string Content { get; set; }
        public virtual ICollection<CategoryGame> Categories { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public virtual ICollection<FreeCode> FreeCodes { get; set; }
        //Server=(localdb)\\mssqllocaldb;Database=GameDB;Trusted_Connection=True  Server=tcp:gamestorecrosplatformdbserver.database.windows.net,1433;Initial Catalog = GameDb; Persist Security Info=False;User ID = vkhoi; Password=Thatvuhai_7595;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;
        //Server=tcp:gamestorecrosplatformdbserver.database.windows.net,1433;Initial Catalog = GameDb; Persist Security Info=False;User ID = vkhoi; Password=Thatvuhai_7595;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;
        public Game()
        {
            Id = Guid.NewGuid();
            Members = new Collection<UserGame>();
            FavoriteMembers = new Collection<WishGame>();
            FreeCodes = new Collection<FreeCode>();
            ImageGames = new Collection<ImageGame>();
            Categories = new Collection<CategoryGame>();
            ReleaseDate= DateTime.Now;
        }
    }
}
