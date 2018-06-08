using System;

namespace SheetsApi.Shared
{
    public class RuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
        public string Text { get; set; }
    }
}
