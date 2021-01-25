using System;

namespace SportRadar.Services
{
    public interface IGameManager
    {
        Guid StartGame(
            string homeTeam,
            string awayTeam
        );

        Guid? FindGame(
            string homeTeam,
            string awayTeam
        );

        void FinishGame(Guid gameId);

        void UpdateScore(
            Guid gameId,
            int homeTeam,
            int awayTeam
        );

        void BuildSummary(IGameSummaryBuilder summaryCreator);
    }
}