using LifeRPG.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public DateTime LastUpdatedDisplay => Utilities.ToDateTime(TimeLastUpdated);
        [NotMapped]
        public DateTime TimeUpdatedDisplay => Utilities.ToDateTime(TimeUpdated);
        [NotMapped]
        public DateTime TimeCreatedDisplay => Utilities.ToDateTime(TimeCreated);
    }
}
