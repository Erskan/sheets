using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SheetsApi.Games;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Forces
{
    public class ForceModel
    {
        public int ForceId { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }

        public IEnumerable<SheetModel> Sheets { get; set; }
        public IEnumerable<GameForceMap> GameForceMaps { get; set; }

        public ForceModel()
        {
            Sheets = new List<SheetModel>();
            GameForceMaps = new List<GameForceMap>();
        }
    }
}