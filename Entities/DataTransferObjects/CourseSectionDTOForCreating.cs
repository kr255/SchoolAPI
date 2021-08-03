using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CourseSectionDTOForCreating
    {
        //public int cs_id { get; set; }
        //public int course_id { get; set; }
        public DateTime cs_create_date { get; set; }
        public DateTime cs_update_date { get; set; }
        public DateTime cs_start_date { get; set; }
        public DateTime cs_end_date { get; set; }

        //public string FullRecord { get; set; }
        public IEnumerable<CourseAssignmentDTOForCreating> courseAssignment { get; set; }

    }
}
