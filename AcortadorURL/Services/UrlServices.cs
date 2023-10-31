using AcortadorURL.Data;
using AcortadorURL.Entities;

namespace AcortadorURL.Services
{
    public class UrlServices
    {
        private readonly UrlContext _urlContext;
        public UrlServices(UrlContext context)
        {
            _urlContext = context;
        }

        public void Create(Url url)
        {
            _urlContext.Urls.Add(url);
            _urlContext.SaveChanges();
        }
    }
}
