using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistoryQuizApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLessonExamRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_LessonId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Exams_LessonId",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId",
                unique: true);
        }
    }
}
