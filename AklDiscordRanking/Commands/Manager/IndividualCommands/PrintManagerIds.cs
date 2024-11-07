using AklDiscordRanking.Core.Handlers;
using Discord.Interactions;

namespace AklDiscordRanking.Commands.Manager;

/// <remarks>
/// This class is partial because the command can only be registered in a module.
/// </remarks>
public partial class ManagerModuleSlash
{
    [SlashCommand("print_managers_id", "Print the current managers id")]
    public async Task PrintManagersId() => await RespondAsync(
        text: dbContext.Users
            .Where(x => x.Permissions.HasFlag(PermissionHandler.EPermissions.Manager))
            .Select(x => x.Id.ToString()).ToList()
            .Aggregate((x, y) => $"{x}, {y}")
    );
}