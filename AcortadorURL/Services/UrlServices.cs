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
        Url? GetById(int id);
        string Add(UrlForCreation url, int userId);
        Url GetUrlByShortCode(string shortCode);
        bool UpdateClicks(int id);
        List<Url> GetUrls(int userId);
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

        public Url? GetById(int id)
        {
            return _urlContext.Urls.SingleOrDefault(url => url.Id == id);
        }

        public string Add(UrlForCreation url, int userId)
        {

            Url newUrl = new Url()
            {
                LongUrl = url.LongUrl,
                ShortUrl = _urlHelper.GenerateRandomChars(6),
                Category = url.Category,
                UserId = userId
            };
            _urlContext.Urls.Add(newUrl);
            _urlContext.SaveChanges();
            return newUrl.ShortUrl;
        }

        public bool UpdateClicks(int id)
        {
            Url? urlToUpd = GetById(id);
            if (urlToUpd == null) 
                return false;
            urlToUpd.CountClicks++;
            _urlContext.Urls.Update(urlToUpd);
            _urlContext.SaveChanges();
            return true;
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

        public List<Url> GetUrls(int userId)
        {
            return _urlContext.Urls.Where(url => url.UserId == userId).ToList();
        }
    }

}
