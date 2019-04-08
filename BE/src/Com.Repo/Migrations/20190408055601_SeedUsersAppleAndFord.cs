using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Repo.Migrations
{
    public partial class SeedUsersAppleAndFord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddedDate", "AddressLine1", "AddressLine2", "BelongsTo", "City", "Country", "Creator", "ModifiedDate", "Modifier", "State", "Type" },
                values: new object[,]
                {
                    { new Guid("cb0d0279-7007-4c10-82ca-ce315e7273c9"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Something here", "Something there", new Guid("0a82bc85-362a-4184-bd45-3ec58bef120d"), "Putra Jaya", "Malaysia", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Selangor", (short)2 },
                    { new Guid("15328f3a-ec7c-4c7d-884b-52f06b6e47d6"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Something here", "Something there", new Guid("7d1bd9ec-1461-4c78-93a1-f8ee6adade97"), "Putra Jaya", "Malaysia", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Selangor", (short)2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"),
                columns: new[] { "AddedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7978), new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7981) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a75c7fe-d6af-4ee3-ba51-06c26b794080"),
                columns: new[] { "AddedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(2043), new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddedDate", "Creator", "Email", "FirstName", "LastName", "ModifiedDate", "Modifier", "Password", "Type", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a82bc85-362a-4184-bd45-3ec58bef120d"), new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7727), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "apple@yahoo.com", "Apple", "", new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7731), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ", (short)2, "apple" },
                    { new Guid("7d1bd9ec-1461-4c78-93a1-f8ee6adade97"), new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7741), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "ford@yahoo.com", "Ford", "", new DateTime(2019, 4, 8, 13, 56, 0, 975, DateTimeKind.Local).AddTicks(7741), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ", (short)2, "ford" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_Code",
                table: "Ads",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_Code",
                table: "Ads");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("15328f3a-ec7c-4c7d-884b-52f06b6e47d6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("cb0d0279-7007-4c10-82ca-ce315e7273c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a82bc85-362a-4184-bd45-3ec58bef120d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d1bd9ec-1461-4c78-93a1-f8ee6adade97"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"),
                columns: new[] { "AddedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(8775), new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(8782) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a75c7fe-d6af-4ee3-ba51-06c26b794080"),
                columns: new[] { "AddedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(1959), new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(7086) });
        }
    }
}
