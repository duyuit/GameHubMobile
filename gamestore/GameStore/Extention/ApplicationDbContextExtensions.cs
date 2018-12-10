using GameStore.EntityConfigurations;
using GameStore.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Extention
{
    public static class ApplicationDbContextExtensions
    {
        public static void ApplyEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new GameConfigurations());
            modelBuilder.ApplyConfiguration(new PublisherConfigurations());
            modelBuilder.ApplyConfiguration(new UserGameConfigurations());
            modelBuilder.ApplyConfiguration(new WishGameConfigurations());
            modelBuilder.ApplyConfiguration(new CodeFreeConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryGameConfigurations());
            modelBuilder.ApplyConfiguration(new ImageConfigurations());
        }

        public static void ChangeIdentityTableNames(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => e.ToTable("User"));
            modelBuilder.Entity<ApplicationRole>(e => e.ToTable("Role"));
            modelBuilder.Entity<IdentityUserRole<Guid>>(e => e.ToTable("UserRole"));
            modelBuilder.Entity<IdentityUserClaim<Guid>>(e => e.ToTable("UserClaim"));
            modelBuilder.Entity<IdentityUserLogin<Guid>>(e => e.ToTable("UserLogin"));
        }
        public static void SeedData(this ModelBuilder modelBuilder)
        {
       
      

            var Categories = new[]
            {
                new Category(){ Id = Guid.NewGuid(), Title="FPS"},
                new Category(){ Id = Guid.NewGuid(), Title="Action"},
                new Category(){ Id = Guid.NewGuid(), Title="Adventure"},
                new Category(){ Id = Guid.NewGuid(), Title="Puzzle"},
                new Category(){ Id = Guid.NewGuid(), Title="Open world"},
            };
            modelBuilder.Entity<Category>().HasData(Categories);
            var Users = new[]
          {
                new User(){ Id = Guid.NewGuid(), Hobbies="Hobbies",FullName="Nguyen Ngoc Duy",Email="duykkxm92@gmail.com",PasswordHash="duykkxm92",PhoneNumber="01638789455",UserName="duykkxm92" },
                new User(){ Id = Guid.NewGuid(), Hobbies="Hobbies",FullName="Full Name",Email="Email1@gmail.com",PasswordHash="Thatvuhai_7595",PhoneNumber="93098509228098523",UserName="UserName1" },
                new User(){ Id = Guid.NewGuid(), Hobbies="Hobbies",FullName="Full Name",Email="Email2@gmail.com",PasswordHash="Thatvuhai_7595",PhoneNumber="93098559238098523",UserName="UserName2" } ,
                new User(){ Id = Guid.NewGuid(), Hobbies="Hobbies",FullName="Full Name",Email="Email3@gmail.com",PasswordHash="Thatvuhai_7595",PhoneNumber="93098609238098523",UserName="UserName3" } ,
                new User(){ Id = Guid.NewGuid(), Hobbies="Hobbies",FullName="Full Name",Email="Email4@gmail.com",PasswordHash="Thatvuhai_7595",PhoneNumber="93098509738098523",UserName="UserName4" } ,
            };
            modelBuilder.Entity<User>().HasData(Users);
            var id = Guid.NewGuid();
         
         

            var publishers = new[]
            {
                new Publisher(){ Id=Guid.NewGuid(),Name="Kiloo"},
                new Publisher(){ Id=Guid.NewGuid(),Name="Mobigame S.A.R.L."},
                new Publisher(){ Id=Guid.NewGuid(),Name="Imangi Studios"},
                new Publisher(){ Id=Guid.NewGuid(),Name="ELECTRONIC ARTS"},
                new Publisher(){ Id=Guid.NewGuid(),Name="King"},
                new Publisher(){ Id=Guid.NewGuid(),Name="AMANOTES"},
                new Publisher(){ Id=Guid.NewGuid(),Name="Outfit7 Limited"},
                new Publisher(){ Id=Guid.NewGuid(),Name="Rovio Entertainment Corporation"},
                new Publisher(){ Id=Guid.NewGuid(),Name="NEKKI"},
                new Publisher(){ Id=Guid.NewGuid(),Name="J-PARK"},
                new Publisher(){ Id=Guid.NewGuid(),Name="Gameloft"},
                new Publisher(){ Id=Guid.NewGuid(),Name="ZeptoLab"},
            };
            modelBuilder.Entity<Publisher>().HasData(publishers);

            var imagePublisher = new[]
            {
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[0].Id,UrlOnline="https://www.kiloo.com/wp-content/uploads/2017/03/sharelogo-2.png"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[1].Id,UrlOnline="http://4.bp.blogspot.com/-jAUhK8EAuiA/VmnLpfRWLHI/AAAAAAAAAkI/Hp8mTQXl8xM/s1600/Zombie%2BTsunami%2B-%2BLogo%2BMobigame.jpg" },
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[2].Id,UrlOnline="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3aHsnIsbz6CxKRg5tmpq73iNWV6J65niLvsEs9tKf9feje5iv"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[3].Id,UrlOnline="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbShsNR-wcUaPKBv2NxLSeE6arTMAMGZNs5L219VYdIxUapVJc"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[4].Id,UrlOnline="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSE0L-3DI9ruta232UcPOIlvnE3I3xV-8l1u_C3Grzx6tmXrDzs"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[5].Id,UrlOnline="https://employer.jobsgo.vn/image.php?src=1187_logo_1187_20170209115933_1779.jpg&w=300&h=300"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[6].Id,UrlOnline="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ea/O7_logo-red_cmyk.jpg/1200px-O7_logo-red_cmyk.jpg"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[7].Id,UrlOnline="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdbIPf6EeERMGnyQoYkE4xUMuaU22OEtWLEfHWjAw6vxzGJ5oq"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[8].Id,UrlOnline="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkyOmWOFhXD1lRsMIHkAJrLIvjwmImH1GBwlmqb3I5ysGUNY0-"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[9].Id,UrlOnline="https://upload.wikimedia.org/wikipedia/vi/thumb/2/2a/ZeptoLab.png/200px-ZeptoLab.png"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[10].Id,UrlOnline="https://pbs.twimg.com/profile_images/1026435341312512001/u3D328AP_400x400.jpg"},
                new ImagePublisher(){Id=Guid.NewGuid(), PublisherId=publishers[11].Id,UrlOnline="https://upload.wikimedia.org/wikipedia/vi/thumb/2/2a/ZeptoLab.png/200px-ZeptoLab.png"}
            };

            modelBuilder.Entity<ImagePublisher>().HasData(imagePublisher);
            var Games = new[]
          {
                new Game(){ Id = Guid.NewGuid(), Content="DASH as fast as you can! DODGE the oncoming trains!Help Jake, Tricky & Fresh escape from the grumpy Inspector and his dog.  Grind trains with your cool crew!  Colorful and vivid HD graphics!  Hoverboard Surfing!  Paint powered jetpack!  Lightning fast swipe acrobatics!  Challenge and help your friends!",Name="Subway Surfers",Price=0,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here",PublisherId=publishers[0].Id },
                new Game(){ Id = Guid.NewGuid(), Content="The zombies are revolting ! Attack the city with a horde of zombies, change pedestrians into zombies and create the largest horde. Eat your friends, and challenge them to a crazy race by destroying everything in your path. Zombie Tsunami has proudly exceeded 200 million players around the world.",Name="Zombie Tsunami",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here",PublisherId=publishers[1].Id},
                new Game(){ Id = Guid.NewGuid(), Content="With over a zillion downloads, Temple Run redefined mobile gaming. Now get more of the exhilarating running, jumping, turning and sliding you love in Temple Run 2! Navigate perilous cliffs, zip lines, mines and forests as you try to escape with the cursed idol. How far can you run ? !",Name="Temple Run 2",Price=50000,ReleaseDate=new DateTime(),Rating=4.3f,VideoUrl="URL Video here" ,PublisherId=publishers[2].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Get ready to soil your plants as a mob of fun-loving zombies is about to invade your home. Use your arsenal of 49 zombie-zapping plants — peashooters, wall-nuts, cherry bombs and more — to mulchify 26 types of zombies before they break down your door.",Name="Plants vs. Zombies FREE",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[3].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Start playing Candy Crush Saga today – loved by millions of players around the world. With over a trillion levels played, this sweet match 3 puzzle game is one of the most popular mobile games of all time!",Name="Candy Crush Saga",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[4].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Magic Tiles 3 ™ is one of the most loved piano games among thousands of free games in 2018 which has more than 80 million players around the world.",Name="Magic Tiles 3",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[5].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Is it a baby? Is it a puppy? No! It’s Talking Tom! The cutest kitten, the coolest cat, and the biggest superstar in the world! My Talking Tom is the best virtual pet game for children, and big kids of all ages.That’s right - even grandma and grandpa can join the fun!",Name="My Talking Tom",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[6].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Use the unique powers of the Angry Birds to destroy the greedy pigs' defenses! The survival of the Angry Birds is at stake. Dish out revenge on the greedy pigs who stole their eggs. Use the unique powers of each bird to destroy the pigs’ defenses. Angry Birds features challenging physics-based gameplay and hours of replay value. Each level requires logic, skill and force to solve.",Name="Angry Birds Classic",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[7].Id},
                new Game(){ Id = Guid.NewGuid(), Content="The sequel to the famous Facebook smash hit with 40 million users Shadow Fight 2 is a nail-biting mix of RPG and classical Fighting. This game lets you equip your character with countless lethal weapons and rare armor sets, and features dozens of lifelike-animated Martial Arts techniques! Crush your enemies, humiliate demon bosses, and be the one to close the Gate of Shadows. Do you have what it takes to kick, punch, jump, and slash your way to victory? There’s only one way to find out",Name="Shadow Fight 2",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[8].Id},
                new Game(){ Id = Guid.NewGuid(), Content="A strange group of enemies appeared in the city and have been using innocent people as experimental tools. Lots of people have turned into Zombie so that Hero and his friends should save the people and remove the enemies.",Name="Anger of stick 5 : zombie",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[4].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Play the award-winning hit action-strategy adventure where you meet, greet, and defeat legions of hilarious zombies from the dawn of time, to the end of days. Amass an army of amazing plants, supercharge them with Plant Food, and devise the ultimate plan to protect your brain.",Name="Plants vs Zombies 2 Free",Price=0,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[5].Id},
                new Game(){ Id = Guid.NewGuid(), Content="In Asphalt 8, you’ll race in some of the hottest, most high-performance dream machines ever created, from cars to bikes, as you take them on a global tour of speed. From the blazing Nevada Desert to the tight turns of Tokyo, you’ll find a world of challenge, excitement and arcade fun on your road to the top!",Name="Asphalt 8: Airborne",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[1].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Help Swampy by guiding water to his broken shower. Each level is a challenging physics-based puzzle with amazing life-like mechanics. Cut through dirt and guide fresh water, dirty water, toxic water, steam, and ooze through increasingly challenging scenarios! Every drop count",Name="Where's My Water? Free",Price=0,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[0].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Follow the adventure of Om Nom in the first part of the legendary Cut the Rope logic puzzles series. Get it now for free and start playing with millions of players around the world!",Name="Cut the Rope FULL FREE",Price=0,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[4].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Strap on your running shoes and join the award-winning, fan-favorite runner, Minion Rush. Enter Gru's Lair, discover its many mysterious rooms, and take on manic missions around the world. Along the way, your Minions will jump, roll and dodge obstacles while unlocking a collection of cool Minion costumes.",Name="Minion Rush: Despicable Me Official Game",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[7].Id},
                new Game(){ Id = Guid.NewGuid(), Content="The time to take action and strike back is now! We’re calling for the best sniper in the world to take aim at evil, wherever it hides.There’s no room for remorse, so shoot to kill…",Name="Sniper Fury: Top shooting game - FPS",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[4].Id},
                new Game(){ Id = Guid.NewGuid(), Content="5 lớp nhân vật tùy biến có thể lên cấp cả trong chơi đơn lẫn chơi mạng. Kiếm và dùng Điểm Kĩ năng để kích hoạt kĩ năng riêng của từng lớp nhân vật. Đấu Đội trong các trận Chơi mạng. Bảng xếp hạng Cá nhân và Đội. Nói chuyện với người chơi khác trong mục Chat Toàn cầu và Đội. Nhiệm vụ tiết tấu nhanh với nhiều thử thách khác nhau từ Tokyo đến Venice.",Name="Modern Combat 5: eSports FPS",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[3].Id},
                new Game(){ Id = Guid.NewGuid(), Content="Dragon Mania Legends is for anyone that wants their very own pet dragon, which is obviously everyone… – Gamezebo",Name="Dragon Mania Legends",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[5].Id},
                new Game(){ Id = Guid.NewGuid(), Content="N.O.V.A. Legacy brings you the best 3D sci-fi FPS experience based on the epic first episode of N.O.V.A., which received critical acclaim -- all in a compact version of the shooter. Kal Wardin, our hero, is a veteran N.O.V.A. marine, summoned once again to don his Mobile Armored Suit and strike against the enemies of the Colonial Administration forces. Helped by Yelena, his personal AI Agent, Kal must protect humanity's destiny by engaging in combat against alien invaders while uncovering the mystery behind their sudden assault.",Name="N.O.V.A. Legacy",Price=100000,ReleaseDate=new DateTime(),Rating=4.5f,VideoUrl="URL Video here" ,PublisherId=publishers[1].Id},

            };

            var ImageGames = new[]
            {
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/vInYRcyjzVjBFfY4HIGLLf-tSLK9S55HjUbmQuxmrbpVpItV3AfyuxVMFGASoDdMHc4=w720-h310",GameId=Games[0].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Ia1psbcXgeCV9FBZk1b08QnxC-uSHCgJ112VeJZB19_F2Q-m_w3Z7P_OjFStnYM3LaCC=w720-h310",GameId=Games[0].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/oMcH_a4lXShvowzyaiQpE0_MhYWZvdN9RkaYLtkdnw_rlDR_uHbHj9Eu2zbrvyOAXHQ=w720-h310",GameId=Games[0].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/h4JQOfS4vmim_WhTHeC3RGxtY8eoFG0fgtgsWWk6VvVSrjnjtlgSFzR6sW0hzbncWA=w720-h310",GameId=Games[0].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/mfGdhejubeU1m1Pkj2vpWMLTlLMhnQz0f2Z8M79g6g0thY9cDyHggntmd_A7ckZPGVM=w720-h310",GameId=Games[1].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/MwNuIIzmxxJgM8JeNi2aBhpE-kNnXBGOVPRb_gZoRE-gel5q9ZP7mrQfTT_9xzV8dz4=w720-h310",GameId=Games[1].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/-BUT6NCVxZsPPjsUW8zdrVk4XLMRuE_oWSTwaXrAPYZbBsMKBfqXxOVI7OowXxoLwa8=w720-h310",GameId=Games[1].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/UY9fte3alDnv-cZ94Jx27Lf4g9FUT2395jhXPScEllshpdCO4zfnuWrTNtO1FVRt3w=w720-h310",GameId=Games[1].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/WRg7Mzp5FM-cSiKGb7TbzgeYBY8oMSV4Vgn35XYHDbejbNkWM7lNgqFeQjMlNAZoUX7Z=w720-h310",GameId=Games[2].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/AZ2OkTlsJuqUvCP8IQKwkCg7Fv56FRAb_CV8bXRsR15Ayre8fmWJrkr4RCIvx1wYoktm=w720-h310",GameId=Games[2].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/Vbi7XVMzoCMoAyHFhJlziKjldN5F-Mkp4EOf5YyiMOPsd-of4ckac2BzPAiKGIveSI4=w720-h310",GameId=Games[2].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/GqnDETqoUP17xJg0cQ3pyEHsgO-KLjx-MbJ0Mcwg4Lvd2PnEO-JARZhYtfd8AYwjEew=w720-h310",GameId=Games[2].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/tk_p7dIHQBEBeYiVkFaPcU_5bd3fOhE8HerKp4Ei0cTyxVoVDdd_QD0SLPJeJrSm4c4=w720-h310",GameId=Games[3].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Km7Il6ij6xZBtWJPSpEacmz8dC2C9WACUuf37VdjIYaXWaPaC6WWWmx3T8aaNgNkJaBx=w720-h310",GameId=Games[3].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Zsth8maheotaUA0he3vGtWmm11dWsEsLlffOsvzGX65Sp4nXNAuKSx-Z96f8as3twQ4=w720-h310",GameId=Games[3].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/aosNkyZihAba_VF_HRKOUMGFuK5SxNcZMMvYIAXufiG8znXvrxJ_7jMgmP2E01CapoQ=w720-h310",GameId=Games[3].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/gFZCgWFd8-oR8zu2ApqRWk6dgwIkDM8jex4MxbA-MdiYgfpHJlkAcPBCZX5czXgddA=w720-h310",GameId=Games[4].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/xaL3b80wmBVOrpH-q_DX8F5kKsASHH8Fllf3u65TsS0zs9_y0J4DWKJj5T9QVAWuT3Rn=w720-h310",GameId=Games[4].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/ucBNG7Vj8Lqo8b14PUMyzB8h7f2YcZ9oKB6BuFaJTgCj4jEv3Zo1jFPg-FjdONrw8c7b=w720-h310",GameId=Games[4].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/EFv_aMUrdXQLXLesEfQAuFv9bNvQ5hwzYnuKZ1cr_OBDZU6cY6OZhIiDzfhx4eSuvtI=w720-h310",GameId=Games[4].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/uJK2kFV81mdNGWE9nDO__wadnVhC8afhQourrne9WhOy0ip1UjlsElsw9xd0BV3NCG8=w720-h310",GameId=Games[5].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Z_KPg-BqbZVMMLlH689YEwzPefUXW0l_7MfPS8-KUzDV4-y-VeSfnswbSXakPJfoJw8=w720-h310",GameId=Games[5].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/CjrXpLQr5ixH5K9RjdL4CFLhmfgkVCJVAw0bhOuFuFI0v4IaQyt1zbXLVxKfGz2l246x=w720-h310",GameId=Games[5].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/HteHDUkzuMjCEHM1B-3jvLqlbBYtJZFWiHm-vf47YcE7QiInhXn2O-LkYPxvzPnPGA=w720-h310",GameId=Games[5].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/L615QU2G2qxv68di7WqB4V40mDsOgko4iKmz-NB6SzwLejM8x4i2CbAqgkIxBqZ3A9M=w720-h310",GameId=Games[6].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/d6CY2BSvBXFLK8J3WqJEdDr53_OZ43Aijr43CjG1QKUfHXt4E_zDNBZWoMqkxONzOQ=w720-h310",GameId=Games[6].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/jCNaOtE_9-Zcs9r5MFtGzaxO8xNz3UYEcB3XdPe1oLO3X6PH-hYEspWnR26lUZef_5A=w720-h310",GameId=Games[6].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/sCw3rT7aK1z589o_MBBn1JzVd7fYC1-fWkYV2Tz4eDfCDTi49dS9tOFBLqBrd_XwQCc=w720-h310",GameId=Games[6].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/UbTWxlQujVdxOaYqy_FmC4LRBlm_wSUgQe0wIM0BSXeGUZ0Vzle9OTWNNs4wk8nOKI4=w720-h310",GameId=Games[7].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/d0jf4r7KjWBCzi2GELWFSf6MaJIHepkJIN8JYT8g0tSIThiH_W6FhUnHjBN_fYdl3Q=w720-h310",GameId=Games[7].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/JIvkWPFnKbYeVV5h3AxjMgR9ogQ2a0vMQgCp5B3JP4dEXU4zIR40H8ROTg8WkPrjcEA=w720-h310",GameId=Games[7].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/ClxJrJjyrjj5uaAxZvSaQcjjRfeCta4_otNRCsGJacfFptfTtamCUJpQ0hcQWOd8u-Q=w720-h310",GameId=Games[7].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/o0i5z7sG2EArHccVaOCYU516s3PzflywGTbzf3ylRoZwOizKm-jH2AKwXweh2_77Tw=w720-h310",GameId=Games[8].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/zRs9fTN-tL-p4yNL3ccFr1w3wUH-hqN0ShgwAnbzcnH2FidymdlixdDN-lpqF3xck4I=w720-h310",GameId=Games[8].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/AinG9y8hyEb_p2B6Rg8-iOVjYR7EcsGDmv_rThdnfzgkBjbukLIT4mWFOg5ObAO4RMq0=w720-h310",GameId=Games[8].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/WJIWdX6YPms3-diI1TPcCPtgv_YGH2QNMGqOXLK-ta5FLulrZps4KObsB1-frjU6syA=w720-h310",GameId=Games[8].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/NdRmiugakoZ-CgyoqeEd7SC9xT_xFIfjY3LtjMifJ9_iKsUdzA5WgBrs2cgoAK3d_CNr=w720-h310",GameId=Games[9].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/A4POGA0IPwbcaSj5dba5zrn6tUlCiyvu4ppse912kWUzr084-qqgvCT0m-E99RPi228=w720-h310",GameId=Games[9].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/PeX7REevxeIec-hxFckCJP0xyg88TEzwPh4zz2Prv08d-0UsspP6wcoaBXYJqWzkuQ=w720-h310",GameId=Games[9].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/YL2_i-PixRM-qYfrZ6CpAqyNiXW_MrIx2KFyg2zZLkdjjosIK5qyPg1dfbyTAC-BdNg=w720-h310",GameId=Games[9].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[10].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[10].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[10].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[10].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[11].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[11].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[11].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3w11K9XJxAy89BNu2LAbU9n8DD2fo-zF5ovi7mdQoAgcRye6-MLCWlEzebyxvSLqHnD_=w720-h310",GameId=Games[11].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/y7On3vVZhFWycuekTPLwARYJ3MwQyODIzKHRt4ofyeS_gmXRDF271NsFDfu_lLhlX2Rj=w720-h310",GameId=Games[12].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/y7On3vVZhFWycuekTPLwARYJ3MwQyODIzKHRt4ofyeS_gmXRDF271NsFDfu_lLhlX2Rj=w720-h310",GameId=Games[12].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/y7On3vVZhFWycuekTPLwARYJ3MwQyODIzKHRt4ofyeS_gmXRDF271NsFDfu_lLhlX2Rj=w720-h310",GameId=Games[12].Id},
                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.ggpht.com/y7On3vVZhFWycuekTPLwARYJ3MwQyODIzKHRt4ofyeS_gmXRDF271NsFDfu_lLhlX2Rj=w720-h310",GameId=Games[12].Id},

                 new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Qnm85mIcd32-R8IxmDXM1MPgCfpM2-duddE7P_iS55P0xFO6ZM9jo9dt6PThjWhZvw=w720-h310",GameId=Games[13].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Kri8NpWg8Nt5BmgNxbMCrW4vxk7LqzjpvibCYHb24_RJgS-l58n-gFR2f4RE_uGfuKI=w720-h310",GameId=Games[13].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/cOijr_HBBvrjn7t00qwPQiXJ2y53NMSMI4iF2YSH89RDlmpe_MbppoqJmXTyIUPCj7M=w720-h310",GameId=Games[13].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/uFYADCilcHxlddeBXKAAu9HNzQG0Mx1VqwuwGQg3WiXBZAg41hooWQTAUilvZetyYhqy=w720-h310",GameId=Games[13].Id},

                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Ziiu3YNdzaoJf7_rdy9tk7pbPiPlluFvA_JdU0FtzqlvZuLrfyuWNnfkRtMvxq4_lA=w720-h310",GameId=Games[14].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/YYz6o1qMBxop37bvU1rfACXRv1AS-gNHOCjUW9lp6eLDV7BQAZ7zUIkG3PF597svP4gP=w720-h310",GameId=Games[14].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/RdxHjaoI2WK-ku4--LmPMaZ6DkLVYt0q9IKiSrdqXnmMKlPo4hgZHf0VdN8Oee5pxg=w720-h310",GameId=Games[14].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/JMc16QhAhKFbnW2jusl-T6xu8xo31BDzv8h7APyDdU006PkYvtk3q3Ey76LU-G908M0=w720-h310",GameId=Games[14].Id},

                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/nNjmESXQm2dJupXjwYn9RvD6nhS6_5bAthB6GrjrHCdaoiftDAKABIEOBJd3paXCYg=w720-h310",GameId=Games[15].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/qSl0aQ-tQiBC_Ut0MC3n-I3HTgQsDQ52XUq_cnfu5rq9kyDSBs2vneGXZZ-PhVv8yb22=w720-h310",GameId=Games[15].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/5W6OOrho0AFit_nm98QqpCsu52uHc-kw7RQPK4_PUdGEi6DjrmfZdPJIGYl2u_3Ibw=w720-h310",GameId=Games[15].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/5W6OOrho0AFit_nm98QqpCsu52uHc-kw7RQPK4_PUdGEi6DjrmfZdPJIGYl2u_3Ibw=w720-h310",GameId=Games[15].Id},

                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/nlXezemMS359X8dy6MxUJMgumyw6abz15NX0CjtnT8V57vni_uuS3saDllIMeyfQ6e-6=w720-h310",GameId=Games[16].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/RhBTJ2IEOhtPEbOpmMTxfMC9iU06JihtylD-lQxbTrIPfT2U-B0YLAjGELbj2Ppk1w8=w720-h310",GameId=Games[16].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/W_3i_ZHnSjan-N8egYQy9sQw87CppDDda9ITzTIQyTFHZpO2VJlhCzP_BORM3Hd-CDw=w720-h310",GameId=Games[16].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/Ibj-Kt-6Pc1IBDVj0yWf1sNjSpdGpRlapbTbjc5MuitmDkoKVMP45GF0LBlg6pnIbYE=w720-h310",GameId=Games[16].Id},

                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/aU5RuCIDy7JzNtp5ib2huaa1t33TVY_zdsES_ooMWSwY6K1JnHG0HC9RK0OgVuXqs9U=w720-h310",GameId=Games[17].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/JJNpXkj5HNkscW_bmZ1yGu-GuakL4Q4zRwOPmACFaqbIT5C2HMaI4LwhjGNiIrup_Ew4=w720-h310",GameId=Games[17].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/3HUpkFFcnCkLbgUosodwIrfzzq3VkebxVQkjfa_uDhapJyrz0ATxq6wRyYpyxKauyg=w720-h310",GameId=Games[17].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/9lQV-3IWYXkSndN4GsVQTflvUCSKPMj-uSuH9tEd8FlHuBOslA52Q-Z7wEEKmhwuxJE=w720-h310",GameId=Games[17].Id},

                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/DQppPRLU04SzwExhZTIKsYL1y3iZXzRsZbTBrmHJqJO1aTCsApHGdYxTKt3dvkN7ctRb=w720-h310",GameId=Games[18].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/FMgP9XZNML3lieBG9KDgiJGnT2WlmHMG5lFGcAl0rk93GtGFjf9X2J6vxcCCElNPJDw=w720-h310",GameId=Games[18].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/wzk-BPRwz5Lrh2YZ66uEJb8JjXkFE8oVm4RpZVTmWsCcx1e1nxP3XBhqr2q9Iff7Xica=w720-h310",GameId=Games[18].Id},
                new ImageGame(){Id=Guid.NewGuid(),UrlLocal="",UrlOnline="https://lh3.googleusercontent.com/-oRMqwODzaru2JCxLf3JtHVZXtpYfQ8Qo0IQRbRsZtssH6dUGr51WMfH0j3eMrfO5w=w720-h310",GameId=Games[18].Id},

            };
            modelBuilder.Entity<Game>().HasData(Games);
            modelBuilder.Entity<ImageGame>().HasData(ImageGames);

            var UserGames = new[]
            {
                new UserGame(){ UserId = Users[0].Id, GameId=Games[0].Id,PurchaseDate=new DateTime()},
                new UserGame(){ UserId = Users[1].Id, GameId=Games[1].Id ,PurchaseDate=new DateTime()},
                new UserGame(){ UserId = Users[2].Id, GameId=Games[2].Id,PurchaseDate=new DateTime()},
                new UserGame(){ UserId = Users[3].Id, GameId=Games[3].Id,PurchaseDate=new DateTime()},
                new UserGame(){ UserId = Users[4].Id, GameId=Games[4].Id,PurchaseDate=new DateTime()},
            };
            modelBuilder.Entity<UserGame>().HasData(UserGames);

            var CodeFrees = new[]
            {
                new FreeCode(){ Id = Guid.NewGuid(), Code = (Guid.NewGuid()).ToString(),GameId= Games[0].Id},
                new FreeCode(){ Id = Guid.NewGuid(), Code = (Guid.NewGuid()).ToString(),GameId= Games[1].Id},
                new FreeCode(){ Id = Guid.NewGuid(), Code = (Guid.NewGuid()).ToString(),GameId= Games[2].Id},
                new FreeCode(){ Id = Guid.NewGuid(), Code = (Guid.NewGuid()).ToString(),GameId= Games[3].Id},
                new FreeCode(){ Id = Guid.NewGuid(), Code = (Guid.NewGuid()).ToString(),GameId= Games[4].Id},
            };
            modelBuilder.Entity<FreeCode>().HasData(CodeFrees);

            var CategoryGames = new[]
           {
                new CategoryGame(){ GameId = Games[0].Id, CategoryId=Categories[0].Id},
                new CategoryGame(){ GameId = Games[1].Id, CategoryId=Categories[1].Id },
                new CategoryGame(){ GameId = Games[2].Id, CategoryId=Categories[2].Id},
                new CategoryGame(){ GameId = Games[3].Id, CategoryId=Categories[3].Id},
                new CategoryGame(){ GameId = Games[4].Id, CategoryId=Categories[4].Id},
            };
            modelBuilder.Entity<CategoryGame>().HasData(CategoryGames);

           


          

            var WishGames = new[]
           {
                new WishGame(){ UserId = Users[0].Id, GameId=Games[0].Id},
                new WishGame(){ UserId = Users[1].Id, GameId=Games[1].Id },
                new WishGame(){ UserId = Users[2].Id, GameId=Games[2].Id},
                new WishGame(){ UserId = Users[3].Id, GameId=Games[3].Id},
                new WishGame(){ UserId = Users[4].Id, GameId=Games[4].Id},
            };
            modelBuilder.Entity<WishGame>().HasData(WishGames);

            var Roles = new[]
           {
                new ApplicationRole(){ Id=Guid.NewGuid(),ConcurrencyStamp="User",Name="User",Description="Limited Permission",NormalizedName="User"},
                new ApplicationRole(){ Id=Guid.NewGuid(),ConcurrencyStamp="Admin",Name="Admin",Description="Full Permission",NormalizedName="Admin" },
            };
            modelBuilder.Entity<ApplicationRole>().HasData(Roles);

        }
    }
}
