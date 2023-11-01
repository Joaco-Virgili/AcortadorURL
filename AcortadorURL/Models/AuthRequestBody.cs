using System.ComponentModel.DataAnnotations;

namespace AcortadorURL.Models
{
    public class AuthRequestBody
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
