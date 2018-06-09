using System;
using System.Collections.Generic;
using SheetsApi.Games;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Forces
{
    public class ForceModel
    {
        public int ForceId { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }

        public IEnumerable<SheetModel> Sheets { get; set; }
        public IEnumerable<GameForceMap> GameForceMaps { get; set; }

        public ForceModel()
        {
            Sheets = new List<SheetModel>();
            GameForceMaps = new List<GameForceMap>();
        }
    }
}