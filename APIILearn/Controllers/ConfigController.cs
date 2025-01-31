using Microsoft.AspNetCore.Mvc;

namespace APIILearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        private readonly IConfiguration conf;
        public ConfigController(IConfiguration _conf)
        {
            conf = _conf;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetConf() 
        {
            var config = new
            {
                AllowedHost = conf["AllowedHosts"]

            };

            return Ok(config);
        }
    }
}
