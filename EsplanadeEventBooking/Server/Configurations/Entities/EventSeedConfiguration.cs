using EsplanadeEventBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsplanadeEventBooking.Server.Configurations.Entities
{
    public class EventSeedConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasData(
                new Event
                {
                    Id = 1,
                    Title = "TwoSet vs Davie Concert",
                    Location = "Theatre",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    CreatorId = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            );
        }
    }
}
