using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CourseAssignment
    {
        public string ca_title { get; set; }
        public string ca_description { get; set; }

        [ForeignKey(nameof(Courses))]
        public int course_id { get; set; }

        [ForeignKey(nameof(CourseSection))]
        public int cs_id { get; set; }

    }
}
