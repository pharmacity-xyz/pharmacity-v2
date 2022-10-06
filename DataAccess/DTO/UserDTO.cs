namespace DataAccess.DTO
{
    public class UserDTO
    {
        public Guid? UserId { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
