using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LSSD.Registration.Data;
using LSSD.Registration.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LSSD.Registration.PublicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly IRegistrationRepository<School> _repository;

        public SchoolController(IRegistrationRepository<School> SchoolRepository)
        {
            this._repository = SchoolRepository;
        }

        [HttpGet]
        public IEnumerable<School> Get()
        {
            return _repository.GetAll();
        }

        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            if (InputValidators.IsValidGUID(guid))
            {
                try
                {
                    School school = _repository.GetById(guid);
                    if (school != null)
                    {
                        return Ok(school);
                    }
                    else
                    {
                        return NotFound(new { HttpStatusCode = 404, ErrorMsg = "Not found" });
                    }
                }
                catch
                {
                    return BadRequest(new { HttpStatusCode = 400, ErrorMsg = "Bad Request" });
                }
            } else
            {
                return BadRequest(new { HttpStatusCode = 400, ErrorMsg = "Bad Request" });
            }
        }
    }
}
