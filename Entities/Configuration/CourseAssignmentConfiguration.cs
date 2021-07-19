using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            //throw new NotImplementedException();
            builder.HasData
            (
                new CourseAssignment
                { 
                    ca_title = "Testing Title Man",
                    ca_description = "Description of Title",
                    course_id = 999,
                    cs_id = 999
                }
            );
        }
    }
}
