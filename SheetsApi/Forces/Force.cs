using System.Collections.Generic;
using SheetsApi.Games;
using SheetsApi.Sheets;

namespace SheetsApi.Forces
{
    public class Force
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Sheets { get; set; }
        public IEnumerable<int> Games { get; set; }

        public Force()
        {
            Sheets = new List<int>();
            Games = new List<int>();
        }
    }
}
