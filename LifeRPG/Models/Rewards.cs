using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LifeRPG.Models
{
    public partial class Rewards
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? QuantityAvailable { get; set; }
        public long? ClaimTotal { get; set; }
        public long? Cost { get; set; }
        public long? TimeCreated { get; set; }
        public long? TimeUpdated { get; set; }
        public long? TimeLastUpdated { get; set; }
        public string IconAsset { get; set; }
        public long? IsCostIncrementing { get; set; }
        public long? CostIncrement { get; set; }
        public long? AddsToInventory { get; set; }
        public string Category { get; set; }
        public DateTime LastUpdatedDisplay { get { return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(TimeLastUpdated ?? 0).ToLocalTime()); } }
        public DateTime TimeUpdatedDisplay { get { return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(TimeUpdated ?? 0).ToLocalTime()); } }
        public DateTime TimeCreatedDisplay { get { return (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(TimeCreated ?? 0).ToLocalTime()); } }
    }
}
