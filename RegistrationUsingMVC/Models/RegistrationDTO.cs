using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrationUsingMVC
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string User_Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string User_Contact { get; set; }

    }
}