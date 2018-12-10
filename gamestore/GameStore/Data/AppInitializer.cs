using GameStore.Extention;
using GameStore.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class AppInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public AppInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {

            //if (!_context.Games.Any())
            {
                var games = new List<Game>()
                    {
                        new Game(){ Id = Guid.NewGuid(), Content="DASH as fast as you can! DODGE the oncoming trains!Help Jake, Tricky & Fresh escape from the grumpy Inspector and his dog.  Grind trains with your cool crew!  Colorful and vivid HD graphics!  Hoverboard Surfing!  Paint powered jetpack!  Lightning fast swipe acrobatics!  Challenge and help your friends!",
                            Name ="Subway Surfers",
                            Price =0,
                            ReleaseDate =new DateTime(),
                            Rating =4.5f,
                            VideoUrl ="URL Video here",
                            PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id },
                        new Game(){ Id = Guid.NewGuid(),
                            Content ="The zombies are revolting ! Attack the city with a horde of zombies, change pedestrians into zombies and create the largest horde. Eat your friends, and challenge them to a crazy race by destroying everything in your path. Zombie Tsunami has proudly exceeded 200 million players around the world.",
                            Name ="Zombie Tsunami",
                            Price =100000,
                            ReleaseDate =new DateTime(),
                            Rating =4.5f,
                            VideoUrl ="URL Video here",
                            PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="With over a zillion downloads, Temple Run redefined mobile gaming. Now get more of the exhilarating running, jumping, turning and sliding you love in Temple Run 2! Navigate perilous cliffs, zip lines, mines and forests as you try to escape with the cursed idol. How far can you run ? !",
                    Name ="Temple Run 2",
                    Price =50000,
                    ReleaseDate =new DateTime(),
                    Rating =4.3f,VideoUrl="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Get ready to soil your plants as a mob of fun-loving zombies is about to invade your home. Use your arsenal of 49 zombie-zapping plants — peashooters, wall-nuts, cherry bombs and more — to mulchify 26 types of zombies before they break down your door.",
                    Name ="Plants vs. Zombies FREE",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Start playing Candy Crush Saga today – loved by millions of players around the world. With over a trillion levels played, this sweet match 3 puzzle game is one of the most popular mobile games of all time!",
                    Name ="Candy Crush Saga",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Magic Tiles 3 ™ is one of the most loved piano games among thousands of free games in 2018 which has more than 80 million players around the world.",
                    Name ="Magic Tiles 3",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Is it a baby? Is it a puppy? No! It’s Talking Tom! The cutest kitten, the coolest cat, and the biggest superstar in the world! My Talking Tom is the best virtual pet game for children, and big kids of all ages.That’s right - even grandma and grandpa can join the fun!",
                    Name ="My Talking Tom",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Use the unique powers of the Angry Birds to destroy the greedy pigs' defenses! The survival of the Angry Birds is at stake. Dish out revenge on the greedy pigs who stole their eggs. Use the unique powers of each bird to destroy the pigs’ defenses. Angry Birds features challenging physics-based gameplay and hours of replay value. Each level requires logic, skill and force to solve.",
                    Name ="Angry Birds Classic",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="The sequel to the famous Facebook smash hit with 40 million users Shadow Fight 2 is a nail-biting mix of RPG and classical Fighting. This game lets you equip your character with countless lethal weapons and rare armor sets, and features dozens of lifelike-animated Martial Arts techniques! Crush your enemies, humiliate demon bosses, and be the one to close the Gate of Shadows. Do you have what it takes to kick, punch, jump, and slash your way to victory? There’s only one way to find out",
                    Name ="Shadow Fight 2",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="A strange group of enemies appeared in the city and have been using innocent people as experimental tools. Lots of people have turned into Zombie so that Hero and his friends should save the people and remove the enemies.",Name="Anger of stick 5 : zombie",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here",
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="Play the award-winning hit action-strategy adventure where you meet, greet, and defeat legions of hilarious zombies from the dawn of time, to the end of days. Amass an army of amazing plants, supercharge them with Plant Food, and devise the ultimate plan to protect your brain.",
                    Name ="Plants vs Zombies 2 Free",
                    Price =0,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                new Game(){ Id = Guid.NewGuid(),
                    Content ="In Asphalt 8, you’ll race in some of the hottest, most high-performance dream machines ever created, from cars to bikes, as you take them on a global tour of speed. From the blazing Nevada Desert to the tight turns of Tokyo, you’ll find a world of challenge, excitement and arcade fun on your road to the top!",
                    Name ="Asphalt 8: Airborne",
                    Price =100000,
                    ReleaseDate =new DateTime(),
                    Rating =4.5f,
                    VideoUrl ="URL Video here" ,
                    PublisherId = _context.Publishers.FirstOrDefault(p=>p.Name == "Kiloo").Id},
                    };

                games[0].Members = new List<UserGame>() { new UserGame() { GameId = games[0].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[1].Members = new List<UserGame>() { new UserGame() { GameId = games[1].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[2].Members = new List<UserGame>() { new UserGame() { GameId = games[2].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[3].Members = new List<UserGame>() { new UserGame() { GameId = games[3].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[4].Members = new List<UserGame>() { new UserGame() { GameId = games[4].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[5].Members = new List<UserGame>() { new UserGame() { GameId = games[5].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                games[6].Members = new List<UserGame>() { new UserGame() { GameId = games[6].Id, UserId = "6f6ee7d9-e3a8-4f27-d1f7-08d6520f9b99".ToGuid() } };
                await _context.AddRangeAsync(games);
                await _context.SaveChangesAsync();
            }

        }
    }
}
