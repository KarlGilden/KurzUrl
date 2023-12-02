using KurzUrl.Contexts;
using KurzUrl.Models;

namespace KurzUrl.Services
{
    public class UrlService : IUrlService
    {
        private readonly DataContext _context;

        public UrlService(DataContext context) 
        {
            _context = context;
        }

        public String ShortenUrl(String OriginalUrl)
        {
            return OriginalUrl;
        }

        public Url CreateUrl(String OriginalUrl, String ShortUrl)
        {
            Url LinkObj = new Url
            {
                Clicks = 0,
                OriginalUrl = OriginalUrl,
                ShortUrl = ShortUrl
            };

            return LinkObj;
        }

        public string GetOriginalUrl(String Url)
        {
            throw new NotImplementedException();
        }
    }
}
