using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatequez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_StudentQuezs_QuezId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuezs_Quez_QuezId",
                table: "StudentQuezs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quez",
                table: "Quez");

            migrationBuilder.RenameTable(
                name: "Quez",
                newName: "Quezs");

            migrationBuilder.RenameIndex(
                name: "IX_Quez_DateDeleted",
                table: "Quezs",
                newName: "IX_Quezs_DateDeleted");

            migrationBuilder.AddColumn<float>(
                name: "Degree",
                table: "Subjects",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinDegree",
                table: "Subjects",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Score",
                table: "Questions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quezs",
                table: "Quezs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quezs_QuezId",
                table: "Questions",
                column: "QuezId",
                principalTable: "Quezs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuezs_Quezs_QuezId",
                table: "StudentQuezs",
                column: "QuezId",
                principalTable: "Quezs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quezs_QuezId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuezs_Quezs_QuezId",
                table: "StudentQuezs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quezs",
                table: "Quezs");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "MinDegree",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Quezs",
                newName: "Quez");

            migrationBuilder.RenameIndex(
                name: "IX_Quezs_DateDeleted",
                table: "Quez",
                newName: "IX_Quez_DateDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quez",
                table: "Quez",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_StudentQuezs_QuezId",
                table: "Questions",
                column: "QuezId",
                principalTable: "StudentQuezs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuezs_Quez_QuezId",
                table: "StudentQuezs",
                column: "QuezId",
                principalTable: "Quez",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
