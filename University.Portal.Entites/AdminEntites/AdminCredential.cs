using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.AdminEntites
{
    public class AdminCredential
    {
        [Key]
        public int AdminCredentialId { get; set; }
        public string AdminId { get; set; }
        public string Password { get; set; }
    }
}
