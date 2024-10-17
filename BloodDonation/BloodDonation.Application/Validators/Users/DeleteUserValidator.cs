using BloodDonation.Application.Commands.Request.Users;
using FluentValidation;

namespace BloodDonation.Application.Validators.Users
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator() 
        {
            RuleFor(u => u.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Informa o código do utilizador");
        }
    }
}
