using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class WishGameConfigurations : IEntityTypeConfiguration<WishGame>
    {
        public void Configure(EntityTypeBuilder<WishGame> builder)
        {
            builder
                .HasKey(t => new { t.UserId, t.GameId });
            builder.Property(pc => pc.UserId).IsRequired();
            builder.Property(pc => pc.GameId).IsRequired();
            builder
                .HasOne(c => c.User)
                .WithMany(c => c.WishGames)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(c => c.Game)
                .WithMany(c => c.FavoriteMembers)
                .HasForeignKey(pc => pc.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
