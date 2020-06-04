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
        private readonly HttpClient _httpClient;

        public SchoolDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<School>> GetAll()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<School>>(await _httpClient.GetStringAsync("/school/"));
        }


    }
}
