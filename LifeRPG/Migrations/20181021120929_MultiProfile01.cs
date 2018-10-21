using Microsoft.EntityFrameworkCore.Migrations;

namespace LifeRPG.Migrations
{
    public partial class MultiProfile01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //TODO: write SQL to move data from Profile to Profiles
            migrationBuilder.Sql("INSERT INTO Profiles(Name, Title, Avatar, Description, RewardPoints) VALUES(" +
                "SELECT Value FROM Profile WHERE Setting='name'," +
                "SELECT Value FROM Profile WHERE Setting='title'," +
                "SELECT Value FROM Profile WHERE Setting='avatar'," +
                "SELECT Value FROM Profile WHERE Setting='description'," +
                "SELECT Value FROM Profile WHERE Setting='rewardPoints')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Profile(Setting, Value) ('name', SELECT TOP(1) Name FROM Profiles ORDER BY Id);" +
                "INSERT INTO Profile(Setting, Value) ('title', SELECT TOP(1) Title FROM Profiles ORDER BY Id);" +
                "INSERT INTO Profile(Setting, Value) ('avatar', SELECT TOP(1) Avatar FROM Profiles ORDER BY Id);" +
                "INSERT INTO Profile(Setting, Value) ('description', SELECT TOP(1) Description FROM Profiles ORDER BY Id);" +
                "INSERT INTO Profile(Setting, Value) ('rewardPoints', SELECT TOP(1) RewardPoints FROM Profiles ORDER BY Id);");
        }
    }
}
