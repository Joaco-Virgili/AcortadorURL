using AcortadorURL.Entities;
using AcortadorURL.Models;
using AcortadorURL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcortadorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult CreateUser(UserForCreation user)
        {
            try
            {
                _userServices.Create(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUrlByUser()
        {
            int userId = Int32.Parse(User.Claims.First(claim => claim.Type.Contains("nameidentifier")).Value);
            List<Url> urls = _userServices.GetUrls(userId);
            return Ok(urls);
        }
    }
}
