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
                    section_key = 009,
                    //UserId = 999,
                   // cs_id = 999,
                    se_created_date =  new DateTime(2020, 1, 1),
                    se_end_date = new DateTime(2020, 5, 1),
                    se_start_date = new DateTime(2020, 1, 1),
                    se_updated_date = new DateTime(2020, 1, 1)
                }
            );
        }
    }
}
