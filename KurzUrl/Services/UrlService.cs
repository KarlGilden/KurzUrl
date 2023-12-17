using KurzUrl.Contexts;
using KurzUrl.Models;
using Microsoft.EntityFrameworkCore;

namespace KurzUrl.Services
{
    public class UrlService : IUrlService
    {
        private readonly DataContext _context;

        public UrlService(DataContext context) 
        {
            _context = context;
        }

        public async Task<String> ShortenUrl(String OriginalUrl)
        {
            const int NumberOfChars = 7;
            const String Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random _random = new Random();

            var codeChars = new char[NumberOfChars];

            while(true)
            {
                for (var i = 0; i < NumberOfChars; i++)
                {
                    var randomIndex = _random.Next(Chars.Length - 1);
                    codeChars[i] = Chars[randomIndex];
                }

                var code = new string(codeChars);

                if (!await _context.Urls.AnyAsync(s => s.Slug == code))
                {
                    return code;
                }
            }
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
