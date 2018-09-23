using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.StudentEntites
{
    public class StudentCredentialValidation: AbstractValidator<StudentCredential>
    {
        public StudentCredentialValidation()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Enter ID.");
            RuleFor(x => x.StudentId).Must(ValidateStudentId).WithMessage("Format is wrong.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter Password.");
        }

        private bool ValidateStudentId(string code)
        {
            string[] id = code.Split('-');
            if (id.Length == 3)
            {
                foreach (string part in id)
                {
                    if (part.Length != 3)
                        return false;
                }
            }
            else
                return false;

            return true;
        }
    }
}
