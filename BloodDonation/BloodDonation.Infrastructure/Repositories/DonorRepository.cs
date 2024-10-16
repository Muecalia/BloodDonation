using BloodDonation.Core.Entities;
using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        public readonly BloodDonationContext _context;

        public DonorRepository(BloodDonationContext context)
        {
            _context = context;
        }

        public async Task<Donor> Create(Donor donor, CancellationToken cancellationToken)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync(cancellationToken);
            return donor;
        }

        public async Task Delete(Donor donor, CancellationToken cancellationToken)
        {
            donor.IsDeleted = true;
            donor.DeletedAt = DateTime.Now;
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Donor>> GetAllDonors(CancellationToken cancellationToken)
        {
            return await _context.Donors
                .Where(d => !d.IsDeleted)
                .ToListAsync(cancellationToken);
        }

        public async Task<Donor?> GetDonor(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donors.FirstOrDefaultAsync(d => !d.IsDeleted && d.Id == Id, cancellationToken);
        }

        public async Task<Donor?> GetDonorDetail(int Id, CancellationToken cancellationToken)
        {
            return await _context.Donors
                .Include(d => d.Address)
                .Include(d => d.Donations)
                .FirstOrDefaultAsync(d => !d.IsDeleted && d.Id == Id, cancellationToken);
        }

        public async Task<bool> IsDonorExist(string name, CancellationToken cancellationToken)
        {
            return await _context.Donors.AnyAsync(d => string.Equals(d.Name, name), cancellationToken);
        }

        public async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
        {
            return await _context.Donors.AnyAsync(d => email.Equals(d.Email), cancellationToken);
        }

        public async Task Update(Donor donor, CancellationToken cancellationToken)
        {
            donor.UpdatedAt = DateTime.Now;
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
