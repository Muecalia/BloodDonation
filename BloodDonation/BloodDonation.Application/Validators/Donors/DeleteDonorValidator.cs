using BloodDonation.Application.Commands.Request.Donors;
using FluentValidation;

namespace BloodDonation.Application.Validators.Donors
{
    public class DeleteDonorValidator : AbstractValidator<DeleteDonorRequest>
    {
        public DeleteDonorValidator() 
        {
            RuleFor(d => d.Id)
                .LessThanOrEqualTo(0).WithMessage("Informa o código do doador");
        }
    }
}
