using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class MakeOneToManyAnswerQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TFQuestionId = table.Column<int>(type: "int", nullable: true),
                    MCQQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_MCQQuestions_MCQQuestionId",
                        column: x => x.MCQQuestionId,
                        principalTable: "MCQQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Answers_TFQuestions_TFQuestionId",
                        column: x => x.TFQuestionId,
                        principalTable: "TFQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_MCQQuestionId",
                table: "Answers",
                column: "MCQQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TFQuestionId",
                table: "Answers",
                column: "TFQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
