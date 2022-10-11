using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
