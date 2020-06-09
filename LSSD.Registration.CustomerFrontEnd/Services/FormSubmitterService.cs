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
        private readonly HttpClient _httpClient;

        public FormSubmitterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private APIResponse translateErrorToAPIResponse(string errorText)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1
            // Try deserializing to a ValidationProblemDetails

            try
            {
                ValidationProblemDetails returnedError = JsonSerializer.Deserialize<ValidationProblemDetails>(errorText);
                List<string> errors = new List<string>();

                foreach (var error in returnedError.Errors)
                {
                    foreach(string errorDetail in error.Value)
                    {
                        errors.Add($"{error.Key}: {errorDetail}");
                    }
                }

                return new APIResponse(false, errors);
            }
            catch { }

            // Try deserializing to a SerializableError
            try
            {
                SerializableError returnedError = JsonSerializer.Deserialize<SerializableError>(errorText);
                List<string> errors = new List<string>();

                foreach (var error in returnedError)
                {
                    foreach(var errorDetail in (string[])error.Value)
                    {
                        errors.Add($"{error.Key}: {errorDetail}");
                    }
                }

                return new APIResponse(false, errors);
            }
            catch { }

            // Just send back a generic error

            return new APIResponse(false, new Guid(), "An error occurred while attempting to list the errors. Sorry.");
        }

        public async Task<APIResponse> SubmitForm<T>(string apiRoute, T form)
        {
            StringContent json = new StringContent(JsonSerializer.Serialize<T>(form), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(apiRoute, json);

                // Deserialize the APIRepsonse that we should get back
                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<APIResponse>(jsonResponse);
                    }
                    catch
                    {
                        return new APIResponse(true, new Guid());
                    }                   
                }
                else
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return translateErrorToAPIResponse(jsonResponse);
                }

            } catch(Exception ex)
            {
                return new APIResponse(false, new Guid(), new List<string>() { "An error occurred, preventing your form from being submitted.", ex.Message });
            }
        }

        public async Task<APIResponse> SubmitForm(GeneralRegistrationFormSubmission form)
        {
            return await SubmitForm("General", form);
        }

        public async Task<APIResponse> SubmitForm(PreKRegistrationFormSubmission form)
        {
            return await SubmitForm("PreK", form);
        }

    }
}
