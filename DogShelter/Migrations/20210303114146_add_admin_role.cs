using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogShelter.Migrations
{
    public partial class add_admin_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "16634a4a-b509-4328-b0c3-01ef18d71bec", "2e0c087b-5d29-44dc-b8b9-5e91ecc3be30", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "394b2c07-cca0-426f-a67a-070300aa653e", 0, "232d8373-9526-4f01-9189-9a21b8dbabb8", null, true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAECkB/sx0nMgYJZyGGlBmph6/Y66B06PpVzArC3781mrB1/kFBvdHpf+/i3wbN8XTrg==", null, false, "2f5380ac-141c-4f42-a893-ac8bf0130ba5", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "16634a4a-b509-4328-b0c3-01ef18d71bec", "394b2c07-cca0-426f-a67a-070300aa653e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "16634a4a-b509-4328-b0c3-01ef18d71bec", "394b2c07-cca0-426f-a67a-070300aa653e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16634a4a-b509-4328-b0c3-01ef18d71bec");
        }
    }
}
