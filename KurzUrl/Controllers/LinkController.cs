using KurzUrl.Models;
using KurzUrl.Services;
using Microsoft.AspNetCore.Mvc;

namespace KurzUrl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly LinkService _LinkService;

        public LinkController(LinkService LinkService) 
        {
            _LinkService = LinkService;
        }

        [HttpGet]
        public async Task<ActionResult<ShortLink>> GetOriginalLink(String id)
        {
            _LinkService.GetOriginalLink(id);
            return Ok();
        }
    }
}
