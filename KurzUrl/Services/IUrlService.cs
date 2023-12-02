using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface IUrlService
    {
        String GetOriginalUrl(String Url);
        Url CreateUrl(String OriginalUrl, String ShortUrl);
        String ShortenUrl(String OriginalUrl);

    }
}
