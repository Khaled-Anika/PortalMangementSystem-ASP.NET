using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.VModel.Entites
{
    public class VLogin
    {
        [Display(Name = "User ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User ID required")]
        public string UserId { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }





    }
}
