namespace BloodDonation.Application.Queries.Response.Users
{
    public class FindAllUsersResponse(int id, string name, string email, string phone, string role)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public string Phone { get; set; } = phone;
        public string Role { get; set; } = role;
    }
}
