using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ExamSequence");

            migrationBuilder.CreateSequence(
                name: "QuestionSequence");

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ExamSequence]"),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalExams_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PracticalExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ExamSequence]"),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticalExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PracticalExams_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MCQQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [QuestionSequence]"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    PracticalExamId = table.Column<int>(type: "int", nullable: true),
                    FinalExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCQQuestions_FinalExams_FinalExamId",
                        column: x => x.FinalExamId,
                        principalTable: "FinalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MCQQuestions_PracticalExams_PracticalExamId",
                        column: x => x.PracticalExamId,
                        principalTable: "PracticalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TFQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [QuestionSequence]"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    PracticalExamId = table.Column<int>(type: "int", nullable: true),
                    FinalExamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TFQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TFQuestions_FinalExams_FinalExamId",
                        column: x => x.FinalExamId,
                        principalTable: "FinalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TFQuestions_PracticalExams_PracticalExamId",
                        column: x => x.PracticalExamId,
                        principalTable: "PracticalExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_SubjectId",
                table: "FinalExams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQQuestions_FinalExamId",
                table: "MCQQuestions",
                column: "FinalExamId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQQuestions_PracticalExamId",
                table: "MCQQuestions",
                column: "PracticalExamId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticalExams_SubjectId",
                table: "PracticalExams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TFQuestions_FinalExamId",
                table: "TFQuestions",
                column: "FinalExamId");

            migrationBuilder.CreateIndex(
                name: "IX_TFQuestions_PracticalExamId",
                table: "TFQuestions",
                column: "PracticalExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MCQQuestions");

            migrationBuilder.DropTable(
                name: "TFQuestions");

            migrationBuilder.DropTable(
                name: "FinalExams");

            migrationBuilder.DropTable(
                name: "PracticalExams");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropSequence(
                name: "ExamSequence");

            migrationBuilder.DropSequence(
                name: "QuestionSequence");
        }
    }
}
