using System;
using Microsoft.AspNetCore.Identity;

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