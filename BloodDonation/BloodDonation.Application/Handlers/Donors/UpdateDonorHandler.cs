using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Infrastructure.ExternalApi.CepApi;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorRequest, ApiResponse<InputDonorResponse>>
    {
        private readonly ICepRepository _iCepRepository;
        private readonly IDonorRepository _iDonorRepository;
        private readonly IAddressRepository _iAddressRepository;
        private readonly IUserRepository _iUserRepository;

        public UpdateDonorHandler(ICepRepository iCepRepository, IDonorRepository iDonorRepository, IAddressRepository iAddressRepository, IUserRepository iUserRepository)
        {
            _iCepRepository = iCepRepository;
            _iDonorRepository = iDonorRepository;
            _iAddressRepository = iAddressRepository;
            _iUserRepository = iUserRepository;
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

                var user = await _iUserRepository.GetById(request.IdUser, cancellationToken);
                if (user == null)
                    return ApiResponse<InputDonorResponse>.Error(MensagemError.NotFound("utilizador"));

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
                donor.User = user;
                donor.IdUser = user.Id;
                donor.DateOfBirth = DateTime.Parse(request.DateOfBirth);

                donor.Address.Cep = newAddress.Cep;
                donor.Address.City = newAddress.City;
                donor.Address.State = newAddress.State;
                donor.Address.Logradouro = newAddress.Logradouro;

                await _iDonorRepository.Update(donor, cancellationToken);
                var result = new InputDonorResponse(donor.Id, donor.Name, donor.Email, donor.Phone);
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
