using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.Haxx.EntityFramework.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "DateTime", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 1, ".NET", new DateTime(2023, 8, 20, 15, 39, 28, 827, DateTimeKind.Local).AddTicks(4817), "This is my first session.", true, null, "Allround .NET" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "DateTime", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 2, "Java", new DateTime(2023, 8, 28, 15, 39, 28, 827, DateTimeKind.Local).AddTicks(5898), "This is my second session.", true, null, "Java, no way!" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "DateTime", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 3, ".NET", new DateTime(2023, 8, 23, 15, 39, 28, 827, DateTimeKind.Local).AddTicks(5919), "This is my third session.", false, null, "VS Code tutorial!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "DateTime", "SessionId", "Text" },
                values: new object[] { 1, null, new DateTime(2023, 8, 25, 15, 39, 28, 829, DateTimeKind.Local).AddTicks(903), 1, "Well done!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "DateTime", "SessionId", "Text" },
                values: new object[] { 2, null, new DateTime(2023, 8, 25, 15, 39, 28, 829, DateTimeKind.Local).AddTicks(1954), 2, "Super!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
