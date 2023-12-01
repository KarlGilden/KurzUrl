using KurzUrl.Models;

namespace KurzUrl.Services
{
    public interface ILinkService
    {
        String GetOriginalLink(String url);
        ShortLink CreateLink(String url);

    }
}
