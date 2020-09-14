using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.Extensions.Configuration;

namespace LSSD.Registration.AdminFrontend.Services
{
    public class GeneralRegistrationFormDataService
    {
        IRegistrationRepository<SubmittedGeneralRegistrationForm> _repository;

        public GeneralRegistrationFormDataService(IRegistrationRepository<SubmittedGeneralRegistrationForm> repository)
        {
            _repository = repository;
        }

        public List<SubmittedGeneralRegistrationForm> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public SubmittedGeneralRegistrationForm Get(string id)
        {
            return _repository.GetById(id);
        }

    }

}