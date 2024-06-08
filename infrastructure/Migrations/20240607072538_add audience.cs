using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addaudience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audience_Students_StudentId",
                table: "Audience");

            migrationBuilder.DropForeignKey(
                name: "FK_Audience_SubjectYears_SubjectYearId",
                table: "Audience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audience",
                table: "Audience");

            migrationBuilder.RenameTable(
                name: "Audience",
                newName: "Audiences");

            migrationBuilder.RenameIndex(
                name: "IX_Audience_SubjectYearId",
                table: "Audiences",
                newName: "IX_Audiences_SubjectYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Audience_StudentId",
                table: "Audiences",
                newName: "IX_Audiences_StudentId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Audiences",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audiences",
                table: "Audiences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Audiences_Students_StudentId",
                table: "Audiences",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audiences_SubjectYears_SubjectYearId",
                table: "Audiences",
                column: "SubjectYearId",
                principalTable: "SubjectYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audiences_Students_StudentId",
                table: "Audiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Audiences_SubjectYears_SubjectYearId",
                table: "Audiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audiences",
                table: "Audiences");

            migrationBuilder.RenameTable(
                name: "Audiences",
                newName: "Audience");

            migrationBuilder.RenameIndex(
                name: "IX_Audiences_SubjectYearId",
                table: "Audience",
                newName: "IX_Audience_SubjectYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Audiences_StudentId",
                table: "Audience",
                newName: "IX_Audience_StudentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Audience",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audience",
                table: "Audience",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Audience_Students_StudentId",
                table: "Audience",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Audience_SubjectYears_SubjectYearId",
                table: "Audience",
                column: "SubjectYearId",
                principalTable: "SubjectYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
