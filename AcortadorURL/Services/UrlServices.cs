using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Helpers;

namespace AcortadorURL.Services
{
    // IUrlService.cs
    public interface IUrlService
    {
        Url ShortenUrl(string longUrl);
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

        public Url ShortenUrl(string longUrl)
        {
            var existingMapping = _urlContext.Urls.FirstOrDefault(m => m.LongUrl == longUrl);

            if (existingMapping != null)
            {
                return new Url { Id = existingMapping.Id, LongUrl = longUrl, ShortUrl = existingMapping.ShortUrl };
            }

            var url = new Url
            {
                LongUrl = longUrl,
                ShortUrl = _urlHelper.GenerateRandomChars(6)
            };

            _urlContext.Urls.Add(url);
            _urlContext.SaveChanges();

            return url;
        }

        public Url GetUrlByShortCode(string shortCode)
        {
            var url = _urlContext.Urls.SingleOrDefault(url => url.ShortUrl == shortCode);
            if (url == null)
            {
                return new Url { LongUrl = null, ShortUrl = null};
            }
            return url;
        }
    }

}
