using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.DepartmentEntites
{
    public class DepartmentValidation : AbstractValidator<Department>
    {
        public DepartmentValidation()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Provide department name.");
        }
    }
}
