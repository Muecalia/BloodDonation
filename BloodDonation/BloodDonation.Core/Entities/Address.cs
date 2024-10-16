using System.ComponentModel.DataAnnotations;

namespace BloodDonation.Core.Entities
{
    public class Address : BaseEntity
    {
        [MaxLength(50)]
        public required string Cep { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Logradouro { get; set; }
        public Donor? Donor { get; set; }
    }
}
