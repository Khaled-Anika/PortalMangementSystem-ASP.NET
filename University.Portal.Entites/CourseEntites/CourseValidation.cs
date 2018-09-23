using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.CourseEntites
{
    public class CourseValidation : AbstractValidator<Course>
    {
        public CourseValidation()
        {
            RuleFor(x => x.CourseCode).NotEmpty().WithMessage("Provide course code.");
            RuleFor(x => x.CourseCode).Must(ValidateCode).WithMessage("Format is wrong.");
            RuleFor(x => x.CourseName).NotEmpty().WithMessage("Provide corse name.");
            RuleFor(x => x.Credit).NotEmpty().WithMessage("Provide credit.");
        }

        private bool ValidateCode(string code)
        {
            if (code != null)
            {
                if (code.Length == 6)
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
