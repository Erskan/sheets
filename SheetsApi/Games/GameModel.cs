using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SheetsApi.Forces;
using SheetsApi.Shared;

namespace SheetsApi.Games
{
    public class GameModel
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
        /* TODO: Consider the concept of "Combatant" or something similar.
         *  A Combatant would then have a series of relations and a score to start with. Force and Game relation. Score just a value.
         *  Determining winner/loser becomes trivial and data model makes more sense.
        */
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