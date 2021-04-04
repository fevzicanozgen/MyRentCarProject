using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class UsersValidator : AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(users => users.Email).NotEmpty();
            RuleFor(users => users.FirstName).NotEmpty();
            RuleFor(users => users.LastName).NotEmpty();
            RuleFor(users => users.Password).NotEmpty();
        }
    }
}
