using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface IUrlService
    {
        Url GetUrl(string id);
        Task<Url> CreateUrl(string originalUrl);
        Task<string> ShortenUrl(string originalUrl);

    }
}
