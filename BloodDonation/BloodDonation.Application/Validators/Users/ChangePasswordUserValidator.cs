using BloodDonation.Application.Commands.Request.Users;
using FluentValidation;

namespace BloodDonation.Application.Validators.Users
{
    public class ChangePasswordUserValidator : AbstractValidator<ChangePasswordUserRequest>
    {
        public ChangePasswordUserValidator() 
        {
            //RuleFor(u => u.Id)
            //    .NotNull()
            //    .NotEmpty()
            //    .GreaterThan(0)
            //    .WithMessage("Informa o código do utilizador");

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Informa o e-mail");

            RuleFor(u => u.NewPassword)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informa a nova senha")
                .MinimumLength(4).WithMessage("Tamanho mínimo da senha é de 4 caracteres");
        }
    }
}
