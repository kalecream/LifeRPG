using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeRPG.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "android_metadata",
                columns: table => new
                {
                    locale = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_android_metadata", x => x.locale);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    _id = table.Column<long>(nullable: false),
                    rewardId = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    quantityAvailable = table.Column<long>(nullable: true),
                    timeCreated = table.Column<long>(nullable: true),
                    timeUpdated = table.Column<long>(nullable: true),
                    isConsumable = table.Column<long>(nullable: true),
                    timeLastConsumed = table.Column<long>(nullable: true),
                    quantityConsumed = table.Column<long>(nullable: true),
                    expirationDate = table.Column<long>(nullable: true),
                    hasExpirationReminder = table.Column<long>(nullable: true),
                    relativePosition = table.Column<long>(nullable: true),
                    value = table.Column<long>(nullable: true),
                    valueUnits = table.Column<long>(nullable: true),
                    isActive = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "missions",
                columns: table => new
                {
                    _id = table.Column<long>(nullable: false),
                    parent = table.Column<long>(nullable: true),
                    completed = table.Column<long>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    difficulty = table.Column<long>(nullable: false),
                    productiveness = table.Column<long>(nullable: false),
                    fear = table.Column<long>(nullable: false),
                    timeCreated = table.Column<long>(nullable: false),
                    timeUpdated = table.Column<long>(nullable: true),
                    timeDue = table.Column<long>(nullable: true),
                    timeCompleted = table.Column<long>(nullable: true),
                    levelCreated = table.Column<long>(nullable: true),
                    levelDone = table.Column<long>(nullable: true),
                    continuous = table.Column<long>(nullable: true),
                    repetition = table.Column<string>(nullable: true),
                    iconAsset = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true),
                    interval = table.Column<long>(nullable: true),
                    duration = table.Column<long>(nullable: true),
                    durationUnits = table.Column<long>(nullable: true),
                    rewardPoints = table.Column<long>(nullable: true),
                    seriesId = table.Column<long>(nullable: true),
                    relativePosition = table.Column<long>(nullable: true),
                    isDueAtSpecificTime = table.Column<long>(nullable: true),
                    hasReminders = table.Column<long>(nullable: true),
                    hasLocation = table.Column<long>(nullable: true),
                    latitude = table.Column<double>(nullable: true),
                    longitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_missions", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    setting = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.setting);
                });

            migrationBuilder.CreateTable(
                name: "ProfileViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RewardPoints = table.Column<int>(nullable: false),
                    XP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reminders",
                columns: table => new
                {
                    _id = table.Column<long>(nullable: false),
                    objectType = table.Column<long>(nullable: true),
                    objectId = table.Column<long>(nullable: true),
                    reminderAmount = table.Column<long>(nullable: true),
                    reminderUnits = table.Column<long>(nullable: true),
                    jobId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reminders", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "rewards",
                columns: table => new
                {
                    _id = table.Column<long>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    quantityAvailable = table.Column<long>(nullable: true),
                    claimTotal = table.Column<long>(nullable: true),
                    cost = table.Column<long>(nullable: true),
                    timeCreated = table.Column<long>(nullable: true),
                    timeUpdated = table.Column<long>(nullable: true),
                    timeLastUpdated = table.Column<long>(nullable: true),
                    iconAsset = table.Column<string>(nullable: true),
                    isCostIncrementing = table.Column<long>(nullable: true),
                    costIncrement = table.Column<long>(nullable: true),
                    addsToInventory = table.Column<long>(nullable: true),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rewards", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "skillDetails",
                columns: table => new
                {
                    _id = table.Column<long>(nullable: false),
                    skill = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true),
                    icon = table.Column<string>(nullable: true),
                    startingXP = table.Column<long>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillDetails", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    skill = table.Column<string>(nullable: false),
                    missionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => new { x.skill, x.missionId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "android_metadata");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "missions");

            migrationBuilder.DropTable(
                name: "profile");

            migrationBuilder.DropTable(
                name: "ProfileViewModel");

            migrationBuilder.DropTable(
                name: "reminders");

            migrationBuilder.DropTable(
                name: "rewards");

            migrationBuilder.DropTable(
                name: "skillDetails");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
