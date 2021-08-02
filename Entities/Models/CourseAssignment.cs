using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CourseAssignment
    {
        [Key]
        [Column("course_assignment_title")]

        public string ca_title { get; set; }
        public string ca_description { get; set; }


        [ForeignKey(nameof(CourseSection))]
        public int cs_id { get; set; }
        public CourseSection CourseSection { get; set; }

    }
}
