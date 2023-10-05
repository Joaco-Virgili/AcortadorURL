using AcortadorURL.Data;
using Microsoft.AspNetCore.Mvc;


namespace AcortadorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlContext _urlContext;
        public UrlController (UrlContext urlContext)
        {
            _urlContext = urlContext;
        }
        
    }
}
