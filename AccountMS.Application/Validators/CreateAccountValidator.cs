using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountMS.Commons.Dtos.Request;
using FluentValidation;

namespace AccountMS.Application.Validators
{
    public class CreateAccountValidator : ValidatorBase<CreateAccountDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(s => s.AccountNumber).NotNull().WithMessage("No puede ser nulo").WithErrorCode("654");
        }
    }
}
