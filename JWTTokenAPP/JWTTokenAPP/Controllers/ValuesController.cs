using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTTokenAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string GetToken()
        {
            string bodyContent = new StreamReader(Request.Body).ReadToEnd();
            return DateTime.Now.ToString();
        }
    }
}
