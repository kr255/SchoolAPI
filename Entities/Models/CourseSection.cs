using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{
    public class CourseSection
    {
        [Key]
        [Column("course_section_id")]
        public int cs_id { get; set; }
        public DateTime cs_create_date { get; set; }
        public DateTime cs_update_date { get; set; }
        public DateTime cs_start_date { get; set; }
        public DateTime cs_end_date { get; set; }
        //public ICollection<CourseAssignment> courseAssignments { get; set; }

        [ForeignKey(nameof(Courses))]
        public int courseid { get; set; }
        public Courses course { get; set; }

        public ICollection<CoursesSectionEnroll> CoursesSectionEnroll { get; set; }

    }
}
