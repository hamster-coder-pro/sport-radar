using FluentAssertions;
using NUnit.Framework;

namespace SportRadar.Services.Tests
{
    public class SmokeTest
    {
        [Test]
        public void Execute()
        {
            var storage = new GamesStorage();
            var manager = new GameManager(storage);
            manager.UpdateScore(manager.StartGame("Mexico", "Canada"), 0, 5);
            manager.UpdateScore(manager.StartGame("Spain", "Brazil"), 10, 2);
            manager.UpdateScore(manager.StartGame("Germany", "France"), 2, 2);
            manager.FinishGame(manager.StartGame("Should be", "Removed"));
            manager.UpdateScore(manager.StartGame("Uruguay", "Italy"), 6, 6);
            manager.UpdateScore(manager.StartGame("Argentina", "Australia"), 3, 1);

            var report = new RecentTotalScoreSummaryBuilder();
            manager.BuildSummary(report);

            report.ScoreBoard.Should()
                .BeEquivalentTo(
                    new[]
                    {
                        "Uruguay 6 - Italy 6", "Spain 10 - Brazil 2", "Mexico 0 - Canada 5", "Argentina 3 - Australia 1", "Germany 2 - France 2"
                    },
                    o => o.WithStrictOrdering()
                );

            manager.BuildSummary(new OtherSummaryBuilder());
        }
    }
}