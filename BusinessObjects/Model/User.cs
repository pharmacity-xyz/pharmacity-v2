using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
