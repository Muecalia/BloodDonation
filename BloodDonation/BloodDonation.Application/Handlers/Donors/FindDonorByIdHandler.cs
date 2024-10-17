using BloodDonation.Application.Queries.Request.Donors;
using BloodDonation.Application.Queries.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class FindDonorByIdHandler : IRequestHandler<FindDonorByIdRequest, ApiResponse<FindDonorByIdResponse>>
    {
        private readonly IDonorRepository _repository;

        public FindDonorByIdHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<FindDonorByIdResponse>> Handle(FindDonorByIdRequest request, CancellationToken cancellationToken)
        {
            string ENTIDADE = "doador";
            try
            {
                var donor = await _repository.GetDonorDetail(request.Id, cancellationToken);
                if (donor == null)
                    return ApiResponse<FindDonorByIdResponse>.Error(MensagemError.NotFound(ENTIDADE));

                var result = new FindDonorByIdResponse 
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    Email = donor.Email,
                    BloodType = donor.BloodType,
                    CreatedAt = donor.CreatedAt.ToShortDateString(),
                    DateOfBirth = donor.DateOfBirth.ToShortDateString(),
                    FactorRh = donor.FactorRh,
                    Gender = donor.Gender,
                    Phone = donor.Phone,
                    UpdatedAt = donor.UpdatedAt?.ToShortDateString(),
                    Weight = donor.Weight,
                    Address = new FindAddressResponse {
                        Cep = donor.Address.Cep,
                        City = donor.Address.City,
                        Id = donor.Address.Id,
                        Logradouro = donor.Address.Logradouro,
                        State = donor.Address.State
                    }
                };

                return ApiResponse<FindDonorByIdResponse>.Success(result, MensagemError.CarregamentoSucesso(ENTIDADE));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(MensagemError.CarregamentoErro(ENTIDADE, ex.Message));
                throw;
            }
        }
    }
}
