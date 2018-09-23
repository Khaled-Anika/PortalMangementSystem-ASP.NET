using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.DegreeEntities
{
    public class DegreeValidation : AbstractValidator<Degree>
    {
        public DegreeValidation()
        {
            RuleFor(x => x.DegreeName).NotEmpty().WithMessage("Provide degree.");
        }
    }
}
