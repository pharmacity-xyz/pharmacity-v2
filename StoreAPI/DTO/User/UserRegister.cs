using System.ComponentModel.DataAnnotations;

namespace StoreAPI.DTO.User
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

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