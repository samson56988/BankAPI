using BankAPI.DAL;
using BankAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<YourBankDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAccountServices, AccountService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My Banking API doc",
                    Version = "v2",
                    Description = "we were crazy enough to build a Bank Api",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name= "Ajayi Samson",
                        Email = "samson@mojec.com",
                        Url = new Uri("https://github.com")
                        
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                var prefix = string.IsNullOrEmpty(x.RoutePrefix) ? "." : "..";
                x.SwaggerEndpoint($"{prefix}/swagger/v2/swagger.json", "My YouTube Banking API doc");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
