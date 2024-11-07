using Discord;
using Discord.Interactions;

namespace AklDiscordRanking.Commands.Users;

/// <remarks>
/// This class is partial because the command can only be registered in a module.
/// </remarks>
public partial class UserModuleSlash
{
    private static readonly List<decimal> Scores = [100.2m, 60m, 75.5m, 88.0m, 92.3m];

    [SlashCommand("addscore", "Adds a score to the leaderboard")]
    public async Task AddScore([Summary("score", "The score to add")] decimal score)
    {
        Scores.Add(score);
        await RespondAsync($"Score {score} added!");
    }

    [SlashCommand("leaderboard", "Displays the leaderboard")]
    public async Task Leaderboard()
    {
        var embed = CreateLeaderboardEmbed();
        await RespondAsync(embed: embed);
    }

    private Embed CreateLeaderboardEmbed()
    {
        var embedBuilder = new EmbedBuilder()
            .WithTitle("Leaderboard")
            .WithColor(Color.Green);

        if (Scores.Count == 0)
        {
            embedBuilder.Description = "No scores available.";
            return embedBuilder.Build();
        }

        // Sort scores and create leaderboard entries
        var sortedScores = Scores
            .Select((score, index) => new { Position = index + 1, Score = score })
            .OrderByDescending(x => x.Score)
            .ToList();

        // Build the leaderboard description
        var leaderboardDescription = string.Join("\n", sortedScores.Select(x => $"{x.Position}. Score: {x.Score}"));

        embedBuilder.Description = leaderboardDescription;
        return embedBuilder.Build();
    }
}