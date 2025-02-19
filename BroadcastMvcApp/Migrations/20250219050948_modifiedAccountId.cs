using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BroadcastMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class modifiedAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Messages_MessageId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_Channels_MessageId",
                table: "Channels");

            migrationBuilder.RenameColumn(
                name: "JoinedUsersId",
                table: "Channels",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Channels",
                newName: "JoinedUsersId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_MessageId",
                table: "Channels",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Messages_MessageId",
                table: "Channels",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
