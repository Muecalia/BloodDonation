using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Utils;
using FluentValidation;

namespace BloodDonation.Application.Validators.Donors
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorRequest>
    {
        public CreateDonorValidator() 
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(2).WithMessage("O tamanho de caracteres deve ser maior ou igual a 2");

            RuleFor(d => d.Phone)
                .NotEmpty().WithMessage("Informe o número de telefone")
                .MinimumLength(9).WithMessage("O tamanho de caracteres deve ser maior ou igual a 9");

            RuleFor(d => d.Email)
                .NotEmpty().WithMessage("Informe o e-mail")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(d => d.Gender)
                .NotEmpty().WithMessage("Informe o genero");

            RuleFor(d => d.BloodType)
                .NotEmpty().WithMessage("Informe o tipo sanguíneo");

            RuleFor(d => d.FactorRh)
                .NotEmpty().WithMessage("Informe o Factor de Rh");

            RuleFor(d => d.Cep)
                .NotEmpty().WithMessage("Informe um CEP válido");

            RuleFor(d => d.Weight)
                .GreaterThanOrEqualTo(50).WithMessage("O peso não pode estar abaixo de 50KG");

            RuleFor(d => d.DateOfBirth)
                .NotEmpty().WithMessage("Informe a data de nascimento")
                .Must(GeneralService.IsValidDateOfBirth).WithMessage("Data de nascimento inválida ou o doador deve ter pelo menos 15 anos");
        }
    }
}
