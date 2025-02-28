using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BroadcastMvcApp.Migrations
{
    /// <inheritdoc />
    public partial class changedforeignkeysinchannelstoienumerablecollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Channels");

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChannelId",
                table: "Messages",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ChannelId",
                table: "Accounts",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Channels_ChannelId",
                table: "Accounts",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Channels_ChannelId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChannelId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ChannelId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Channels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Channels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
