using BloodDonation.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonation.Infrastructure.Persistence
{
    public class BloodDonationContext : DbContext
    {
        public BloodDonationContext(DbContextOptions<BloodDonationContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>(e =>
            {
                e.HasKey(a => a.Id);

                e.HasOne(a => a.Donor)
                    .WithOne(a => a.Address)
                    .HasForeignKey<Donor>(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<BloodStock>(e => 
            {
                e.HasKey(bs => bs.Id);
            });

            builder.Entity<Donation>(e => 
            {
                e.HasKey(d => d.Id);
                e.HasIndex(d => d.IdDonor);
                e.HasIndex(d => d.IdUser);

                e.HasOne(d => d.Donor)
                    .WithMany(d => d.Donations)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.User)
                    .WithMany(e => e.Donations)
                    .HasForeignKey (e => e.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Donor>(e => 
            {
                e.HasKey(d => d.Id);
                e.HasIndex(d => d.Name);
                e.HasIndex(d => d.Email);

                e.HasOne(d => d.Address)
                    .WithOne(a => a.Donor)
                    .HasForeignKey<Donor>(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(d => d.User)
                    .WithMany(d => d.Donors)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(d => d.Donations)
                    .WithOne(d => d.Donor)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(e => 
            {
                e.HasKey(u => u.Id);
                e.HasIndex(u => u.Name);
                e.HasIndex(u => u.Email);

                e.HasMany(d => d.Donations)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(u => u.Donors)
                    .WithOne(d => d.User)
                    .HasForeignKey(e => e.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
