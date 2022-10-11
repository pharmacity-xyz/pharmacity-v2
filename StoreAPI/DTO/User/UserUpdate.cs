using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO
{
    public class UserUpdate
    {
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
    }
}