using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Profile : BaseEntity
    {
        [MaxLength(30)]
        public required string Name { get; set; }
    }
}
