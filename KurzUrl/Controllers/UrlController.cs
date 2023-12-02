using KurzUrl.Models;
using KurzUrl.Services;
using Microsoft.AspNetCore.Mvc;

namespace KurzUrl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _UrlService;

        public UrlController(UrlService UrlService) 
        {
            _UrlService = UrlService;
        }

        [HttpGet]
        public async Task<ActionResult<Url>> GetOriginalLink(String id)
        {
            _UrlService.GetOriginalUrl(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Url>> CreateLink(String OriginalUrl)
        {
            String ShortUrl = _UrlService.ShortenUrl(OriginalUrl);
            _UrlService.CreateUrl(OriginalUrl, ShortUrl);
            return Ok();
        }
    }
}
