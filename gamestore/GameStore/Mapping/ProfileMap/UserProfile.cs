using GameStore.DTOs;
using GameStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Mapping.ProfileMap
{
    public class UserProfile : BaseProfile
    {
        protected override void CreateMap()
        {
            CreateMap<User, UserDTOs>()
                .ForMember(pr => pr.Games,
                    opt => opt.MapFrom(p =>
                        p.Games.Select(pc => pc.Game)))
                .ForMember(pr => pr.WishGames,
                    opt => opt.MapFrom(p =>
                        p.WishGames.Select(pc => pc.Game)))

                .ForAllMembers(opt => opt.Condition(
                    (src, des, srcMbr, desMbr) => (srcMbr != null)));

            CreateMap<UserDTOs, User>()
                .ForMember(g => g.Email, opt => opt.Ignore())
                .ForMember(g => g.PhoneNumber, opt => opt.Ignore());

            CreateMap<RegisterDTOs, User>()
               .ForMember(p => p.WishGames, opt => opt.Ignore())
               .AfterMap((pr, p) =>
               {
                 
                   var addedGame = pr.IDWishGames.Where(id => p.WishGames.All(pc => pc.GameId != id))
                       .Select(id => new WishGame() { GameId = id, UserId = pr.Id }).ToList();
                   foreach (var pc in addedGame)
                       p.WishGames.Add(pc);

                   var removedGames =
                       p.WishGames.Where(c => !pr.IDWishGames.Contains(c.GameId)).ToList();
                   foreach (var pc in removedGames)
                       p.WishGames.Remove(pc);
               
               })
               .ForMember(pr => pr.Games, opt => opt.Ignore())
                .AfterMap((pr, p) =>
                {
                        var addedGame = pr.IDGames.Where(id => p.Games.All(pc => pc.GameId != id))
                            .Select(id => new UserGame() { GameId = id, UserId = pr.Id }).ToList();
                        foreach (var pc in addedGame)
                            p.Games.Add(pc);

                        var removedCategories =
                            p.Games.Where(c => !pr.IDGames.Contains(c.GameId)).ToList();
                        foreach (var pc in removedCategories)
                            p.Games.Remove(pc);
                 
                });
            //CreateMap<BuyGameDTOs, User>()
            //  .ForMember(p => p.Games, opt => opt.Ignore())
            //  .AfterMap((pr, p) =>
            //  {
            //      var addedGame = pr.IDGames.Where(id => p.Games.All(pc => pc.GameId != id))
            //          .Select(id => new UserGame() { GameId = id, UserId = pr.Id }).ToList();
            //      foreach (var pc in addedGame)
            //          p.Games.Add(pc);

            //      var removedGames =
            //          p.Games.Where(c => !pr.IDGames.Contains(c.GameId)).ToList();
            //      foreach (var pc in removedGames)
            //          p.Games.Remove(pc);
            //  });

            //CreateMap<LikeGameDTOs, User>()
            //   .ForMember(p => p.WishGames, opt => opt.Ignore())
            //   .AfterMap((pr, p) =>
            //   {
            //       var addedGame = pr.IDWishGames.Where(id => p.WishGames.All(pc => pc.GameId != id))
            //           .Select(id => new WishGame() { GameId = id, UserId = pr.Id }).ToList();
            //       foreach (var pc in addedGame)
            //           p.WishGames.Add(pc);

            //       var removedGames =
            //           p.WishGames.Where(c => !pr.IDWishGames.Contains(c.GameId)).ToList();
            //       foreach (var pc in removedGames)
            //           p.WishGames.Remove(pc);`
            //   });
            CreateMap<UserSaved, User>()
                 //.ForMember(g => g.UserName, opt => opt.MapFrom(u => u.Email))
                .ForMember(p => p.WishGames, opt => opt.Ignore())
                 .ForMember(p => p.Games, opt => opt.Ignore());
            CreateMap<User, UserSaved>();
            //revert mapper
            CreateMap<User, RegisterDTOs>();
        }
    }
}
