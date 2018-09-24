using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LifeRPG.ViewModels;

namespace LifeRPG.Models
{
    public partial class LifeRPGContext : DbContext
    {
        public LifeRPGContext()
        {
        }

        public LifeRPGContext(DbContextOptions<LifeRPGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AndroidMetadata> AndroidMetadata { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Reminders> Reminders { get; set; }
        public virtual DbSet<Rewards> Rewards { get; set; }
        public virtual DbSet<SkillDetails> SkillDetails { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\khammack\\Desktop\\LifeRPG.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AndroidMetadata>(entity =>
            {
                entity.HasKey(e => e.Locale);

                entity.ToTable("android_metadata");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExpirationDate).HasColumnName("expirationDate");

                entity.Property(e => e.HasExpirationReminder).HasColumnName("hasExpirationReminder");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsConsumable).HasColumnName("isConsumable");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.QuantityAvailable).HasColumnName("quantityAvailable");

                entity.Property(e => e.QuantityConsumed).HasColumnName("quantityConsumed");

                entity.Property(e => e.RelativePosition).HasColumnName("relativePosition");

                entity.Property(e => e.RewardId).HasColumnName("rewardId");

                entity.Property(e => e.TimeCreated).HasColumnName("timeCreated");

                entity.Property(e => e.TimeLastConsumed).HasColumnName("timeLastConsumed");

                entity.Property(e => e.TimeUpdated).HasColumnName("timeUpdated");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.Property(e => e.ValueUnits).HasColumnName("valueUnits");
            });

            modelBuilder.Entity<Missions>(entity =>
            {
                entity.ToTable("missions");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.Continuous).HasColumnName("continuous");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.DurationUnits).HasColumnName("durationUnits");

                entity.Property(e => e.Fear).HasColumnName("fear");

                entity.Property(e => e.HasLocation).HasColumnName("hasLocation");

                entity.Property(e => e.HasReminders).HasColumnName("hasReminders");

                entity.Property(e => e.IconAsset).HasColumnName("iconAsset");

                entity.Property(e => e.Interval).HasColumnName("interval");

                entity.Property(e => e.IsDueAtSpecificTime).HasColumnName("isDueAtSpecificTime");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.LevelCreated).HasColumnName("levelCreated");

                entity.Property(e => e.LevelDone).HasColumnName("levelDone");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.Property(e => e.Productiveness).HasColumnName("productiveness");

                entity.Property(e => e.RelativePosition).HasColumnName("relativePosition");

                entity.Property(e => e.Repetition).HasColumnName("repetition");

                entity.Property(e => e.RewardPoints).HasColumnName("rewardPoints");

                entity.Property(e => e.SeriesId).HasColumnName("seriesId");

                entity.Property(e => e.TimeCompleted).HasColumnName("timeCompleted");

                entity.Property(e => e.TimeCreated).HasColumnName("timeCreated");

                entity.Property(e => e.TimeDue).HasColumnName("timeDue");

                entity.Property(e => e.TimeUpdated).HasColumnName("timeUpdated");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.Setting);

                entity.ToTable("profile");

                entity.Property(e => e.Setting)
                    .HasColumnName("setting")
                    .ValueGeneratedNever();

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Reminders>(entity =>
            {
                entity.ToTable("reminders");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.JobId).HasColumnName("jobId");

                entity.Property(e => e.ObjectId).HasColumnName("objectId");

                entity.Property(e => e.ObjectType).HasColumnName("objectType");

                entity.Property(e => e.ReminderAmount).HasColumnName("reminderAmount");

                entity.Property(e => e.ReminderUnits).HasColumnName("reminderUnits");
            });

            modelBuilder.Entity<Rewards>(entity =>
            {
                entity.ToTable("rewards");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddsToInventory).HasColumnName("addsToInventory");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.ClaimTotal).HasColumnName("claimTotal");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CostIncrement).HasColumnName("costIncrement");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IconAsset).HasColumnName("iconAsset");

                entity.Property(e => e.IsCostIncrementing).HasColumnName("isCostIncrementing");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.QuantityAvailable).HasColumnName("quantityAvailable");

                entity.Property(e => e.TimeCreated).HasColumnName("timeCreated");

                entity.Property(e => e.TimeLastUpdated).HasColumnName("timeLastUpdated");

                entity.Property(e => e.TimeUpdated).HasColumnName("timeUpdated");
            });

            modelBuilder.Entity<SkillDetails>(entity =>
            {
                entity.ToTable("skillDetails");

                entity.Property(e => e.Id)
                    .HasColumnName("_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Skill).HasColumnName("skill");

                entity.Property(e => e.StartingXp).HasColumnName("startingXP");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.HasKey(e => new { e.Skill, e.MissionId });

                entity.ToTable("skills");

                entity.Property(e => e.Skill).HasColumnName("skill");

                entity.Property(e => e.MissionId).HasColumnName("missionId");
            });
        }

        public DbSet<LifeRPG.ViewModels.ProfileViewModel> ProfileViewModel { get; set; }
    }
}
