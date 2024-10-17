using BloodDonation.Application.Commands.Request.Users;
using FluentValidation;

namespace BloodDonation.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() 
        {
            RuleFor(u =>  u.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o nome");

            RuleFor(u => u.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Informa o e-mail");

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informa a senha")
                .MinimumLength(4).WithMessage("Tamanho mínimo da senha é de 4 caracteres");

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
