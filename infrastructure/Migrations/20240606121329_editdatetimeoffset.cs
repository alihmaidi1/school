using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editdatetimeoffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBill_Bills_BillId",
                table: "StudentBill");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBill_Students_StudentId",
                table: "StudentBill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBill",
                table: "StudentBill");

            migrationBuilder.RenameTable(
                name: "StudentBill",
                newName: "StudentBills");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBill_StudentId",
                table: "StudentBills",
                newName: "IX_StudentBills_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBill_BillId",
                table: "StudentBills",
                newName: "IX_StudentBills_BillId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Bills",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "StudentBills",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBills",
                table: "StudentBills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBills_Bills_BillId",
                table: "StudentBills",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBills_Students_StudentId",
                table: "StudentBills",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBills_Bills_BillId",
                table: "StudentBills");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBills_Students_StudentId",
                table: "StudentBills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentBills",
                table: "StudentBills");

            migrationBuilder.RenameTable(
                name: "StudentBills",
                newName: "StudentBill");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBills_StudentId",
                table: "StudentBill",
                newName: "IX_StudentBill_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentBills_BillId",
                table: "StudentBill",
                newName: "IX_StudentBill_BillId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StudentBill",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentBill",
                table: "StudentBill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBill_Bills_BillId",
                table: "StudentBill",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBill_Students_StudentId",
                table: "StudentBill",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
