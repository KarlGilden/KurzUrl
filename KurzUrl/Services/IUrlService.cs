using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface IUrlService
    {
        Url GetUrl(String Id);
        Url CreateUrl(String OriginalUrl, String ShortUrl);
        String GetOriginalUrl(String Url);

        String ShortenUrl(String OriginalUrl);

    }
}
