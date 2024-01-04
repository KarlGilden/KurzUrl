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

        public async Task<string> ShortenUrl(string OriginalUrl)
        {
            const int NumberOfChars = 7;
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
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

        public async Task<Url> CreateUrl(string originalUrl)
        {
            string slug = await ShortenUrl(originalUrl);

            Url UrlObj = new()
            {
                Slug = slug,
                Clicks = 0,
                OriginalUrl = originalUrl
            };

            _context.Urls.Add(UrlObj);

            _context.SaveChanges();

            return UrlObj;
        }
        
        public Url GetUrl(string Slug)
        {
            try
            {
                Url url = _context.Urls.First(u => u.Slug == Slug);

                return url;
            }
            catch
            {
                return null;
            }

        }
    }
}
