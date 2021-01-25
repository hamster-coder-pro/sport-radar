using System.Collections.Generic;

namespace SportRadar.Services
{
    public interface IGameSummaryBuilder
    {
        void Build(IEnumerable<Game> games);
    }
}