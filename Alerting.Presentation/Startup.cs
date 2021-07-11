using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerting.Application.Interface;
using Alerting.Application.Services;
using Alerting.DomainModel.Interfaces;
using Alerting.Infrastructure.Notifications;
using Alerting.Infrastructure.Repositories;
using Alerting.Presentation.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; 

namespace Alerting.Presentation
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

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(
            //        name: "AllowOrigin",
            //        builder => {
            //            //builder.WithOrigins("http://elk-alerting.nsedna.com/")
            //            //       .WithOrigins("http://elk-alerting.nsedna.com/api/Alert/NotificationError").AllowAnyMethod().AllowAnyHeader();

            //            //builder.AllowAnyOrigin()
            //            //        .AllowAnyMethod()
            //            //        .AllowAnyHeader();


            //        });
            //});


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(options =>
                {
                    options
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();

            services.AddScoped<IUserQuery, UserService>();
            services.AddScoped<IUserCommand, UserService>();

            services.AddScoped<INotification, Notification>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IApplicationCommand, ApplicationService>();
            services.AddScoped<IApplicationQuery, ApplicationService>();

            services.AddControllers();
            services.AddCustomizedDbContext(Configuration);

            //services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseSwagger();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            
            //});
            //app.UseSwagger(options =>
            //{
            //    options.PreSerializeFilters.Add((swagger, httpReq) =>
            //    {
            //        swagger.Servers.Clear();
            //    });
            //});


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
