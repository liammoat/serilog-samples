# ASP.NET Core Web App

## Key aspects

* ASP.NET Core Web App
* Uses ```Serilog.AspNetCore``` to get information about ASP.NET's internal operations written to the same Serilog sinks as your application events.
* Uses ```Serilog.Sinks.ApplicationInsights``` to write events to Microsoft Application Insights.

## Setup

1. Create ASP.NET Core Web App:

    ```bash
    dotnet new webapp --name Serilog.Samples.WebApp
    ```

2. Add Serilog packages:

    ```bash
    dotnet add package Serilog.AspNetCore
    dotnet add package Serilog.Sinks.ApplicationInsights
    ```

3. Configure web host to ```UseSerilog``` ([reference](./Program.cs#L29-L33)):

    ```c#
    .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.File(new CompactJsonFormatter(), "logs\\myapp.json", rollingInterval: RollingInterval.Day)
        .WriteTo.Console()
        .WriteTo.ApplicationInsights(new TelemetryClient(new TelemetryConfiguration("<ikey>")), new TraceTelemetryConverter()));
    ```

4. Create some log output messages ([reference](./Pages/Index.cshtml.cs#L22-L39)).

5. Run the application:

    ```bash
    dotnet run
    ```