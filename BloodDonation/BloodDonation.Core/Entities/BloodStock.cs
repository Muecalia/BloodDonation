using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        [MaxLength(3), Required]
        public required string BloodType { get; set; }
        [MaxLength(10), Required]
        public required string FactorRh { get; set; }
        [Required]
        public required int QtdMl { get; set; }
    }
}
