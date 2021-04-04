using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    class CustomersValidator : AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(cust => cust.CompanyName).NotEmpty();
        }
    }
}
