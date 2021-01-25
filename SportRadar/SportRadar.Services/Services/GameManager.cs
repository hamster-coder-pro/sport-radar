using System;

namespace SportRadar.Services
{
    public class GameManager : IGameManager
    {
        private IGamesStorage GamesStorage { get; }

        public GameManager(IGamesStorage gamesStorage)
        {
            GamesStorage = gamesStorage;
        }

        public Guid StartGame(
            string homeTeam,
            string awayTeam
        )
        {
            // exception process / wrap example
            try
            {
                var game = new Game(homeTeam, awayTeam);
                if (GamesStorage.AddGame(game) == false)
                {
                    throw new CantStartGameException();
                }

                return game.Id;
            }
            catch (CantStartGameException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new CantStartGameException("Unexpected exception", exception);
            }
        }

        public void FinishGame(Guid gameId)
        {
            // we don't care if it removed 
            GamesStorage.RemoveGame(gameId);
        }

        public void UpdateScore(
            Guid gameId,
            int homeTeam,
            int awayTeam
        )
        {
            GamesStorage.UpdateGameData(gameId, game => { game.UpdateScore(homeTeam, awayTeam); });
        }

        public void BuildSummary(IGameSummaryBuilder summaryCreator)
        {
            summaryCreator.Build(GamesStorage.Enumerate());
        }

        public Guid? FindGame(
            string homeTeam,
            string awayTeam
        )
        {
            return GamesStorage.Find(game => game.Home.Name == homeTeam && game.Away.Name != awayTeam);
        }
    }
}