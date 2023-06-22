using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PR.Application;
using PR.Application.System.Commands.SeedSampleData;
using PR.Persistance;

namespace PR.Client;

public class Program
{
    public static IConfigurationRoot Configuration { get; set; }

    public static async Task Main(string[] args)
    {
        var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        if(isDevelopment)
        {
            configurationBuilder.AddUserSecrets<Program>();
        }

        Configuration = configurationBuilder.Build();

        var serviceProvider = new ServiceCollection()
            .AddPersistenceServices(Configuration)
            .AddApplicationServices()
            .BuildServiceProvider();

        var mediator = serviceProvider.GetService<IMediator>();

        //await mediator!.Send(new SeedSampleDataCommand());

        Console.WriteLine("Hello World");
    }
}