using System;
using Microsoft.AspNetCore.Identity;

namespace SheetsApi.Shared
{
    public class RuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IdentityUser<int> AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public IdentityUser<int> ModifiedByUser { get; set; }
        public string Text { get; set; }
        public int Points { get; set; }
    }
}
