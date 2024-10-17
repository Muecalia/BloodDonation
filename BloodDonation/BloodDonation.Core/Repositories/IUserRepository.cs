using BloodDonation.Core.Entities;

namespace BloodDonation.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id, CancellationToken cancellationToken);
        Task<User?> GetByIdEmail(int id, string email, CancellationToken cancellationToken);
        Task<User?> GetByIdDetail(int id, CancellationToken cancellationToken);
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<User> Create(User user, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task Delete(User user, CancellationToken cancellationToken);
        Task<bool> IsUserExist(string name, CancellationToken cancellationToken);
        Task<bool> IsEmailExist(string email, CancellationToken cancellationToken);
    }
}
