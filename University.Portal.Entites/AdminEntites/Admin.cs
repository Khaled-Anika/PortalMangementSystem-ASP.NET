using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.AdminEntites
{
    public class Admin
    {
        [Key]
        public int  Id { get; set; }

        public string AdminId { get; set; }

        public string FullName { get; set; }

    }
}
