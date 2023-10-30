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
             // Cambia 6 por la longitud deseada
            
            var url = new Url
            {
                LongUrl = urlForCreation.LongUrl,
                ShortUrl = GenerateRandomChars(6)
        };

            _urlContext.Urls.Add(url);
            _urlContext.SaveChanges();
            // Guardar la relación entre la URL corta y la URL larga (en la base de datos o en memoria)

            return Ok(url);
        }

        private string GenerateRandomChars(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet("{code}")]
        public IActionResult RedirectUrl(string code)
        {
            string url = _urlContext.Urls.SingleOrDefault(url => url.ShortUrl == code).LongUrl;
            return url == null ? NotFound() : Redirect(url);
        }
    }
}