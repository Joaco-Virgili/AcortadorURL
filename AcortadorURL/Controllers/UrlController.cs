using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using AcortadorURL.Helpers;
using AcortadorURL.Services;
using System.Security.Claims;

namespace AcortadorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost]
        public IActionResult Shorten([FromBody] UrlForCreation url)
        {
            int userId = Int32.Parse(User.Claims.First(claim => claim.Type.Contains("nameidentifier")).Value);
            return Ok(_urlService.Add(url, userId));
        }

        [HttpGet("{code}")]
        public IActionResult RedirectUrl(string code)
        {
            var urlEntry = _urlService.GetUrlByShortCode(code);

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