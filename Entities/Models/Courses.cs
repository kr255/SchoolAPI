using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Courses
    {
        [Key]
        [Column("course_id")]
        public int courseid { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set; }
        public DateTime course_created_date { get; set; }
        public DateTime course_updated_date { get; set; }

        //ICollection<CourseSection> courseSection { get; set; }
    }
}
