using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcortadorURL.Entities
{
    public class Url
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public int CountClicks { get; set; }
        public string Category { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
