using System;
using System.Collections.Generic;

namespace LifeRPG.Models
{
    public partial class Reminders
    {
        public long Id { get; set; }
        public long? ObjectType { get; set; }
        public long? ObjectId { get; set; }
        public long? ReminderAmount { get; set; }
        public long? ReminderUnits { get; set; }
        public long? JobId { get; set; }
    }
}
