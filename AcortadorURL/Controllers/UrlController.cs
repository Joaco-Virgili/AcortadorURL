using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using AcortadorURL.Helpers;


namespace AcortadorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlContext _urlContext;
        private readonly UrlHelper _urlHelper;
        public UrlController(UrlContext urlContext, UrlHelper urlHelper)
        {
            _urlContext = urlContext;
            _urlHelper = urlHelper;
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
                ShortUrl = _urlHelper.GenerateRandomChars(6)
            };

            _urlContext.Urls.Add(url);
            _urlContext.SaveChanges();

            return Ok(url);
        }


        [HttpGet("{code}")]
        public IActionResult RedirectUrl(string code)
        {
            var urlEntry = _urlContext.Urls?.SingleOrDefault(url => url.ShortUrl == code);

            if (urlEntry != null && urlEntry.LongUrl != null)
            {
                string url = urlEntry.LongUrl;
                return Redirect(url);
            }
            else
            {
                return NotFound();
            }
        }
    }
}