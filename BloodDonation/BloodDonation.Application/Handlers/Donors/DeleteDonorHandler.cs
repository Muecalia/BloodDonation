using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Infrastructure.Interfaces;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorRequest, ApiResponse<InputDonorResponse>>
    {
        private readonly IDonorRepository _iDonorRepository;

        public DeleteDonorHandler(IDonorRepository iDonorRepository)
        {
            _iDonorRepository = iDonorRepository;
        }

        public async Task<ApiResponse<InputDonorResponse>> Handle(DeleteDonorRequest request, CancellationToken cancellationToken)
        {
            var ENTIDADE = "doador";
            var OPERACAO = "eliminar";
            try
            {
                var donor = await _iDonorRepository.GetDonor(request.Id, cancellationToken);
                if (donor == null)
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.NotFound(ENTIDADE));

                donor.IsDeleted = true;
                donor.DeletedAt = DateTime.Now;
                
                await _iDonorRepository.Delete(donor, cancellationToken);

                var result = new InputDonorResponse
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    Email = donor.Email,
                    Phone = donor.Phone,
                    DataOperacao = donor.DeletedAt?.ToShortDateString()
                };
                return ApiResponse<InputDonorResponse>.Success(result, MensagemError.OperacaoSucesso(ENTIDADE, OPERACAO));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Message: {ex}");
                return ApiResponse<InputDonorResponse>.Error(MensagemError.OperacaoErro(ENTIDADE, OPERACAO, ex.Message));
                //throw;
            }
        }
    }
}
