using System;
using System.Collections.Generic;
using SheetsApi.Shared;
using SheetsApi.Sheets;

namespace SheetsApi.Forces
{
    public class ForceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
        public IEnumerable<Sheet> Sheets { get; set; }

        public ForceModel()
        {
            Sheets = new List<Sheet>();
        }
    }
}