using BankApp.Core.Domain.Entities;
using FluentValidation;

namespace BankApp.Validation
{
    public class BankTransactionValidator : AbstractValidator<BankTransaction>
    {
        public BankTransactionValidator()
        {

        }
    }
}
