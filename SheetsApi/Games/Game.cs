using SheetsApi.Forces;

namespace SheetsApi.Games
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Force Winner { get; set; }
        public Force Loser { get; set; }
        public int? WinnerScore { get; set; }
        public int? LoserScore { get; set; }
    }
}
