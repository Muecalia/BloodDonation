namespace BloodDonation.Application.Commands.Response.Donors
{
    public class InputDonorResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DataOperacao { get; set; } = string.Empty;
    }
}
