using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Formatting.Compact;

namespace Serilog.Samples.DepInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                    .Enrich.FromLogContext()
                    .WriteTo.Console(new RenderedCompactJsonFormatter()));
    }
}
