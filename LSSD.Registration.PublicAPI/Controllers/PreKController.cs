using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Forms;
using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LSSD.Registration.PublicAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PreKController : ControllerBase
    {
        IRegistrationRepository<SubmittedPreKApplicationForm> _repository;

        public PreKController(IRegistrationRepository<SubmittedPreKApplicationForm> repository)
        {
            this._repository = repository;
        }

        // GET: api/<PreKController>
        [HttpGet]
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(Examples.PreK, new System.Text.Json.JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    WriteIndented = true
                });
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PreKRegistrationFormSubmission value)
        {
            if (value == null) {
                Console.WriteLine("Body was null!");
                return BadRequest();
            }

            try
            {
                Guid newObjectId = _repository.Insert(
                    new SubmittedPreKApplicationForm(
                        value, 
                        HttpContext.Connection.RemoteIpAddress.ToString()
                        )
                    );

                return Accepted(new APIResponse(true, newObjectId));
            } catch
            {
                return StatusCode(500);
            }

        }

    }
}
