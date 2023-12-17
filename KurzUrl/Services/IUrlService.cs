using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface IUrlService
    {
        Url GetUrl(String Slug);
        Url CreateUrl(String OriginalUrl, String Slug);
        String GetOriginalUrl(String Slug);
        Task<String> ShortenUrl(String OriginalUrl);

    }
}
