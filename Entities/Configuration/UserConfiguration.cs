using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData
            (
            
                new Users
                { 
                    UserId = 999,
                    name = "Test User",
                    password = "TESTtest",
                    email = "testStudent@school.com",
                    enroll_status = status.FRESHMAN,
                    sys_role_id = system_role_id.STUDENT,
                    created_date =  new DateTime(2020, 1, 1),
                    updated_date = new DateTime(2020, 1, 1)

                },

                new Users
                {
                    UserId = 99,
                    name = "Test User 2",
                    password = "TESTtest2",
                    email = "testStudent2@school.com",
                    enroll_status = status.SOPHMORE,
                    sys_role_id = system_role_id.STUDENT,
                    created_date = new DateTime(2020, 1, 2),
                    updated_date = new DateTime(2020, 1, 2)

                }

            );
            //throw new NotImplementedException();
        }
    }
}
