using System.Collections.Generic;
using SheetsApi.Games;
using SheetsApi.Sheets;

namespace SheetsApi.Forces
{
    public class Force
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Sheet> Sheets { get; set; }
        public IEnumerable<Game> Games { get; set; }

        public Force()
        {
            Sheets = new List<Sheet>();
            Games = new List<Game>();
        }
    }
}
