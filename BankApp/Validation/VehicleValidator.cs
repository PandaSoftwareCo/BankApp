using BankApp.Core.Domain.Entities;
using FluentValidation;

namespace BankApp.Validation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {

        }
    }
}
