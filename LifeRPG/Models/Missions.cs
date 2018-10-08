using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LifeRPG.Utils;

namespace LifeRPG.Models
{
    public partial class Missions
    {
        public long Id { get; set; }
        public long? Parent { get; set; }
        public long Completed { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Difficulty { get; set; }
        public long Productiveness { get; set; }
        public long Fear { get; set; }
        public long TimeCreated { get; set; }
        public long? TimeUpdated { get; set; }
        public long? TimeDue { get; set; }
        public long? TimeCompleted { get; set; }
        public long? LevelCreated { get; set; }
        public long? LevelDone { get; set; }
        public long? Continuous { get; set; }
        public string Repetition { get; set; }
        public string IconAsset { get; set; }
        public string Notes { get; set; }
        public long? Interval { get; set; }
        public long? Duration { get; set; }
        public long? DurationUnits { get; set; }
        public long? RewardPoints { get; set; }
        public long? SeriesId { get; set; }
        public long? RelativePosition { get; set; }
        public long? IsDueAtSpecificTime { get; set; }
        public long? HasReminders { get; set; }
        public long? HasLocation { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [NotMapped]
        public DateTime TimeCreatedDisplay => Utilities.ToDateTime(TimeCreated);
        [NotMapped]
        public DateTime TimeUpdatedDisplay => Utilities.ToDateTime(TimeUpdated);
        [NotMapped]
        public DateTime TimeDueDisplay => Utilities.ToDateTime(TimeDue);
        [NotMapped]
        public DateTime TimeCompletedDisplay => Utilities.ToDateTime(TimeCompleted);
        [NotMapped]
        public string DurationDisplay => Duration + (DurationUnits == 0 ? " minutes" : DurationUnits == 1 ? " hours" : "days");
    }
}
