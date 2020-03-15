using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure;
using Application.IServices;
using Application.Services;
using Domain.IRepositories;
using Infastructure.Reposetories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookCrossingBackEnd
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SoftServe BookCrossing", Version = "v1" });
            });
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BookCrossingContext>(options =>
                options.UseSqlServer(
                    connection, x => x.MigrationsAssembly("Infastructure")));
            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IRegistrationService, RegistrationService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SoftServe BookCrossing");
            });
        }
    }
}
