﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class SectionEnroll
    {
        [Key]
        [Column("section_enroll_key")]

        public int section_key { get; set; }
        
        //[ForeignKey(nameof(Users))]
       // public int UserId { get; set; }
        public ICollection<StudentSectionEnroll> StudentSectionEnroll { get; set; }

        public DateTime se_created_date { get; set; }
        public DateTime se_updated_date { get; set; }
        public DateTime se_start_date { get; set; }
        public DateTime se_end_date { get; set; }

        //[ForeignKey(nameof(CourseSection))]
        //public int cs_id { get; set; }
        public ICollection<CoursesSectionEnroll> CoursesSectionEnroll { get; set; }

    }
}
