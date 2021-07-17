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
        public int cs_id { get; set; }

        [ForeignKey(nameof(Courses))]
        public int course_id { get; set; }

        public DateTime cs_create_date { get; set; }
        public DateTime cs_update_date { get; set; }
        public DateTime cs_start_date { get; set; }
        public DateTime cs_end_date { get; set; }

        public ICollection<CourseAssignment> courseAssignments { get; set; }
    }
}
