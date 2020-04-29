using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LSSD.Registration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("DERP");
        }
    }
}