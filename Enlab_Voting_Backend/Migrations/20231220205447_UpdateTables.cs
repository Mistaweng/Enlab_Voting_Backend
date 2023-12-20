using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnlabVotingBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "PaymentAmount");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "SelectedCandidates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPaid",
                table: "RegisteredCandidates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "RegisteredCandidates",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "VoteRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TotalVotes = table.Column<int>(type: "integer", nullable: false),
                    VoterId = table.Column<string>(type: "text", nullable: false),
                    ContestantId = table.Column<string>(type: "text", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteRecords_Contestants_ContestantId",
                        column: x => x.ContestantId,
                        principalTable: "Contestants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteRecords_ContestantId",
                table: "VoteRecords",
                column: "ContestantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteRecords");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "SelectedCandidates");

            migrationBuilder.DropColumn(
                name: "HasPaid",
                table: "RegisteredCandidates");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "RegisteredCandidates");

            migrationBuilder.RenameColumn(
                name: "PaymentAmount",
                table: "Transactions",
                newName: "Amount");
        }
    }
}
