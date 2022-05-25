using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestRoom.DataAccess.Migrations
{
    public partial class RemoveQuestSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestActors_ActorSets_QuestActorSetId",
                table: "QuestActors");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_ActorSets_QuestActorSetId",
                table: "QuestSession");

            migrationBuilder.DropTable(
                name: "ActorSets");

            migrationBuilder.RenameColumn(
                name: "QuestActorSetId",
                table: "QuestSession",
                newName: "QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestSession_QuestActorSetId",
                table: "QuestSession",
                newName: "IX_QuestSession_QuestId");

            migrationBuilder.RenameColumn(
                name: "QuestActorSetId",
                table: "QuestActors",
                newName: "QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActors_QuestActorSetId",
                table: "QuestActors",
                newName: "IX_QuestActors_QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActors_Quests_QuestId",
                table: "QuestActors",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_Quests_QuestId",
                table: "QuestSession",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestActors_Quests_QuestId",
                table: "QuestActors");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_Quests_QuestId",
                table: "QuestSession");

            migrationBuilder.RenameColumn(
                name: "QuestId",
                table: "QuestSession",
                newName: "QuestActorSetId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestSession_QuestId",
                table: "QuestSession",
                newName: "IX_QuestSession_QuestActorSetId");

            migrationBuilder.RenameColumn(
                name: "QuestId",
                table: "QuestActors",
                newName: "QuestActorSetId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActors_QuestId",
                table: "QuestActors",
                newName: "IX_QuestActors_QuestActorSetId");

            migrationBuilder.CreateTable(
                name: "ActorSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeltedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorSets_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorSets_QuestId",
                table: "ActorSets",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActors_ActorSets_QuestActorSetId",
                table: "QuestActors",
                column: "QuestActorSetId",
                principalTable: "ActorSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_ActorSets_QuestActorSetId",
                table: "QuestSession",
                column: "QuestActorSetId",
                principalTable: "ActorSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
