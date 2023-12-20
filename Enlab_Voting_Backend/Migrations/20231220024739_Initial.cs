using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EnlabVotingBackend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    IsLockedOut = table.Column<bool>(type: "boolean", nullable: true),
                    LastOnline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    VoterCode = table.Column<string>(type: "text", nullable: true),
                    Timeleft = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestPositions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    President = table.Column<string>(type: "text", nullable: false),
                    VicePresident = table.Column<string>(type: "text", nullable: false),
                    Secretary = table.Column<string>(type: "text", nullable: false),
                    ViceSecretary = table.Column<string>(type: "text", nullable: false),
                    Treasurer = table.Column<string>(type: "text", nullable: false),
                    FinancialSecretary = table.Column<string>(type: "text", nullable: false),
                    PRO = table.Column<string>(type: "text", nullable: false),
                    Welfare = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestPositions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setting_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "boolean", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Vendor = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredCandidates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    PositionId = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Fees = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCandidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredCandidates_ContestPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "ContestPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contestants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    NoOfVotes = table.Column<int>(type: "integer", nullable: false),
                    WalletId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contestants_Wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectedCandidate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ContestantId = table.Column<string>(type: "text", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedCandidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedCandidate_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedCandidate_Contestants_ContestantId",
                        column: x => x.ContestantId,
                        principalTable: "Contestants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    NoOfVotes = table.Column<int>(type: "integer", nullable: false),
                    SelectedCandidateId = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voters_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_SelectedCandidate_SelectedCandidateId",
                        column: x => x.SelectedCandidateId,
                        principalTable: "SelectedCandidate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_WalletId",
                table: "Contestants",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestPositions_AppUserId",
                table: "ContestPositions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCandidates_PositionId",
                table: "RegisteredCandidates",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCandidate_AppUserId",
                table: "SelectedCandidate",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedCandidate_ContestantId",
                table: "SelectedCandidate",
                column: "ContestantId");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_AppUserId",
                table: "Setting",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppUserId",
                table: "Transactions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_AppUserId",
                table: "Voters",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_SelectedCandidateId",
                table: "Voters",
                column: "SelectedCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_AppUserId",
                table: "Wallet",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RegisteredCandidates");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ContestPositions");

            migrationBuilder.DropTable(
                name: "SelectedCandidate");

            migrationBuilder.DropTable(
                name: "Contestants");

            migrationBuilder.DropTable(
                name: "Wallet");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
