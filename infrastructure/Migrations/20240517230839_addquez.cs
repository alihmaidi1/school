using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addquez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "StudentQuezs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudentQuezs");

            migrationBuilder.DropColumn(
                name: "StartAt",
                table: "StudentQuezs");

            migrationBuilder.AddColumn<Guid>(
                name: "QuezId",
                table: "StudentQuezs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Quez",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quez", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Years_DateDeleted",
                table: "Years",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_DateDeleted",
                table: "Warnings",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_DateDeleted",
                table: "Vacations",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectYears_DateDeleted",
                table: "SubjectYears",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DateDeleted",
                table: "Subjects",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_DateDeleted",
                table: "StudentSubjects",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuezs_DateDeleted",
                table: "StudentQuezs",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuezs_QuezId",
                table: "StudentQuezs",
                column: "QuezId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_DateDeleted",
                table: "Stages",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DateDeleted",
                table: "Questions",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DateDeleted",
                table: "Classes",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_DateDeleted",
                table: "Answers",
                column: "DateDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Quez_DateDeleted",
                table: "Quez",
                column: "DateDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuezs_Quez_QuezId",
                table: "StudentQuezs",
                column: "QuezId",
                principalTable: "Quez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuezs_Quez_QuezId",
                table: "StudentQuezs");

            migrationBuilder.DropTable(
                name: "Quez");

            migrationBuilder.DropIndex(
                name: "IX_Years_DateDeleted",
                table: "Years");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_DateDeleted",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_DateDeleted",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_SubjectYears_DateDeleted",
                table: "SubjectYears");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_DateDeleted",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_DateDeleted",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuezs_DateDeleted",
                table: "StudentQuezs");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuezs_QuezId",
                table: "StudentQuezs");

            migrationBuilder.DropIndex(
                name: "IX_Stages_DateDeleted",
                table: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DateDeleted",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Classes_DateDeleted",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Answers_DateDeleted",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuezId",
                table: "StudentQuezs");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "StudentQuezs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudentQuezs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartAt",
                table: "StudentQuezs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
