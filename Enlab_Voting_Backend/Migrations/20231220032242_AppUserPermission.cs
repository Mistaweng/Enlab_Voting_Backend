using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnlabVotingBackend.Migrations
{
    /// <inheritdoc />
    public partial class AppUserPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Wallet_WalletId",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCandidate_AspNetUsers_AppUserId",
                table: "SelectedCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCandidate_Contestants_ContestantId",
                table: "SelectedCandidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_SelectedCandidate_SelectedCandidateId",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_AspNetUsers_AppUserId",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedCandidate",
                table: "SelectedCandidate");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "SelectedCandidate",
                newName: "SelectedCandidates");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_AppUserId",
                table: "Wallets",
                newName: "IX_Wallets_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCandidate_ContestantId",
                table: "SelectedCandidates",
                newName: "IX_SelectedCandidates_ContestantId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCandidate_AppUserId",
                table: "SelectedCandidates",
                newName: "IX_SelectedCandidates_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedCandidateId",
                table: "Voters",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedCandidates",
                table: "SelectedCandidates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: true),
                    ImageData = table.Column<byte[]>(type: "bytea", nullable: true),
                    CloudinaryPublicId = table.Column<string>(type: "text", nullable: false),
                    CloudinaryUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    WalletAppUserId = table.Column<string>(type: "text", nullable: false),
                    WalletId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletHistories_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletHistories_WalletId",
                table: "WalletHistories",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Wallets_WalletId",
                table: "Contestants",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCandidates_AspNetUsers_AppUserId",
                table: "SelectedCandidates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCandidates_Contestants_ContestantId",
                table: "SelectedCandidates",
                column: "ContestantId",
                principalTable: "Contestants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_SelectedCandidates_SelectedCandidateId",
                table: "Voters",
                column: "SelectedCandidateId",
                principalTable: "SelectedCandidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_AppUserId",
                table: "Wallets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Wallets_WalletId",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCandidates_AspNetUsers_AppUserId",
                table: "SelectedCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectedCandidates_Contestants_ContestantId",
                table: "SelectedCandidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_SelectedCandidates_SelectedCandidateId",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_AppUserId",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "WalletHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectedCandidates",
                table: "SelectedCandidates");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameTable(
                name: "SelectedCandidates",
                newName: "SelectedCandidate");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_AppUserId",
                table: "Wallet",
                newName: "IX_Wallet_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCandidates_ContestantId",
                table: "SelectedCandidate",
                newName: "IX_SelectedCandidate_ContestantId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectedCandidates_AppUserId",
                table: "SelectedCandidate",
                newName: "IX_SelectedCandidate_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "SelectedCandidateId",
                table: "Voters",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectedCandidate",
                table: "SelectedCandidate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Wallet_WalletId",
                table: "Contestants",
                column: "WalletId",
                principalTable: "Wallet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCandidate_AspNetUsers_AppUserId",
                table: "SelectedCandidate",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectedCandidate_Contestants_ContestantId",
                table: "SelectedCandidate",
                column: "ContestantId",
                principalTable: "Contestants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_SelectedCandidate_SelectedCandidateId",
                table: "Voters",
                column: "SelectedCandidateId",
                principalTable: "SelectedCandidate",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_AspNetUsers_AppUserId",
                table: "Wallet",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
