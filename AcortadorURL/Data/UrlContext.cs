using System.Collections.Generic;
using AcortadorURL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcortadorURL.Data
{
    public class UrlContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Url>Urls { get; set; }
        
        public UrlContext(DbContextOptions<UrlContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User pepe = new User()
            {
                Id = 1,
                Email = "pepe@email.com",
                Password = "pepe"
            };

            User joaco = new User()
            {
                Id = 2,
                Email = "joaco@email.com",
                Password = "Joaco"
            };

            Url url = new Url()
            {
                Id = 1,
                LongUrl = "https://google.com",
                ShortUrl = "ad3Er5",
                CountClicks = 1,
                Category = "Buscador",
                UserId = pepe.Id
            };

            Url url2 = new Url()
            {
                Id = 2,
                LongUrl = "https://youtube.com",
                ShortUrl = "Lo25Te",
                CountClicks = 5,
                Category = "Entretenimiento",
                UserId = joaco.Id
            };

            modelBuilder.Entity<User>()
                .HasData(pepe, joaco);

            modelBuilder.Entity<Url>()
                .HasData(url, url2);

            modelBuilder.Entity<User>()
                .HasMany<Url>(u => u.Urls)
                .WithOne(url => url.User);
        }
    }
}