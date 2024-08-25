using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuestionsAndAnswersMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MCQQuestions",
                columns: new[] { "Id", "Body", "FinalExamId", "Mark", "PracticalExamId" },
                values: new object[,]
                {
                    { 1, "What is the correct syntax to output 'Hello World' in C#?", 1, 2, null },
                    { 2, "Which of the following is NOT an access modifier in C#?", 2, 2, null },
                    { 3, "Which of the following is a Python tuple?", null, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "TFQuestions",
                columns: new[] { "Id", "Body", "FinalExamId", "Mark", "PracticalExamId" },
                values: new object[,]
                {
                    { 4, "C# is a statically-typed language.", 1, 1, null },
                    { 5, "C# supports multiple inheritance.", 2, 1, null },
                    { 6, "Python uses indentation to define code blocks.", null, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Correct", "MCQQuestionId", "TFQuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, null, "Console.WriteLine('Hello World');" },
                    { 2, false, 1, null, "System.out.println('Hello World');" },
                    { 3, false, 1, null, "echo('Hello World');" },
                    { 4, true, null, 4, "True" },
                    { 5, false, null, 4, "False" },
                    { 6, false, 2, null, "public" },
                    { 7, false, 2, null, "private" },
                    { 8, false, 2, null, "protected" },
                    { 9, true, 2, null, "internalize" },
                    { 10, false, null, 5, "True" },
                    { 11, true, null, 5, "False" },
                    { 12, true, 3, null, "(1, 2, 3)" },
                    { 13, false, 3, null, "[1, 2, 3]" },
                    { 14, false, 3, null, "{1, 2, 3}" },
                    { 15, true, null, 6, "True" },
                    { 16, false, null, 6, "False" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MCQQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MCQQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MCQQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TFQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TFQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TFQuestions",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
