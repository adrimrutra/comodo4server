using ApplicationDevelopment.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NLog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace ApplicationDevelopment
{
    /// <summary>
    /// class Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup(IConfiguration configuration)
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        /// <summary>
        /// ConfigureServices(IServiceCollection services)
        /// </summary>
        /// <remarks>This method gets called by the runtime. Use this method to add services to the container.</remarks>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureServices(IServiceCollection services)
        /// </summary>
        /// <remarks>This method gets called by the runtime. Use this method to add services to the container.</remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureMongoDbService(Configuration);

            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration["ConnectionString"]));

            services.ConfigureRepository();
            services.ConfigureLoggerService();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfiguredSwagger();
        }


        /// <summary>
        /// Configure(IApplicationBuilder app, IHostingEnvironment env)
        /// </summary>
        /// <remarks>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.</remarks>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseStaticFiles();

            

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "ApplicationDevelopment");
            });
            app.UseMvc();
        }
    }
}
