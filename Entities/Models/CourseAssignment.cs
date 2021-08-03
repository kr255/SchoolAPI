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

        // would do string cleaning here if it were required
        public string ca_title { get; set; }
        public string ca_description { get; set; }


        [ForeignKey(nameof(CourseSection))]
        public int cs_id { get; set; }
        public CourseSection CourseSection { get; set; }

    }
}
