using CaseStudy.Api.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetToken()
        {
            return Ok(new CreateToken().TokenCreateUser());
        }
    }
}
