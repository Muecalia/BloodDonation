using BloodDonation.Core.Entities;

namespace BloodDonation.Infrastructure.ExternalApi.CepApi
{
    public interface ICepRepository
    {
        Task<Address> GetAddress(string cep, CancellationToken cancellationToken);
    }
}
