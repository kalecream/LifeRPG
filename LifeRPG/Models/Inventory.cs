using System;
using System.Collections.Generic;

namespace LifeRPG.Models
{
    public partial class Inventory
    {
        public long Id { get; set; }
        public long? RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Category { get; set; }
        public long? QuantityAvailable { get; set; }
        public long? TimeCreated { get; set; }
        public long? TimeUpdated { get; set; }
        public long? IsConsumable { get; set; }
        public long? TimeLastConsumed { get; set; }
        public long? QuantityConsumed { get; set; }
        public long? ExpirationDate { get; set; }
        public long? HasExpirationReminder { get; set; }
        public long? RelativePosition { get; set; }
        public long? Value { get; set; }
        public long? ValueUnits { get; set; }
        public long? IsActive { get; set; }
    }
}
