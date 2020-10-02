using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Serilog.Samples.Autofac.Services;

namespace Serilog.Samples.Autofac.Pages
{
    public class IndexModel : PageModel
    {
        public string Greeting {get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IGreetingsService _greetingsService;

        public IndexModel(ILogger<IndexModel> logger, IGreetingsService greetingsService)
        {
            _logger = logger;
            _greetingsService = greetingsService;
        }

        public void OnGet()
        {
            using (_logger.BeginScope("GET Index"))
            {
                _logger.LogInformation("Index load");

                // Do something else...

                Greeting = _greetingsService.SayHello("Liam");
                _logger.LogInformation("Greeting message given: {Greeting}", Greeting);
            }

            _logger.LogInformation("Hello, world!");

            var fruit = new[] { "Apple", "Pear", "Orange" };
            _logger.LogInformation("In my bowl I have {Fruit}", fruit);

            var sensorInput = new { Latitude = 25, Longitude = 134 };
            _logger.LogInformation("Processing {@SensorInput}", sensorInput);

            int a = 10, b = 0;
            try
            {
                _logger.LogInformation("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
            }            
        }
    }
}
