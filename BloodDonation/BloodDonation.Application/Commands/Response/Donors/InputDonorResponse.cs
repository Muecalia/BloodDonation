namespace BloodDonation.Application.Commands.Response.Donors
{
    public class InputDonorResponse(int id, string name, string email, string phone)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        //public string DataOperacao { get; set; } = string.Empty;
    }
}
