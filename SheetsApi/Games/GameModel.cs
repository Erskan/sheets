using System;
using System.Collections.Generic;
using SheetsApi.Forces;
using SheetsApi.Shared;

namespace SheetsApi.Games
{
    public class GameModel
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
        // TODO: This is stupid. I gotta find a way to support and represent more forces for a single game.
        public ForceModel Winner { get; set; }
        public ForceModel Loser { get; set; }
        public int? WinnerScore { get; set; }
        public int? LoserScore { get; set; }
        public DateTime? Completed { get; set; }
        public IEnumerable<GameForceMap> GameForceMap { get; set; }

        public GameModel()
        {
            GameForceMap = new List<GameForceMap>();
        }
    }
}