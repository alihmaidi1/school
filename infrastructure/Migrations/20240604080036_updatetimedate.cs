using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetimedate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuezs_StudentSubjects_StudentSubjectId",
                table: "StudentQuezs");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectYears_Accounts_TeacherId",
                table: "SubjectYears");

            migrationBuilder.DropIndex(
                name: "IX_SubjectYears_TeacherId",
                table: "SubjectYears");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SubjectYears");

            migrationBuilder.RenameColumn(
                name: "StudentSubjectId",
                table: "StudentQuezs",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuezs_StudentSubjectId",
                table: "StudentQuezs",
                newName: "IX_StudentQuezs_StudentId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Years",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectYearId",
                table: "Quezs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Quezs_SubjectYearId",
                table: "Quezs",
                column: "SubjectYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quezs_SubjectYears_SubjectYearId",
                table: "Quezs",
                column: "SubjectYearId",
                principalTable: "SubjectYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuezs_Students_StudentId",
                table: "StudentQuezs",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quezs_SubjectYears_SubjectYearId",
                table: "Quezs");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuezs_Students_StudentId",
                table: "StudentQuezs");

            migrationBuilder.DropIndex(
                name: "IX_Quezs_SubjectYearId",
                table: "Quezs");

            migrationBuilder.DropColumn(
                name: "SubjectYearId",
                table: "Quezs");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentQuezs",
                newName: "StudentSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentQuezs_StudentId",
                table: "StudentQuezs",
                newName: "IX_StudentQuezs_StudentSubjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Years",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "SubjectYears",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectYears_TeacherId",
                table: "SubjectYears",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuezs_StudentSubjects_StudentSubjectId",
                table: "StudentQuezs",
                column: "StudentSubjectId",
                principalTable: "StudentSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectYears_Accounts_TeacherId",
                table: "SubjectYears",
                column: "TeacherId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
