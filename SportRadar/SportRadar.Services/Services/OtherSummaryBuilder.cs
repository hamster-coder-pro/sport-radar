using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SportRadar.Services
{
    public class OtherSummaryBuilder : IGameSummaryBuilder
    {
        public void Build(IEnumerable<Game> games)
        {
            games = games.OrderBy(x => x.Home.Score + x.Away.Score).ThenBy(x => x.AddedOn);
            foreach (var x in games)
            {
                Debug.WriteLine($"{x.Away.Name} {x.Away.Score} - {x.Home.Name} {x.Home.Score}");
            }
        }
    }
}