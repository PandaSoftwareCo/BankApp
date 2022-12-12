using BankApp.Core.Domain.Entities;
using FluentValidation;

namespace BankApp.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Name).Length(2, 10);
            //RuleFor(x => x.Email).EmailAddress();
            //RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}
