using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(t => t.CardNumber).NotEmpty();
            RuleFor(t => t.CreditCardTypeId).NotEmpty();
            RuleFor(t => t.Cvv).NotNull();
            RuleFor(t => t.FirstName).NotEmpty();
            RuleFor(t => t.LastName).NotEmpty();
            RuleFor(t => t.ExpirationMonth).NotEmpty();
            RuleFor(t => t.ExpirationYear).NotEmpty();
        }
    }
}