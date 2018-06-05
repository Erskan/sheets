using System;
using System.Collections.Generic;
using SheetsApi.Forces;
using SheetsApi.Shared;

namespace SheetsApi.Games
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
        public IEnumerable<Force> Forces { get; set; }
        public Force Winner { get; set; }
        public Force Loser { get; set; }
        public DateTime Completed { get; set; }

        public GameModel()
        {
            Forces = new List<Force>();
        }
    }
}