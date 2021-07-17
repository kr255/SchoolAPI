﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models
{

    public enum status { FRESHMAN, SOPHMORE, JUNIOR, SENIOR, ALUMNI, NA }
    public enum system_role_id { STUDENT, FACULTY, STAFF }
    public class Users
    {
        [Key]
        public int user_id { get; set; }

        [Required(ErrorMessage = "student name is a required field.")]
        public string name { get; set;}
        [Required(ErrorMessage = "student password is a required field.")]
        public string password { get; set;}
        [Required(ErrorMessage = "student email is a required field.")]
        public string email { get; set;}
        public status enroll_status { get; set; }
        public system_role_id sys_role_id { get; set; }
        public DateTime created_date { get; set;}
        public DateTime updated_date { get; set;}

        //public ICollection<Users> All_Users { get; set; }
    }
}
