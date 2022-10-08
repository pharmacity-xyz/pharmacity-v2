namespace DataAccess.DTO
{
    public class UserDTO
    {
        public Guid? UserId { get; set; }

        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string City { get; set; } = default!;

        public string Country { get; set; } = default!;

        public string CompanyName { get; set; } = default!;

        public string? Role { get; set; }
    }
}
