using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public status enroll_status { get; set; }
        public system_role_id sys_role_id { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }

        public string FullRecord { get; set; }
    }
}
