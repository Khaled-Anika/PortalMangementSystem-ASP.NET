using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.SemesterEntities
{
    public class SemesterValidation: AbstractValidator<Semester>
    {
        public SemesterValidation()
        {
            RuleFor(x => x.SemesterCode).NotEmpty().WithMessage("Enter semseter code.");
            RuleFor(x => x.year).NotEmpty().WithMessage("Enter year.");
            RuleFor(x => x.year).Must(ValidateYear).WithMessage("Format is wrong.");
        }

        private bool ValidateYear(string year)
        {
            if (year != null)
            {
                if (year.Length == 4)
                {
                    return true;
                }
                else
                    return false;
            }
           else
            {
                return false;
            }
        }
    }
}
