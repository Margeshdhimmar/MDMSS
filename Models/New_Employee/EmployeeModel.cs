using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MD.Models.New_Employee
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Required Field")]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}