using LSSD.Registration.Model;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LSSD.Registration.CustomerFrontEnd.Services
{
    public class SchoolDataService
    {
        private readonly IRegistrationRepository<School> _repository;


        public SchoolDataService(IRegistrationRepository<School> SchoolRepository)
        {
            this._repository = SchoolRepository;
        }

        public IEnumerable<School> GetAll()
        {
            return _repository.GetAll().Where(s => s.IsAvailableForRegistration == true);
        }


    }
}
