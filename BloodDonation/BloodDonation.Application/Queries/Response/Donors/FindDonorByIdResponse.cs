namespace BloodDonation.Application.Queries.Response.Donors
{
    public class FindDonorByIdResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
        public char Gender { get; set; } = 'F';
        public string FactorRh { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public double Weight { get; set; } = 2f;
        public FindAddressResponse Address { get; set; }
        //public List<FindDonationsResponse> Donations { get; set; } = [];
    }
}
