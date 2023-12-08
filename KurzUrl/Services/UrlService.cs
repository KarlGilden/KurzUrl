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
            return Guid.NewGuid().ToString();
        }

        public Url CreateUrl(String OriginalUrl, String Slug)
        {
            Url UrlObj = new Url
            {
                Slug = Slug,
                Clicks = 0,
                OriginalUrl = OriginalUrl
            };

            _context.Urls.Add(UrlObj);

            _context.SaveChanges();

            return UrlObj;
        }
        
        public String GetOriginalUrl(String Slug)
        {
            String OriginalUrl = _context.Urls.First(u => u.Slug == Slug).OriginalUrl;
            return OriginalUrl;
        }

        public Url GetUrl(String Slug)
        {
            Url url = _context.Urls.First(u => u.Slug == Slug);
            return url;
        }
    }
}
