using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Com.Repo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<Guid>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    BelongsTo = table.Column<Guid>(nullable: false),
                    Type = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<Guid>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 240, nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Creator = table.Column<Guid>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    Password = table.Column<string>(maxLength: 240, nullable: false),
                    Type = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AddressTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Conference" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddedDate", "AddressLine1", "AddressLine2", "BelongsTo", "City", "Country", "Creator", "ModifiedDate", "Modifier", "State", "Type" },
                values: new object[] { new Guid("3b4ae92f-0be3-4fb6-9177-c50686c748b7"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Something here", "Something there", new Guid("8a75c7fe-d6af-4ee3-ba51-06c26b794080"), "Putra Jaya", "Malaysia", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Selangor", (short)2 });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "AddedDate", "Code", "Creator", "Description", "ModifiedDate", "Modifier", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ce59a858-d20e-4d7b-8207-23b912190181"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "classic", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Offers the most basic level of advertisement", new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Classic Ad", 269.99000000000001 },
                    { new Guid("42b323f6-4b1f-449e-894d-3ee3c181fbf9"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "standout", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Allows advertisers to use a company logo and use a longer presentation text", new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Standout Ad", 322.99000000000001 },
                    { new Guid("88d45054-b3f7-4c64-aaaa-00cc6f063ed0"), new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "premium", new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", new DateTime(2019, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "Premium Ad", 394.99000000000001 }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddedDate", "Creator", "Email", "FirstName", "LastName", "ModifiedDate", "Modifier", "Password", "Type", "UserName" },
                values: new object[,]
                {
                    { new Guid("8a75c7fe-d6af-4ee3-ba51-06c26b794080"), new DateTime(2019, 4, 6, 14, 57, 37, 660, DateTimeKind.Local).AddTicks(7563), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "alsaket@yahoo.com", "Amer", "Ali", new DateTime(2019, 4, 6, 14, 57, 37, 661, DateTimeKind.Local).AddTicks(2630), new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ", (short)2, "amer" },
                    { new Guid("45e231ce-1a79-4289-9fe6-b89b66ef9d5f"), new DateTime(2019, 4, 6, 14, 57, 37, 661, DateTimeKind.Local).AddTicks(4350), new Guid("00000000-0000-0000-0000-000000000000"), "admin@yahoo.com", "Super", "Admin", new DateTime(2019, 4, 6, 14, 57, 37, 661, DateTimeKind.Local).AddTicks(4361), new Guid("00000000-0000-0000-0000-000000000000"), "$MYHASH$V1$10000$xcFsnGmPpBute45y3p6bGanZvI3JLuPRJGUZopaGHu1mMrPQ", (short)1, "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BelongsTo_Type",
                table: "Addresses",
                columns: new[] { "BelongsTo", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
