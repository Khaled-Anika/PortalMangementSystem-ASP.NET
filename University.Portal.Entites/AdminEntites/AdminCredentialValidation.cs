using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.AdminEntites
{
    public class AdminCredentialValidation : AbstractValidator<AdminCredential>
    {
        public AdminCredentialValidation()
        {
            RuleFor(x => x.AdminId).NotEmpty().WithMessage("Enter ID.");
            RuleFor(x => x.AdminId).Must(ValidateAdminId).WithMessage("Format is wrong.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter password.");
        }

        private bool ValidateAdminId(string code)
        {
            string[] id = code.Split('-');
            if (id.Length == 3)
            {
                if (id[0].Length != 4)
                    return false;

                for(int i=1;i<3;i++)
                {
                    if (id[i].Length != 3)
                        return false;
                }
            }
            else
                return false;

            return true;
        }
    }
}
