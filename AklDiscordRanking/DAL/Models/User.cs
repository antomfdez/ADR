using EPermissions = AklDiscordRanking.Core.Handlers.PermissionHandler.EPermissions;

namespace AklDiscordRanking.DAL.Models;

public class User
{
    /// <summary>
    /// The Discord user Id.
    /// </summary>
    public ulong Id { get; init; }

    /// <summary>
    /// The User command permissions flag.
    /// </summary>
    public EPermissions Permissions { get; set; }
}