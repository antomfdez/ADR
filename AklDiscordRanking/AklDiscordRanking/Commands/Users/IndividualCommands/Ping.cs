using System.Net.NetworkInformation;
using Discord;
using Discord.Interactions;

namespace AklDiscordRanking.Commands.Users;

/// <remarks>
/// This class is partial because the command can only be registered in a module.
/// </remarks>
public partial class UserModuleSlash
{
    [SlashCommand("ping", "Get the bot ping from discord")]
    public async Task Ping() => await RespondAsync(embed: PingCommand.GetPing());
}

/// <summary>
/// Static class used to hold functions for the current command.
/// </summary>
file static class PingCommand
{
    public static Embed GetPing()
    {
        var l_EmbedBuilder = new EmbedBuilder();
        l_EmbedBuilder.AddField("Discord: ", new Ping().Send("discord.com").RoundtripTime + "ms");

        l_EmbedBuilder.WithColor(Color.Blue);
        return l_EmbedBuilder.Build();
    }
}