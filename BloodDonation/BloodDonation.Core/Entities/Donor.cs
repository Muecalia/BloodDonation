using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Donor : BaseEntity
    {
        public Donor() : base()
        {
            Donations = [];
        }

        [MaxLength(100)]
        public required string Name { get; set; }
        public required DateTime DateOfBirth { get; set; }
        [EmailAddress, Required, MaxLength(100)]
        public required string Email { get; set; }
        [MaxLength(20), Required]
        public required string Phone { get; set; }
        [Required]
        public required char Gender { get; set; }
        [MaxLength(10), Required]
        public required string FactorRh { get; set; }
        [MaxLength(3), Required]
        public required string BloodType { get; set; }
        [Required]
        public double Weight { get; set; }
        public required int IdAddress { get; set; }
        [Required]
        public required Address Address { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
