using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseAssignmentDTO
    {
        public string ca_title { get; set; }
        public string ca_description { get; set; }
        //public int course_id { get; set; }
        public int cs_id { get; set; }

        public string FullRecord { get; set; }

    }
}
