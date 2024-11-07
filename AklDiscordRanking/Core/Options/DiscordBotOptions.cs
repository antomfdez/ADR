using System.ComponentModel.DataAnnotations;

namespace AklDiscordRanking.Core.Options;

public class DiscordBotOptions
{
    [Required] public required ulong Id { get; init; }
    [Required] public required string Name { get; init; }
    [Required] public required string Status { get; init; }
    [Required] public required string Token { get; init; }
    [Required] public required ulong ManagerId { get; init; }
}