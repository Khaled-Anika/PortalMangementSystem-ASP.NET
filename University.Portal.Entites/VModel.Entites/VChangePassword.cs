using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.VModel.Entites
{
    public class VChangePassword
    {
        [Required(ErrorMessage = "Current Password  required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]

        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        //[MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        [Required(ErrorMessage = "Confirm password required", AllowEmptyStrings = false)]
        public string ConfirmPassword { get; set; }
    }
}
