using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class StudentSectionEnroll
    {
        public int UserId { get; set; }
        public Users User { get; set; }
        
        public int section_key { get; set; }
        public SectionEnroll SectionEnroll { get; set; }
    }
}
