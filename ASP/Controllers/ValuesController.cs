using ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //[HttpGet("Values/Get")]
        public Tenant[] Get()
        {
            return new Tenant[]
    {
        new Tenant
        {
            Id = 1,
            Name = "Glenn Block"
        },
        new Tenant
        {
            Id = 2,
            Name = "Dan Roth"
        }
    };
        }
    }
}
