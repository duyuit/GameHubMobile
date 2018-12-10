using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GameStore.Model;
using GameStore.Extention;

namespace GameStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole,Guid>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FreeCode> FreeCodes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<WishGame> WishGame { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CategoryGame> CategoryGames { get; set; }
        public DbSet<ImageGame> ImageGames { get; set; }
        public DbSet<ImageUser> ImageUsers { get; set; }
        public DbSet<ImagePublisher> ImagePublishers { get; set; }
        //public DbSet<ImageCategory> ImageCategories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //configure entities
            builder.ApplyEntityConfigurations();
            //base builder
            base.OnModelCreating(builder);
            //chaneg Name table for helpful
            builder.ChangeIdentityTableNames();
            //seed data 

            builder.SeedData();
        }

    }
}
