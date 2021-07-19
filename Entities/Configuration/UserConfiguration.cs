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
                    user_id = 999,
                    name = "Test User",
                    password = "TESTtest",
                    email = "testStudent@school.com",
                    enroll_status = status.FRESHMAN,
                    sys_role_id = system_role_id.STUDENT

                }
                
            );
            //throw new NotImplementedException();
        }
    }
}
