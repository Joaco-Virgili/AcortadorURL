using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Helpers;
using AcortadorURL.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AcortadorURL.Services
{
    // IUrlService.cs
    public interface IUrlService
    {
        string Add(UrlForCreation url, int userId);
        Url GetUrlByShortCode(string shortCode);
    }

    // UrlService.cs
    public class UrlService : IUrlService
    {
        private readonly UrlContext _urlContext;
        private readonly UrlHelper _urlHelper;

        public UrlService(UrlContext urlContext, UrlHelper urlHelper)
        {
            _urlContext = urlContext;
            _urlHelper = urlHelper;
        }

        public string Add(UrlForCreation url, int userId)
        {

            Url newUrl = new Url()
            {
                LongUrl = url.LongUrl,
                ShortUrl = _urlHelper.GenerateRandomChars(6),
                UserId = userId
            };
            _urlContext.Urls.Add(newUrl);
            _urlContext.SaveChanges();
            return newUrl.ShortUrl;
        }

        public Url GetUrlByShortCode(string shortCode)
        {
            var url = _urlContext.Urls.SingleOrDefault(url => url.ShortUrl == shortCode);
            if (url == null)
            {
                return new Url { LongUrl = null, ShortUrl = null };
            }
            return url;
        }
    }

}
