# Shared common library*

## Key aspects

* .NET Core class library for common configuration
* Multiple ASP.NET Core Web Apps to consume common class library

## Setup

1. Create a class library and implmement an extension method for ```IHostBuilder``` ([reference](./Serilog.Samples.Shared.Common/WebHostBuilderExtensions.cs#L11-L16)).

    ```c#
    public static IHostBuilder UseCustomLogging(this IHostBuilder builder) => 
        builder.UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
            .Enrich.FromLogContext()
            .WriteTo.ApplicationInsights(new TelemetryClient(new TelemetryConfiguration("<ikey>")), new TraceTelemetryConverter())
            .WriteTo.File(new CompactJsonFormatter(), "logs\\myapp.json", rollingInterval: RollingInterval.Day)
            .WriteTo.Console());
    ```

2. Reference the above library from other .NET projects.

    ```bash
    dotnet add reference <path-to-project>
    ```

3. Configure web host to ```UseCustomLogging``` ([reference](./Serilog.Samples.Shared.WebApp1/Program.cs#L20)):

    ```c#
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseCustomLogging();
    ```

4. Run the application:

    ```bash
    dotnet run
    ```

\* This is a sample and not necessary an endorsed approach.