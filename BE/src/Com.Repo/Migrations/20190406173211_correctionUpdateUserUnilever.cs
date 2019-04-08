using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Repo.Migrations
{
    public partial class correctionUpdateUserUnilever : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "AddedDate", "ModifiedDate", "UserName" },
                values: new object[] { new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(1959), new DateTime(2019, 4, 7, 1, 32, 11, 66, DateTimeKind.Local).AddTicks(7086), "unilever" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"),
                columns: new[] { "AddedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2019, 4, 7, 1, 30, 36, 376, DateTimeKind.Local).AddTicks(8071), new DateTime(2019, 4, 7, 1, 30, 36, 376, DateTimeKind.Local).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a75c7fe-d6af-4ee3-ba51-06c26b794080"),
                columns: new[] { "AddedDate", "ModifiedDate", "UserName" },
                values: new object[] { new DateTime(2019, 4, 7, 1, 30, 36, 375, DateTimeKind.Local).AddTicks(5867), new DateTime(2019, 4, 7, 1, 30, 36, 376, DateTimeKind.Local).AddTicks(6333), "amer" });
        }
    }
}
