﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica.Migrations
{
    public partial class Sixth_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "DoctorGrade");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Race",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Validation",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "gradeDTO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    DoctorGradeId = table.Column<long>(nullable: true),
                    DoctorGradeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gradeDTO_DoctorGrade_DoctorGradeId",
                        column: x => x.DoctorGradeId,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gradeDTO_DoctorGrade_DoctorGradeId1",
                        column: x => x.DoctorGradeId1,
                        principalTable: "DoctorGrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gradeDTO_DoctorGradeId",
                table: "gradeDTO",
                column: "DoctorGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_gradeDTO_DoctorGradeId1",
                table: "gradeDTO",
                column: "DoctorGradeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gradeDTO");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Race",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Validation",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "User");

            migrationBuilder.AddColumn<double>(
                name: "AverageGrade",
                table: "DoctorGrade",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
