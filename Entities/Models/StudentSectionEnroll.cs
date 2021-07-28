using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class StudentSectionEnroll
    {
        public int user_id { get; set; }
        public Users user { get; set; }

        public int section_key { get; set; }
        public SectionEnroll section { get; set; }
    }
}
