using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NuPortal.Models
{
    public class Login
    {
        [Required(ErrorMessage = "UserName required")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string ErrorMessage { get; set; }
    }
}