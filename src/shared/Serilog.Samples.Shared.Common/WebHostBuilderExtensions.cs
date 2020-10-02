using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Hosting;
using Serilog.Formatting.Compact;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;

namespace Serilog.Samples.Shared.Common
{
    public static class WebHostBuilderExtensions
    {
        public static IHostBuilder UseCustomLogging(this IHostBuilder builder) => 
            builder.UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
                    .Enrich.FromLogContext()
                    .WriteTo.ApplicationInsights(new TelemetryClient(new TelemetryConfiguration("<ikey>")), new TraceTelemetryConverter())
                    .WriteTo.File(new CompactJsonFormatter(), "logs\\myapp.json", rollingInterval: RollingInterval.Day)
                    .WriteTo.Console());
    }
}
