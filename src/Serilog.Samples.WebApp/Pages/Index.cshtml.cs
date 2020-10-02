using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Serilog.Samples.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
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
