using KurzUrl.Contexts;
using KurzUrl.Models;
using Microsoft.AspNetCore.Mvc;

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
            Url UrlObj = new Url
            {
                Id = Guid.NewGuid().ToString(),
                Clicks = 0,
                OriginalUrl = OriginalUrl,
                ShortUrl = ShortUrl
            };

            _context.Urls.Add(UrlObj);

            _context.SaveChanges();

            return UrlObj;
        }
        
        public String GetOriginalUrl(String ShortUrl)
        {
            String OriginalUrl = _context.Urls.First(u => u.ShortUrl == ShortUrl).OriginalUrl;
            return OriginalUrl;
        }

        public Url GetUrl(String Id)
        {
            Url url = _context.Urls.First(u => u.Id == Id);
            return url;
        }
    }
}
