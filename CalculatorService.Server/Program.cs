using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CalculatorService.Server
{
    /// <summary>
    /// This class is the entry point of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Implementation of host configuration
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Host configuration
        /// </summary>
        /// <param name="args">argumentos</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>();
    }
}
