using System.Collections;
using System.Collections.Generic;
using SheetsApi.Forces;

namespace SheetsApi.Games
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Combatant> Combatants { get; set; }

        public Game()
        {
            Combatants = new List<Combatant>();
        }
    }
}
