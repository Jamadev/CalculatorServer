using CalculatorService.Server.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace CalculatorService.Server
{
    /// <summary>
    /// This class is the entry point of the application, configures the request 
    /// pipeline which handles all requests made
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Adds services to the container.
        /// </summary>
        /// <param name="services"></param>

        public void ConfigureServices(IServiceCollection services)
        {
            // Dependency injection. It is a singleton in order to keep objects the same
            // during every request after the application is started. 
            // To keep some data without a database. Resets every time the application stops.
            services.AddSingleton<ICalculatorInterface, Services.CalculatorService>();

            // Adds and configures swagger. Tool for documentation.
            services.AddSwaggerGen(c =>
            {
                var infoAplicacion = PlatformServices.Default.Application;
                c.SwaggerDoc(infoAplicacion.ApplicationVersion,
                                      new Info
                                      {
                                          Title = $"{infoAplicacion.ApplicationName}",
                                          Version = infoAplicacion.ApplicationVersion,
                                          Contact = new Contact()
                                          {
                                              Email = "melissaml055@gmail.com",
                                              Name = "Melissa Muñoz"
                                          },
                                          Description = $"{infoAplicacion.ApplicationName} Microservice."
                                      });

                string rutaxml = Path.Combine(infoAplicacion.ApplicationBasePath, $"{infoAplicacion.ApplicationName}.xml");
                c.IncludeXmlComments(rutaxml);
                c.DescribeAllEnumsAsStrings();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        /// <summary>
        /// Defines how the application will respond on each HTTP request
        /// Configures middleware in HTTP pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Obtains information of the application. Used later to configure logging and swagger.
            var infoAplicacion = PlatformServices.Default.Application;

            app.UseMvc();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Uses and configures swagger.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = $"{infoAplicacion.ApplicationName} {infoAplicacion.ApplicationVersion}";
                c.SwaggerEndpoint($"../swagger/{infoAplicacion.ApplicationVersion}/swagger.json", $"{infoAplicacion.ApplicationName}");
                c.RoutePrefix = "documentacion";

                c.DisplayRequestDuration();
            });

            var LogRoute = infoAplicacion.ApplicationBasePath;
            // Logger initialization and configuration. Uses Serilog.
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Debug()
                      .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.RollingFile(Path.Combine(LogRoute, infoAplicacion.ApplicationName, "Logs/Information/log-{Date}.txt"), outputTemplate: "{Message}{NewLine}{Operation}"))
                      .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.RollingFile(Path.Combine(LogRoute, infoAplicacion.ApplicationName, "Logs/Errores/log-{Date}.txt")))
                      .CreateLogger();
        }
    }
}
