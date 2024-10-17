using BloodDonation.Application.Queries.Request.Donors;
using BloodDonation.Application.Queries.Response.Donors;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Donors
{
    public class FindAllDonorsHandler : IRequestHandler<FindAllDonorsRequest, PagedResponse<FindAllDonorsResponse>>
    {
        private readonly IDonorRepository _repository;

        public FindAllDonorsHandler(IDonorRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<FindAllDonorsResponse>> Handle(FindAllDonorsRequest request, CancellationToken cancellationToken)
        {
            string ENTIDADE = "doador";
            try
            {
                var donors = await _repository.GetAllDonors(cancellationToken);
                var results = new List<FindAllDonorsResponse>();

                donors.ForEach(d => results.Add(new FindAllDonorsResponse 
                {
                    Id = d.Id,
                    Name = d.Name,
                    Email = d.Email,
                    Gender = d.Gender,
                    Phone = d.Phone,
                    CreatedAt = d.CreatedAt.ToShortDateString(),
                    UpdatedAt = d.UpdatedAt?.ToShortDateString(),
                    DateOfBirth = d.DateOfBirth.ToShortDateString()
                }));

                return new PagedResponse<FindAllDonorsResponse>(results, MensagemError.CarregamentoSucesso(ENTIDADE, donors.Count));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(MensagemError.CarregamentoErro(ENTIDADE, ex.Message));
                throw;
            }
        }
    }
}
