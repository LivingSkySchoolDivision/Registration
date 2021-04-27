using LSSD.Registration.Model;
using LSSD.Registration.Model.Forms;
using LSSD.Registration.Model.SubmittedForms;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace LSSD.Registration.CustomerFrontEnd.Services
{
    public class FormSubmitterService
    {
        private readonly IRegistrationRepository<SubmittedGeneralRegistrationForm> k12Repository;
        private readonly IRegistrationRepository<SubmittedPreKApplicationForm> preKRepository;

        public FormSubmitterService(IRegistrationRepository<SubmittedGeneralRegistrationForm> k12repo, IRegistrationRepository<SubmittedPreKApplicationForm> prekrepo)
        {
            k12Repository = k12repo;
            preKRepository = prekrepo;
        }

        public APIResponse SubmitForm(GeneralRegistrationFormSubmission form) 
        {
            try {
                Guid newObjectId = k12Repository.Insert(
                        new SubmittedGeneralRegistrationForm(form)
                        );
                return new APIResponse(true, newObjectId);
            }
            catch(Exception ex) 
            {
                return new APIResponse(false, new List<string>() {"Exception occurred when submitting form: " + ex.Message} );
            }
        }
        public APIResponse SubmitForm(PreKRegistrationFormSubmission form) 
        {
            try {
                Guid newObjectId = preKRepository.Insert(
                        new SubmittedPreKApplicationForm(form)
                        );
                return new APIResponse(true, newObjectId);
            }
            catch(Exception ex) 
            {
                return new APIResponse(false, new List<string>() {"Exception occurred when submitting form: " + ex.Message} );
            }
        }



    }
}
