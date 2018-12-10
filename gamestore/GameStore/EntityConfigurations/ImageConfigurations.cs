using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<ImageGame>
    {
        public void Configure(EntityTypeBuilder<ImageGame> builder)
        {
            builder
           .HasOne(a => a.Game)
           .WithMany(p => p.ImageGames)
           .HasForeignKey(a => a.GameId)
           .OnDelete(DeleteBehavior.Cascade);
        }

      
    }
}
