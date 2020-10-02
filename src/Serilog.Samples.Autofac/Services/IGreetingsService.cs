namespace Serilog.Samples.Autofac.Services
{
    public interface IGreetingsService
    {
        string SayHello(string name);
        string SayGreeting(string greeting, string name);
    }
}