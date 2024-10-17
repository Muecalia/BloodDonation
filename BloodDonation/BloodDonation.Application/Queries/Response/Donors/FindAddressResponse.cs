namespace BloodDonation.Application.Queries.Response.Donors
{
    public class FindAddressResponse
    {
        public int Id { get; set; } = 0;
        public string Cep { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
    }
}
