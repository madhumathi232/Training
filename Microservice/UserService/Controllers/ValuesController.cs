using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet (Name ="GetData")]
        public string GetDataValues()
        {
            return DateTime.Now.ToString() ;
        }
       
    }
}
