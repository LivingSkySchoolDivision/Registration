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
    public class GeneralController : ControllerBase
    {
        IRegistrationRepository<SubmittedGeneralRegistrationForm> _repository;

        public GeneralController(IRegistrationRepository<SubmittedGeneralRegistrationForm> repository)
        {
            this._repository = repository;
        }

        // GET: api/<GeneralController>
        [HttpGet]
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(Examples.General, new System.Text.Json.JsonSerializerOptions()
                {
                    IgnoreNullValues = false,
                    WriteIndented = true
                });
            }
            catch
            {
                return StatusCode(500);
            }
        }


        // POST api/<GeneralController>
        [HttpPost]
        public IActionResult Post([FromBody] GeneralRegistrationFormSubmission value, string ignored)
        {
            if (value == null)
                return BadRequest();

            try
            {
                Guid newObjectId = _repository.Insert(
                    new SubmittedGeneralRegistrationForm(value)
                    );

                return Accepted(new APIResponse(true, newObjectId));
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
