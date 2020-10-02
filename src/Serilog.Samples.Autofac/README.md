# Logging with Autofac

## Key aspects

* ASP.NET Core Web App
* Uses ```Autofac.Extensions.DependencyInjection``` for dependency injection.
* Uses ```Serilog.AspNetCore``` to get information about ASP.NET's internal operations written to the same Serilog sinks as your application events.

## Setup

1. Create ASP.NET Core Web App:

    ```bash
    dotnet new webapp --name Serilog.Samples.Autofac
    ```

2. Add Serilog packages:

    ```bash
    dotnet add package Serilog.AspNetCore
    dotnet add package Autofac.Extensions.DependencyInjection
    ```

3. Configure web host to ```UseServiceProviderFactory``` ([reference](./Program.cs#L16)):

4. Configure web host to ```UseSerilog``` ([reference](./Program.cs#L21-L23)):

    ```c#
    .UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.Console());
    ```

5. Call ```ConfigureContainer``` to configure Autofac ([reference](./Startup.cs#L33-L39)):

    ```c#
    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Register your own things directly with Autofac here. Don't
        // call builder.Populate(), that happens in AutofacServiceProviderFactory
        // for you.
        builder.RegisterType<GreetingsService>().As<IGreetingsService>();
    }
    ```

6. Create some log output messages ([reference](./Pages/Index.cshtml.cs#L27-L54)).

7. Run the application:

    ```bash
    dotnet run
    ```