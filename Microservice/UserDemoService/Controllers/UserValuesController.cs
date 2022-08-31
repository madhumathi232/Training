using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserDemoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserValuesController : ControllerBase
    {
        [HttpGet(Name ="GetUserDatas")]
        public string GetUserData()
        {
            return "Hii Madhu";
        }
    }
}
