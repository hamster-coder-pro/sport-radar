using System.Collections.Generic;
using System.Linq;

namespace SportRadar.Services
{
    public class RecentTotalScoreSummaryBuilder : IGameSummaryBuilder
    {
        public RecentTotalScoreSummaryBuilder()
        {
            ScoreBoard = new List<string>();
        }

        public ICollection<string> ScoreBoard { get; private set; }

        public void Build(IEnumerable<Game> games)
        {
            games = games.OrderByDescending(x => x.Home.Score + x.Away.Score).ThenByDescending(x => x.AddedOn);
            ScoreBoard = games.Select(x => $"{x.Home.Name} {x.Home.Score} - {x.Away.Name} {x.Away.Score}").ToList();
        }
    }
}