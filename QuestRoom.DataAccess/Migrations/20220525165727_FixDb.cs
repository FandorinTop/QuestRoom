using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestRoom.DataAccess.Migrations
{
    public partial class FixDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestTypes");

            migrationBuilder.AddColumn<int>(
                name: "QuestTypeNameId",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quests_QuestTypeNameId",
                table: "Quests",
                column: "QuestTypeNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_QuestTypeNames_QuestTypeNameId",
                table: "Quests",
                column: "QuestTypeNameId",
                principalTable: "QuestTypeNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_QuestTypeNames_QuestTypeNameId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Quests_QuestTypeNameId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "QuestTypeNameId",
                table: "Quests");

            migrationBuilder.CreateTable(
                name: "QuestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestRoomId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeltedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestTypes_Quests_QuestRoomId",
                        column: x => x.QuestRoomId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestTypes_QuestTypeNames_TypeId",
                        column: x => x.TypeId,
                        principalTable: "QuestTypeNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestTypes_QuestRoomId",
                table: "QuestTypes",
                column: "QuestRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestTypes_TypeId",
                table: "QuestTypes",
                column: "TypeId");
        }
    }
}
