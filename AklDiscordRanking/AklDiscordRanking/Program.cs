using AklDiscordRanking;
using AklDiscordRanking.Core.Host;
using AklDiscordRanking.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.ConfigureServices((host, services) =>
{
    services.AddOptionsWithValidateOnStart<DiscordBotOptions>()
        .Bind(host.Configuration.GetSection(Constants.DiscordBotOptionsSectionsKey))
        .ValidateDataAnnotations();

    services.AddDiscordBotServices()
        .AddHostedService<DiscordBotHost>();
});

await builder.Build()
    .StartAsync();