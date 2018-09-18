using SheetsApi.Forces;

namespace SheetsApi.Games
{
    public class Combatant
    {
        public int Id { get; set; }
        public Force Force { get; set; }
        public Game Game { get; set; }
        public int Score { get; set; }
    }
}