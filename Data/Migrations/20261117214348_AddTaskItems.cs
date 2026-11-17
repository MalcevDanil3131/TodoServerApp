using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoServerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedDate", "Description", "FinishDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи 1", null, "Задача 1" },
                    { 2, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи 2", null, "Задача 2" },
                    { 3, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи 3", null, "Задача 3" },
                    { 4, new DateTime(2024, 8, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи 4", null, "Задача 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
