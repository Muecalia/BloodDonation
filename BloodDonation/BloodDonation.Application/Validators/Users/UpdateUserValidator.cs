using BloodDonation.Application.Commands.Request.Users;
using FluentValidation;

namespace BloodDonation.Application.Validators.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator() 
        {
            RuleFor(u => u.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Informa o código do utilizador");

            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o nome");

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Informa o e-mail");

            RuleFor(u => u.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informa o telefone")
                .MinimumLength(9).WithMessage("Tamanho mínimo do telefone é de 9 digitos");

            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage("Informa o perfil");
        }
    }
}
