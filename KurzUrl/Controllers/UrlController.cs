using KurzUrl.Models;
using KurzUrl.Services;
using Microsoft.AspNetCore.Mvc;

namespace KurzUrl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _UrlService;

        public UrlController(IUrlService UrlService) 
        {
            _UrlService = UrlService;
        }

        [HttpGet]
        [Route("[controller]/GetUrl")]
        public async Task<ActionResult<Url>> GetUrl(String id)
        {
            _UrlService.GetUrl(id);
            return Ok();
        }


        [HttpPost]
        [Route("[controller]/CreateUrl")]
        public async Task<ActionResult<Url>> CreateUrl(String OriginalUrl)
        {
            String ShortUrl = _UrlService.ShortenUrl(OriginalUrl);
            Url newUrl = _UrlService.CreateUrl(OriginalUrl, ShortUrl);

            return CreatedAtAction(nameof(GetUrl), new { id = newUrl.Id }, newUrl);

        }


        [HttpGet]
        [Route("[controller]/GetOriginalUrl")]
        public async Task<ActionResult<Url>> GetOriginalUrl(String id)
        {
            _UrlService.GetOriginalUrl(id);
            return Ok();
        }
    }
}
