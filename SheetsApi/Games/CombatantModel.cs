using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SheetsApi.Forces;
using SheetsApi.Shared;

namespace SheetsApi.Games
{
    public class CombatantModel
    {
        public int CombatantId { get; set; }
        public int GameId { get; set; }
        public int ForceId { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
        public int Score { get; set; }
    }
}