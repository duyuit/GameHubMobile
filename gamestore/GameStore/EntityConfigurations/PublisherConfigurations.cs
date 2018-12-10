using GameStore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.EntityConfigurations
{
    public class PublisherConfigurations : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
                      //builder
                      //.HasOne(a => a.ImagePublisher)
                      //.WithOne(p => p.Publisher)
                      //.HasForeignKey<Publisher>(a => a.ImagePublisherId)
                      //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
