using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Model
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public string Email { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required]
        public string City { get; set; } = default!;

        [Required]
        public string Country { get; set; } = default!;

        [Required]
        public string CompanyName { get; set; } = default!;

        public string? Role { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
