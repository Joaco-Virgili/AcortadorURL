using System.ComponentModel.DataAnnotations.Schema;

namespace AcortadorURL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Url> Urls { get; set; }
    }
}
