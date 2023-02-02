using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EsplanadeEventBooking.Server.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "0a52cfad-a937-4281-affe-9cdd5f0f545b", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "dcdd97b5-bc66-4662-895f-c9bffc734d85", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "2c97571f-8ee6-4caa-863f-006611060b96", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAELOHD+ebf2rv0MbmjOyJFJEKQ4i8sUC44TsjLwWsEcDDkNTRzwETRPiyiRaXLJBfjw==", null, false, "c7c6ab54-e805-4809-9b60-75700b8d8d27", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Eusers",
                columns: new[] { "Id", "Age", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[] { 1, 20, "System", new DateTime(2023, 2, 3, 5, 15, 14, 692, DateTimeKind.Local).AddTicks(3062), new DateTime(2023, 2, 3, 5, 15, 14, 692, DateTimeKind.Local).AddTicks(9991), "Adam", "System" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedBy", "CreatorId", "DateCreated", "DateUpdated", "EndDate", "Location", "StartDate", "TicketId", "Title", "UpdatedBy" },
                values: new object[] { 1, "System", 1, new DateTime(2023, 2, 3, 5, 15, 14, 693, DateTimeKind.Local).AddTicks(3710), new DateTime(2023, 2, 3, 5, 15, 14, 693, DateTimeKind.Local).AddTicks(3713), new DateTime(2023, 2, 3, 5, 15, 14, 693, DateTimeKind.Local).AddTicks(3426), "Theatre", new DateTime(2023, 2, 3, 5, 15, 14, 693, DateTimeKind.Local).AddTicks(3245), null, "TwoSet vs Davie Concert", "System" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.DeleteData(
                table: "Eusers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
