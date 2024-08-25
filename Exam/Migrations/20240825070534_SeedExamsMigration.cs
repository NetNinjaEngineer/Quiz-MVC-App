using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class SeedExamsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FinalExams",
                columns: new[] { "Id", "Duration", "NumberOfQuestions", "SubjectId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 0, 0, 0), 3, 1 },
                    { 2, new TimeSpan(0, 0, 0, 0, 0), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PracticalExams",
                columns: new[] { "Id", "Duration", "NumberOfQuestions", "SubjectId" },
                values: new object[] { 3, new TimeSpan(0, 0, 0, 0, 0), 2, 6 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinalExams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinalExams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PracticalExams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
