using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SectionEnrollDTOForCreating
    {
        public int user_id { get; set; }

        public DateTime se_created_date { get; set; }
        public DateTime se_updated_date { get; set; }
        public DateTime se_start_date { get; set; }
        public DateTime se_end_date { get; set; }
        public int cs_id { get; set; }

        public string FullRecord { get; set; }

    }
}
