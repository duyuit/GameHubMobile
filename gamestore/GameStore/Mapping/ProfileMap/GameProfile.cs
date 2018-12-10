using GameStore.DTOs;
using GameStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Mapping.ProfileMap
{
    public class GameProfile :BaseProfile
    {
        protected override void CreateMap()
        {
            CreateMap<Game, GameDTOs>()
               .ForMember(pr => pr.Members,
                   opt => opt.MapFrom(p =>
                       p.Members.Select(pc => pc.User)))
               .ForMember(pr => pr.FavoriteMembers,
                   opt => opt.MapFrom(p =>
                       p.FavoriteMembers.Select(pc => pc.User)))
               .ForMember(pr => pr.Categories,
                   opt => opt.MapFrom(p =>
                       p.Categories.Select(pc => pc.Category)))
               .ForMember(pr => pr.Publisher, opt => opt.MapFrom(p => p.Publisher))
                   .ForMember(pr => pr.ImageGames,
                     opt => opt.MapFrom(p => p.ImageGames))
                   ;

            CreateMap<GameDTOs, Game>();

            CreateMap<SavedGameDTOs, Game>()
                .ForMember(p => p.Members, opt => opt.Ignore())
               .AfterMap((pr, p) =>
               {
                   var addedMember = pr.Members.Where(id => p.Members.All(pc => pc.UserId != id))
                       .Select(id => new UserGame() { GameId = pr.Id, UserId = id }).ToList();
                   foreach (var pc in addedMember)
                       p.Members.Add(pc);

                   var removedMember =
                       p.Members.Where(c => !pr.Members.Contains(c.UserId)).ToList();
                   foreach (var pc in removedMember)
                       p.Members.Remove(pc);
               })
               .ForMember(p => p.FavoriteMembers, opt => opt.Ignore())
               .AfterMap((pr, p) =>
               {
                   var addedFavoriteMembers = pr.FavoriteMembers.Where(id => p.FavoriteMembers.All(pc => pc.UserId != id))
                       .Select(id => new WishGame() { GameId = pr.Id, UserId = id }).ToList();
                   foreach (var pc in addedFavoriteMembers)
                       p.FavoriteMembers.Add(pc);

                   var removedFavoriteMembers =
                       p.FavoriteMembers.Where(c => !pr.FavoriteMembers.Contains(c.UserId)).ToList();
                   foreach (var pc in removedFavoriteMembers)
                       p.FavoriteMembers.Remove(pc);
               })
               .ForMember(p => p.Categories, opt => opt.Ignore())
               .AfterMap((pr, p) =>
               {
                   var addedCategories = pr.Categories.Where(id => p.Categories.All(pc => pc.CategoryId != id))
                       .Select(id => new CategoryGame() { GameId = pr.Id, CategoryId = id }).ToList();
                   foreach (var pc in addedCategories)
                       p.Categories.Add(pc);

                   var removedCategories =
                       p.Categories.Where(c => !pr.Categories.Contains(c.CategoryId)).ToList();
                   foreach (var pc in removedCategories)
                       p.Categories.Remove(pc);
               });
            CreateMap<Game, SavedGameDTOs>();


        }
    }
}
