using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class CourseSectionConfiguration : IEntityTypeConfiguration<CourseSection>
    {
        public void Configure(EntityTypeBuilder<CourseSection> builder)
        {
            builder.HasData
            (
                new CourseSection
                {
                    course_id = 999,
                    cs_id = 999,
                    cs_create_date = new DateTime(2020, 1, 1),
                    cs_end_date = new DateTime(2020, 6, 1),
                    cs_start_date = new DateTime(2020, 1, 1),
                    cs_update_date = new DateTime(2020, 1, 1)
                    
                }
            );
        }
    }
}
