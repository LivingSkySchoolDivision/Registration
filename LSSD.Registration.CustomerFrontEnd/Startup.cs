using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LSSD.Registration.CustomerFrontEnd.Services;
using Blazored.LocalStorage;
using System.Net.Http;
using LSSD.Registration.Data;
using LSSD.Registration.Model;
using LSSD.Registration.Model.SubmittedForms;

namespace LSSD.Registration.CustomerFrontEnd
{
    public class Startup
    {
        private bool HostedInContainer => Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationSection settingsSection = Configuration.GetSection("Settings");
            
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<MongoDbConnection>();
            services.AddScoped<IRegistrationRepository<School>, MongoRepository<School>>();
            services.AddScoped<IRegistrationRepository<SubmittedGeneralRegistrationForm>, MongoRepository<SubmittedGeneralRegistrationForm>>();
            services.AddScoped<IRegistrationRepository<SubmittedPreKApplicationForm>, MongoRepository<SubmittedPreKApplicationForm>>();

            services.AddScoped<FormStepTrackerService>();
            services.AddScoped<SchoolDataService>();
            services.AddScoped<BrowserStorageService>();
            services.AddScoped<FormSubmitterService>();

            // Local Storage
            services.AddBlazoredLocalStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (HostedInContainer)
            {
                Console.WriteLine("We appear to be running in a container");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
