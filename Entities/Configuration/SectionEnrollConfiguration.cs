using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class SectionEnrollConfiguration : IEntityTypeConfiguration<SectionEnroll>
    {
        public void Configure(EntityTypeBuilder<SectionEnroll> builder)
        {
            builder.HasData
            (
                new SectionEnroll
                {
                    user_id = 999,
                    cs_id = 999

                     
                }
            );
        }
    }
}
