using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;


namespace AcortadorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlContext _urlContext;
        public UrlController(UrlContext urlContext)
        {
            _urlContext = urlContext;
        }

        [HttpPost]
        public IActionResult ShortenUrl([FromBody] UrlForCreation urlForCreation)
        {
            var existingMapping = _urlContext.Urls.FirstOrDefault(m => m.LongUrl == urlForCreation.LongUrl);

            if (existingMapping != null)
            {
                return Ok(new Url { Id = existingMapping.Id, LongUrl = urlForCreation.LongUrl, ShortUrl = existingMapping.ShortUrl });
            }

            // Validar la URL larga aquí si es necesario

            string randomChars = GenerateRandomChars(6); // Cambia 6 por la longitud deseada
            string shortUrl = $"https://localhost:4200/{randomChars}";
            var url = new Url
            {
                LongUrl = urlForCreation.LongUrl,
                ShortUrl = shortUrl
            };

            _urlContext.Urls.Add(url);
            _urlContext.SaveChanges();
            // Guardar la relación entre la URL corta y la URL larga (en la base de datos o en memoria)

            return Ok(new Url { Id = url.Id, LongUrl = urlForCreation.LongUrl, ShortUrl = shortUrl });
        }

        private string GenerateRandomChars(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}