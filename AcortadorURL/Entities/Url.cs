using System.ComponentModel.DataAnnotations.Schema;

namespace AcortadorURL.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
