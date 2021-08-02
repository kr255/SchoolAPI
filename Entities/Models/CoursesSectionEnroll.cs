using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class CoursesSectionEnroll
    {
        public int cs_id { get; set; }
        public CourseSection CourseSection { get; set; }
        public int section_key { get; set; }
        public SectionEnroll SectionEnroll { get; set; }
    }
}
