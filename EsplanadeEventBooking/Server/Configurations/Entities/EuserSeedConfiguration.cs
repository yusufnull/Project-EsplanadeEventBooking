using EsplanadeEventBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsplanadeEventBooking.Server.Configurations.Entities
{
    public class EuserSeedConfiguration : IEntityTypeConfiguration<Euser>
    {
        public void Configure(EntityTypeBuilder<Euser> builder)
        {
            builder.HasData(
                new Euser
                {
                    Id = 1,
                    Name = "Adam",
                    Age = 20,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            );
        }
    }
}
