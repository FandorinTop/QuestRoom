using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestRoom.DataAccess.Migrations
{
    public partial class RemoveCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParticipantCount",
                table: "QuestSession");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantCount",
                table: "QuestSession",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
