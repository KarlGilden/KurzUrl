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
        public async Task<ActionResult<Url>> GetUrl(String Slug)
        {
            _UrlService.GetUrl(Slug); 
            return Ok();
        }


        [HttpPost]
        [Route("[controller]/CreateUrl")]
        public async Task<ActionResult<Url>> CreateUrl(String OriginalUrl)
        {
            String Slug = _UrlService.ShortenUrl(OriginalUrl);
            Url newUrl = _UrlService.CreateUrl(OriginalUrl, Slug);

            return CreatedAtAction(nameof(GetUrl), new { slug = newUrl.Slug }, newUrl);

        }


        [HttpGet]
        [Route("[controller]/GetOriginalUrl")]
        public async Task<ActionResult<Url>> GetOriginalUrl(String Slug)
        {
            String OriginalUrl = _UrlService.GetOriginalUrl(Slug);
            return Ok(OriginalUrl);
        }
    }
}
