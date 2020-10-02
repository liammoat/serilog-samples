# Logging with Microsoft.Extensions.Hosting

## Key aspects

* .NET Core Worker
* Uses ```Serilog.Extensions.Hosting``` to routes framework log messages through Serilog.

## Setup

1. Create ASP.NET Core Web App:

    ```bash
    dotnet new worker --name Serilog.Samples.DepInjection
    ```

2. Add Serilog packages:

    ```bash
    dotnet add package Serilog.Extensions.Hosting
    dotnet add package Serilog.Formatting.Compact
    dotnet add package Serilog.Sinks.Console
    ```

3. Configure web host to ```UseSerilog``` ([reference](./Program.cs#L20-L22)):

    ```bash
    .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.Console(new RenderedCompactJsonFormatter()));
    ```

4. Run the application:

    ```bash
    dotnet run
    ```