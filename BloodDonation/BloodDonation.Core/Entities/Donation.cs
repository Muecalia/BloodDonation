namespace BloodDonation.Core.Entities
{
    public class Donation : BaseEntity
    {
        public required int QtdMl { get; set; }
        public required int IdDonor { get; set; }
        public required Donor Donor { get; set; }
        public required int IdEmployee { get; set; }
        public required Employee Employee { get; set; }
    }
}
