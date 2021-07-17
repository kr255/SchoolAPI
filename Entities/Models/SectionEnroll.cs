using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SectionEnroll
    {
        [ForeignKey(nameof(Users))]
        public int  user_id { get; set; }

        public DateTime se_created_date { get; set; }
        public DateTime se_updated_date { get; set; }
        public DateTime se_start_date { get; set; }
        public DateTime se_end_date { get; set; }

        [ForeignKey(nameof(CourseSection))]
        public int cs_id { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
