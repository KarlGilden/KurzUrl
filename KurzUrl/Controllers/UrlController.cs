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
        public ActionResult<string> Hello()
        {
            return Ok("KurzUrl");
        }

        [HttpGet("{slug}")]
        public ActionResult<Url> GetUrl(string slug)
        {

            Url url = _UrlService.GetUrl(slug);

            if (url == null)
            {
                return BadRequest("Url not found");
            }

            return Ok(url);
        }


        [HttpPost]
        public async Task<ActionResult<Url>> CreateUrl([FromBody] string originalUrl)
        {
            if (originalUrl == null)
            {
                return BadRequest("Body request not found");
            }

            Url newUrl = await _UrlService.CreateUrl(originalUrl);

            return CreatedAtAction(nameof(GetUrl), new { slug = newUrl.Slug }, newUrl);

        }

/*
        [HttpGet]
        public ActionResult<String> GetOriginalUrl(String slug)
        {
            String OriginalUrl = _UrlService.GetOriginalUrl(slug);
            return Ok(OriginalUrl);
        }*/
    }
}
