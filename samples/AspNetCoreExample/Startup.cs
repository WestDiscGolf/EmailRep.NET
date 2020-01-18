using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailRep.NET;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<EmailRepClientSettings>();
            services.AddHttpClient<IEmailRepClient, EmailRepClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var client = app.ApplicationServices.GetService<IEmailRepClient>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var response = await client.QueryEmailAsync("bill@microsoft.com");

                    await context.Response.WriteAsync(response.Email);
                });
            });
        }
    }
}
