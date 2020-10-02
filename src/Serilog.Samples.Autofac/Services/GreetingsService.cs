namespace Serilog.Samples.Autofac.Services
{
    public class GreetingsService : IGreetingsService
    {
        public string SayHello(string name) => SayGreeting("Hello", name);

        public string SayGreeting(string greeting, string name) => $"{greeting}, {name}!";
    }
}