using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N70.Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IsEmailAddressVerified = table.Column<bool>(type: "boolean", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "IsDisabled", "ModifiedTime", "Type" },
                values: new object[,]
                {
                    { new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"), new DateTime(2023, 11, 8, 13, 16, 20, 127, DateTimeKind.Utc).AddTicks(8487), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"), new DateTime(2023, 11, 8, 13, 16, 20, 127, DateTimeKind.Utc).AddTicks(8493), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"), new DateTime(2023, 11, 8, 13, 16, 20, 127, DateTimeKind.Utc).AddTicks(8495), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("cefdf4ea-215b-45cb-8069-40455d1c8336"), "admin", "Admin", true, "Admin", "$2a$11$DjpykDNgRHvY7V5lDo7Wee0vU4t1QIi/QQpVrKy9453t6zC86w74y", new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf") });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Type",
                table: "Roles",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
