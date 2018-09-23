using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace University.Portal.Application.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string CurrentPassword { set; get; }

        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string NewPassword { get; set; }

        [Required]
        [CompareAttribute("NewPassword", ErrorMessage = "Password did not match!")]
        public string RetypePassword { get; set; }
    }
}