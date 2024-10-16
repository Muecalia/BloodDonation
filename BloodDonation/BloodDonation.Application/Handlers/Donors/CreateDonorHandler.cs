using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.ExternalApi.CepApi;
using BloodDonation.Infrastructure.Interfaces;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorRequest, ApiResponse<InputDonorResponse>>
    {
        private readonly ICepRepository _iCepRepository;
        private readonly IDonorRepository _iDonorRepository;
        private readonly IAddressRepository _iAddressRepository;

        public CreateDonorHandler(ICepRepository iCepRepository, IDonorRepository iDonorRepository, IAddressRepository iAddressRepository)
        {
            _iCepRepository = iCepRepository;
            _iDonorRepository = iDonorRepository;
            _iAddressRepository = iAddressRepository;
        }

        public async Task<ApiResponse<InputDonorResponse>> Handle(CreateDonorRequest request, CancellationToken cancellationToken)
        {
            string ENTIDADE = "doador";
            string OPERATION = "criar";
            try
            {
                if (await _iDonorRepository.IsDonorExist(request.Name, cancellationToken))
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.Conflito(ENTIDADE));

                if (await _iDonorRepository.IsEmailExist(request.Email, cancellationToken))
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.ConflitoEmail(request.Email));

                var newAddress = await _iCepRepository.GetAddress(request.Cep, cancellationToken);
                if (newAddress == null)
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.NotFound("CEP"));

                var address = await _iAddressRepository.Create(newAddress, cancellationToken);

                var newDonor = new Donor 
                {
                    Name = request.Name,
                    Email = request.Email,
                    BloodType = request.BloodType,
                    DateOfBirth = DateTime.Parse(request.DateOfBirth),
                    FactorRh = request.FactorRh,
                    Gender = request.Gender,
                    Phone = request.Phone,
                    Address = address,
                    IdAddress = address.Id
                };

                var donor = await _iDonorRepository.Create(newDonor, cancellationToken);
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
