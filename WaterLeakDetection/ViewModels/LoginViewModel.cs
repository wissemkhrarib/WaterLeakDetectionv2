using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterLeakDetection.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        [DataType(DataType.EmailAddress),Display(Name ="Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber), Display(Name = "Phone")]

        public string PhoneNumber { get; set; }
        public string ReturnUrl { get; set; }



    }
}
