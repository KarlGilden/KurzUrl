using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface IUrlService
    {
        Url GetUrl(String Slug);
        Url CreateUrl(String OriginalUrl, String Slug);
        String GetOriginalUrl(String Slug);

        String ShortenUrl(String OriginalUrl);

    }
}
