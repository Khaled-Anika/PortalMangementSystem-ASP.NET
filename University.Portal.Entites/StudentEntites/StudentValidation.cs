using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.StudentEntites
{
    public class StudentValidation: AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Enter Id.");
            RuleFor(x => x.StudentId).Must(ValidateCode).WithMessage("Format is wrong.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Enter First name.");
            RuleFor(x => x.FirstName).MaximumLength(100).WithMessage("First name must be less than 100 characters.");
            RuleFor(x => x.MiddleName).MaximumLength(100).WithMessage("Middle name must be less than 100 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Enter Last name.");
            RuleFor(x => x.LastName).MaximumLength(100).WithMessage("Last name must be less than 100 characters.");

        }

        private bool ValidateCode(string code)
        {
            if (code != null)
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
            else
            {
                return false;
            }
        }
    }
}
