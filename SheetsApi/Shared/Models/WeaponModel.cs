﻿using System;
using System.Collections.Generic;

namespace SheetsApi.Shared
{
    public class WeaponModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SheetsUser AddedByUser { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public SheetsUser ModifiedByUser { get; set; }
        public int Range { get; set; }
        public WeaponTypeModel Type { get; set; }
        public int Strength { get; set; }
        public int ArmorPenetration { get; set; }
        public int Damage { get; set; }
        public IEnumerable<RuleModel> Rules { get; set; }

        public WeaponModel()
        {
            Rules = new List<RuleModel>();
        }
    }
}