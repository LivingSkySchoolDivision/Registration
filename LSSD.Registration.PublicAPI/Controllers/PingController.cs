using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Forms;
using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.AspNetCore.Mvc;

namespace LSSD.Registration.PublicAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {

        // GET: api/<GeneralController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(new { ping = "pong" }, new System.Text.Json.JsonSerializerOptions()
                {
                    IgnoreNullValues = false,
                    WriteIndented = true
                });
        }



    }
}
