using BankApp.Core.Domain.Entities;
using FluentValidation;

namespace BankApp.Validation
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.AccountId).NotNull();
            RuleFor(x => x.AccountName).Length(0, 100);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);

        }
    }
}
