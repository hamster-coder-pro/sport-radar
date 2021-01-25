using FluentAssertions;
using NUnit.Framework;

namespace SportRadar.Services.Tests
{
    public class RecentTotalScoreSummaryBuilderTests
    {
        private Game CreateGame(
            string homeTeamName,
            int homeTeamScore,
            string awayTeamName,
            int awayTeamScore
        )
        {
            var game = new Game(homeTeamName, awayTeamName);
            game.UpdateScore(homeTeamScore, awayTeamScore);
            return game;
        }

        [Test]
        public void Default()
        {
            var games = new[]
            {
                CreateGame("A", 1, "B", 2), CreateGame("A", 3, "B", 4), CreateGame("C", 1, "D", 2)
            };

            var expected = new[]
            {
                "A 3 - B 4", "C 1 - D 2", "A 1 - B 2"
            };

            var builder = new RecentTotalScoreSummaryBuilder();
            builder.Build(games);

            builder.ScoreBoard.Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        }
    }
}