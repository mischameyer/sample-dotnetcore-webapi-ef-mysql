using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using sample_dotnetcore_webapi_ef_infrastructure.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using sample_dotnetcore_webapi_ef_services.Dtos;
using sample_dotnetcore_webapi_ef_infrastructure.Entities;
using sample_dotnetcore_webapi_ef_services.Mappings;
using sample_dotnetcore_webapi_ef_infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using sample_dotnetcore_webapi_ef_services.Services;

namespace sample_dotnetcore_webapi_ef
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
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IBookServices, BookServices>();
            
            services.AddDbContext<sample_dotnetcore_webapi_ef_infrastructure.Repository.DbContext>(o => o.UseMySql(Configuration.GetConnectionString("MySQL")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });            

            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ".NET Core WebApi with Entity Framework Core (to MySQL)", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (errorFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500, errorFeature.Error, errorFeature.Error.Message);
                        }

                        await context.Response.WriteAsync("There was an error");
                    });
                });
            }            

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });           
        }
    }
}
