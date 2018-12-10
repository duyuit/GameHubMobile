using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class CategoryGameConfigurations : IEntityTypeConfiguration<CategoryGame>
    {
        public void Configure(EntityTypeBuilder<CategoryGame> builder)
        {
            builder
                .HasKey(t => new { t.GameId, t.CategoryId });
            builder.Property(pc => pc.GameId).IsRequired();
            builder.Property(pc => pc.CategoryId).IsRequired();
            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Games)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(c => c.Game)
                .WithMany(c => c.Categories)
                .HasForeignKey(pc => pc.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
