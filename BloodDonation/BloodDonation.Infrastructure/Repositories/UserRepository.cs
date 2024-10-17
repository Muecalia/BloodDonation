using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BloodDonationContext _context;

        public UserRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task Delete(User user, CancellationToken cancellationToken)
        {
            user.IsDeleted = true;
            user.DeletedAt = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<User?> GetByIdEmail(int id, string email, CancellationToken cancellationToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id && string.Equals(u.Email, email), cancellationToken);
        }

        public async Task<User?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id, cancellationToken);
        }

        public async Task<User?> GetByIdDetail(int id, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(u => u.Donations)
                .FirstOrDefaultAsync(u => !u.IsDeleted && u.Id == id, cancellationToken);
        }

        public async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => string.Equals(u.Email, email), cancellationToken);
        }

        public async Task<bool> IsUserExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Name.Equals(name), cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            user.UpdatedAt = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
