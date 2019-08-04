using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RepositoryContract;
using Entities;
using LoggerContracts;
using LoggerService;
using System.IO;
using System;

namespace ApplicationDevelopment.Extensions
{
    /// <summary>
    /// ServiceExtensions
    /// </summary>
    /// <remarks>This is Service Extensions class for configuring services.</remarks>
    public static class ServiceExtensions
    {
        /// <summary>
        /// ConfigureCors
        /// </summary>
        /// <remarks>The method configuring cors.</remarks>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        /// <summary>
        /// ConfigureIISIntegration
        /// </summary>
        /// <remarks>The method configuring IIS Integration.</remarks>
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        /// <summary>
        /// ConfigureLoggerService
        /// </summary>
        /// <remarks>The method configuring Loggern.</remarks>
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        /// <summary>
        /// ConfigureMongoDbService
        /// </summary>
        /// <remarks>The method configuring MongoDb.</remarks>
        public static void ConfigureMongoDbService(this IServiceCollection services, IConfiguration Configuration)
        {

           // string connectionString = Configuration["MongoConnectionString"];
           // string MongoDatabase = Configuration["MongoDatabase"];

            services.Configure<Settings>(options =>
            {
                options.ConnectionString = Configuration["ConnectionString"];
                options.Database = Configuration["Database"];
            });

            //services.Configure<Settings>(options =>
            //{
            //    options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
            //    options.Database = Configuration.GetSection("MongoDb:Database").Value;
            //});
        }
        /// <summary>
        /// ConfigureRepository
        /// </summary>
        /// <remarks>The method configuring Repository.</remarks>
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddTransient<AppDbContext, AppDbContext>();
            services.AddTransient<IInfoRepository, InfoRepository>();
        }
        /// <summary>
        /// ConfiguredSwagger
        /// </summary>
        /// <remarks>The method configuring Swagger.</remarks>
        public static void ConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1.0", info: new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "bit8server",
                    Version = "1.0.0"
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "bit8server.xml"));
            });
        }
    }
}
