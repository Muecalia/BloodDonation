using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address, CancellationToken cancellationToken);
        Task Update(Address address, CancellationToken cancellationToken);
        Task Delete(Address address, CancellationToken cancellationToken);
        //Task<bool> IsAddressExist(string name, CancellationToken cancellationToken);
        Task<Address?> GetAddress(int Id, CancellationToken cancellationToken);
        //Task<Address?> GetAddressDetail(int Id, CancellationToken cancellationToken);
        //Task<List<Address>> GetAllAddresss(CancellationToken cancellationToken);
    }
}
