﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Entities.Configuration;

namespace Entities
{
    public class RepositoryContext :  DbContext
    {
        public RepositoryContext(DbContextOptions options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseAssignmentConfiguration());

            modelBuilder.ApplyConfiguration(new SectionEnrollConfiguration());
            modelBuilder.ApplyConfiguration(new CourseSectionConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<SectionEnroll> SectionEnrolls { get; set; }
    }
}
