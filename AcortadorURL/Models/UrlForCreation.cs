using AcortadorURL.Entities;

namespace AcortadorURL.Models
{
    public class UrlForCreation
    {
        public string LongUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public User? User;
    }
}
