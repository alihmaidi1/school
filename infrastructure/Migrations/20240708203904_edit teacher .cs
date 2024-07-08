using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editteacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectYears_TeacherSubjects_TeacherSubjectId",
                table: "SubjectYears");

            migrationBuilder.RenameColumn(
                name: "TeacherSubjectId",
                table: "SubjectYears",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectYears_TeacherSubjectId",
                table: "SubjectYears",
                newName: "IX_SubjectYears_SubjectId");

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
                name: "FK_SubjectYears_Accounts_TeacherId",
                table: "SubjectYears",
                column: "TeacherId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectYears_Subjects_SubjectId",
                table: "SubjectYears",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectYears_Accounts_TeacherId",
                table: "SubjectYears");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectYears_Subjects_SubjectId",
                table: "SubjectYears");

            migrationBuilder.DropIndex(
                name: "IX_SubjectYears_TeacherId",
                table: "SubjectYears");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SubjectYears");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectYears",
                newName: "TeacherSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectYears_SubjectId",
                table: "SubjectYears",
                newName: "IX_SubjectYears_TeacherSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectYears_TeacherSubjects_TeacherSubjectId",
                table: "SubjectYears",
                column: "TeacherSubjectId",
                principalTable: "TeacherSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
