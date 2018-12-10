using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasMany(a => a.Categories)
                .WithOne(c => c.Game)
                .HasForeignKey(o => o.GameId)
                .OnDelete(DeleteBehavior.Cascade);
            //builder
            //    .HasMany(a => a.FreeCodes)
            //    .WithOne(f => f.Game)
            //    .HasForeignKey(o => o.GameId)
            //    .OnDelete(DeleteBehavior.Cascade);
          
            builder
                .HasOne(a => a.Publisher)
                .WithMany(p => p.Games)
                .HasForeignKey(a => a.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);
       

            builder
                .Property(f => f.PublisherId)
                .IsRequired();

            builder.Property(f => f.Price)
                .IsRequired();
        }
    }
}
