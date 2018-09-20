using System;
using System.Collections.Generic;

namespace LifeRPG.Models
{
    public partial class SkillDetails
    {
        public long Id { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Icon { get; set; }
        public long? StartingXp { get; set; }
        public string Notes { get; set; }
    }
}
