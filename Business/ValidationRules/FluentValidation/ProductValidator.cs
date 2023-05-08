using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3);
            RuleFor(c => c.Surname).NotEmpty().MinimumLength(2);
            RuleFor(c => c.IdentityNo).NotEmpty().Length(11,11);
            RuleFor(c => c.BirthDate).NotNull();

        }

    }
}
