using BankApp.Core.Domain.Entities;
using FluentValidation;

namespace BankApp.Validation
{
    public class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator()
        {

        }
    }
}
