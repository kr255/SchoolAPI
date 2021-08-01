using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CoursesDTOForCreating
    {
        // int courseid { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set; }
        public DateTime course_created_date { get; set; }
        public DateTime course_updated_date { get; set; }

       // public string FullRecord { get; set; }

    }
}
