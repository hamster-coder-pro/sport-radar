namespace SportRadar.Services
{
    public class GameTeam
    {
        public GameTeam()
        {
            Name = string.Empty;
            Score = 0;
        }

        public string Name { get; init; }

        public int Score { get; set; }
    }
}