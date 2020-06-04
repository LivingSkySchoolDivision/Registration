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

namespace LSSD.Registration.CustomerFrontEnd
{
    public class Startup
    {
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

            // Default to what's in Properties/launchSettings.json for the API project.
            string apiURI = settingsSection["APIURI"] ?? "https://localhost:4001"; 

            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Add an HttpClient that we can use
            services.AddScoped<HttpClient>(s =>
            {
                var client = new HttpClient { BaseAddress = new System.Uri(apiURI) };
                return client;
            });

            services.AddScoped<FormStepTrackerService>();
            services.AddScoped<SchoolDataService>();
            services.AddScoped<BrowserStorageService>();

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
