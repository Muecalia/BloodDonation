using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class User : BaseEntity
    {
        public User() 
        {
            Donors = [];
            Donations = [];
        }

        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        [MaxLength(20)]
        public required string Phone { get; set; }
        [MaxLength(200)]
        public required string Password { get; set; }
        public required string Role { get; set; }
        public List<Donor> Donors { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
