using System;

namespace SportRadar.Services
{
    public class Game
    {
        public Game(
            string homeTeam,
            string awayTeam
        )
        {
            Id = Guid.NewGuid();
            AddedOn = DateTime.UtcNow;
            Home = new GameTeam()
            {
                Name = homeTeam
            };
            Away = new GameTeam()
            {
                Name = awayTeam
            };
        }

        public Guid Id { get; }

        public DateTime AddedOn { get; }

        public GameTeam Home { get; private set; }

        public GameTeam Away { get; }

        public void UpdateScore(
            int homeTeam,
            int awayTeam
        )
        {
            Home.Score = homeTeam;
            Away.Score = awayTeam;
        }
    }
}