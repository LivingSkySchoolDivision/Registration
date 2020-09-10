using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.Extensions.Configuration;

namespace LSSD.Registration.AdminFrontend.Services
{
    public class PreKRegistrationFormDataService
    {
        IRegistrationRepository<SubmittedPreKApplicationForm> _repository;

        public PreKRegistrationFormDataService(IRegistrationRepository<SubmittedPreKApplicationForm> repository)
        {
            _repository = repository;
        }

        public List<SubmittedPreKApplicationForm> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public SubmittedPreKApplicationForm Get(string id)
        {
            return _repository.GetById(id);
        }

    }

}