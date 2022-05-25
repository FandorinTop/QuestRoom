using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestRoom.DataAccess.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestActor_Personals_PersonalId",
                table: "QuestActor");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestActor_QuestActorSet_QuestActorSetId",
                table: "QuestActor");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestActorSet_Quests_QuestId",
                table: "QuestActorSet");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_Discount_DiscountId",
                table: "QuestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_QuestActorSet_QuestActorSetId",
                table: "QuestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestType_Quests_QuestRoomId",
                table: "QuestType");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestType_QuestTypeName_TypeId",
                table: "QuestType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestTypeName",
                table: "QuestTypeName");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestType",
                table: "QuestType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestActorSet",
                table: "QuestActorSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestActor",
                table: "QuestActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discount",
                table: "Discount");

            migrationBuilder.RenameTable(
                name: "QuestTypeName",
                newName: "QuestTypeNames");

            migrationBuilder.RenameTable(
                name: "QuestType",
                newName: "QuestTypes");

            migrationBuilder.RenameTable(
                name: "QuestActorSet",
                newName: "ActorSets");

            migrationBuilder.RenameTable(
                name: "QuestActor",
                newName: "QuestActors");

            migrationBuilder.RenameTable(
                name: "Discount",
                newName: "Discounts");

            migrationBuilder.RenameIndex(
                name: "IX_QuestType_TypeId",
                table: "QuestTypes",
                newName: "IX_QuestTypes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestType_QuestRoomId",
                table: "QuestTypes",
                newName: "IX_QuestTypes_QuestRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActorSet_QuestId",
                table: "ActorSets",
                newName: "IX_ActorSets_QuestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActor_QuestActorSetId",
                table: "QuestActors",
                newName: "IX_QuestActors_QuestActorSetId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActor_PersonalId",
                table: "QuestActors",
                newName: "IX_QuestActors_PersonalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestTypeNames",
                table: "QuestTypeNames",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestTypes",
                table: "QuestTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorSets",
                table: "ActorSets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestActors",
                table: "QuestActors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorSets_Quests_QuestId",
                table: "ActorSets",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActors_ActorSets_QuestActorSetId",
                table: "QuestActors",
                column: "QuestActorSetId",
                principalTable: "ActorSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActors_Personals_PersonalId",
                table: "QuestActors",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_ActorSets_QuestActorSetId",
                table: "QuestSession",
                column: "QuestActorSetId",
                principalTable: "ActorSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_Discounts_DiscountId",
                table: "QuestSession",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestTypes_Quests_QuestRoomId",
                table: "QuestTypes",
                column: "QuestRoomId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestTypes_QuestTypeNames_TypeId",
                table: "QuestTypes",
                column: "TypeId",
                principalTable: "QuestTypeNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorSets_Quests_QuestId",
                table: "ActorSets");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestActors_ActorSets_QuestActorSetId",
                table: "QuestActors");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestActors_Personals_PersonalId",
                table: "QuestActors");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_ActorSets_QuestActorSetId",
                table: "QuestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestSession_Discounts_DiscountId",
                table: "QuestSession");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestTypes_Quests_QuestRoomId",
                table: "QuestTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestTypes_QuestTypeNames_TypeId",
                table: "QuestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestTypes",
                table: "QuestTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestTypeNames",
                table: "QuestTypeNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestActors",
                table: "QuestActors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorSets",
                table: "ActorSets");

            migrationBuilder.RenameTable(
                name: "QuestTypes",
                newName: "QuestType");

            migrationBuilder.RenameTable(
                name: "QuestTypeNames",
                newName: "QuestTypeName");

            migrationBuilder.RenameTable(
                name: "QuestActors",
                newName: "QuestActor");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "Discount");

            migrationBuilder.RenameTable(
                name: "ActorSets",
                newName: "QuestActorSet");

            migrationBuilder.RenameIndex(
                name: "IX_QuestTypes_TypeId",
                table: "QuestType",
                newName: "IX_QuestType_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestTypes_QuestRoomId",
                table: "QuestType",
                newName: "IX_QuestType_QuestRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActors_QuestActorSetId",
                table: "QuestActor",
                newName: "IX_QuestActor_QuestActorSetId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestActors_PersonalId",
                table: "QuestActor",
                newName: "IX_QuestActor_PersonalId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorSets_QuestId",
                table: "QuestActorSet",
                newName: "IX_QuestActorSet_QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestType",
                table: "QuestType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestTypeName",
                table: "QuestTypeName",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestActor",
                table: "QuestActor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discount",
                table: "Discount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestActorSet",
                table: "QuestActorSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActor_Personals_PersonalId",
                table: "QuestActor",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActor_QuestActorSet_QuestActorSetId",
                table: "QuestActor",
                column: "QuestActorSetId",
                principalTable: "QuestActorSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestActorSet_Quests_QuestId",
                table: "QuestActorSet",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_Discount_DiscountId",
                table: "QuestSession",
                column: "DiscountId",
                principalTable: "Discount",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestSession_QuestActorSet_QuestActorSetId",
                table: "QuestSession",
                column: "QuestActorSetId",
                principalTable: "QuestActorSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestType_Quests_QuestRoomId",
                table: "QuestType",
                column: "QuestRoomId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestType_QuestTypeName_TypeId",
                table: "QuestType",
                column: "TypeId",
                principalTable: "QuestTypeName",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
