using Microsoft.AspNetCore.Mvc;

namespace WebAPIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        public string GetToken()
        {

            return DateTime.Now.ToString();
        }
    }
}
