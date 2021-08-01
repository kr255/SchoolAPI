using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class StudentSectionEnroll
    {
        [Column("user_id")]

        public int user_id { get; set; }
        public Users user { get; set; }
        
        [Column("section_enroll_key")]
        public int section_key { get; set; }
        public SectionEnroll section { get; set; }
    }
}
