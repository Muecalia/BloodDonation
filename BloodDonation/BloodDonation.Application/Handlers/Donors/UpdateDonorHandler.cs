using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Infrastructure.ExternalApi.CepApi;
using BloodDonation.Infrastructure.Interfaces;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorRequest, ApiResponse<InputDonorResponse>>
    {
        private readonly ICepRepository _iCepRepository;
        private readonly IDonorRepository _iDonorRepository;
        private readonly IAddressRepository _iAddressRepository;

        public UpdateDonorHandler(ICepRepository iCepRepository, IDonorRepository iDonorRepository, IAddressRepository iAddressRepository)
        {
            _iCepRepository = iCepRepository;
            _iDonorRepository = iDonorRepository;
            _iAddressRepository = iAddressRepository;
        }

        public async Task<ApiResponse<InputDonorResponse>> Handle(UpdateDonorRequest request, CancellationToken cancellationToken)
        {
            string ENTIDADE = "doador";
            string OPERATION = "editar";
            try
            {
                var donor = await _iDonorRepository.GetDonorDetail(request.Id, cancellationToken);
                if (donor == null)
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.NotFound(ENTIDADE));

                var newAddress = await _iCepRepository.GetAddress(request.Cep, cancellationToken);
                if (newAddress == null)
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.NotFound("CEP"));

                donor.Name = request.Name;
                donor.Email = request.Email;
                donor.Phone = request.Phone;
                donor.Weight = request.Weight;
                donor.Gender = request.Gender;
                donor.FactorRh = request.FactorRh;
                donor.BloodType = request.BloodType;
                donor.DateOfBirth = DateTime.Parse(request.DateOfBirth);

                donor.Address.Cep = newAddress.Cep;
                donor.Address.City = newAddress.City;
                donor.Address.State = newAddress.State;
                donor.Address.Logradouro = newAddress.Logradouro;

                //await _iAddressRepository.Update(donor.Address, cancellationToken);
                await _iDonorRepository.Update(donor, cancellationToken);
                var result = new InputDonorResponse
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    Email = donor.Email,
                    Phone = donor.Phone,
                    DataOperacao = donor.CreatedAt.ToShortDateString()
                };
                return ApiResponse<InputDonorResponse>.Success(result, MensagemError.OperacaoSucesso(ENTIDADE, OPERATION));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Message: {ex}");
                return ApiResponse<InputDonorResponse>.Error(MensagemError.OperacaoErro(ENTIDADE, OPERATION, ex.Message));
                //throw;
            }
        }

    }
}
