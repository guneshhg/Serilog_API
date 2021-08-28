using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Membership",
                columns: table => new
                {
                    Membership_Code = table.Column<string>(type: "varchar(6)", nullable: false),
                    Title = table.Column<string>(type: "varchar(10)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Membership", x => x.Membership_Code);
                });

            migrationBuilder.CreateTable(
                name: "T_Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Last_Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Membership_Code = table.Column<string>(type: "varchar(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Customer_T_Membership_Membership_Code",
                        column: x => x.Membership_Code,
                        principalTable: "T_Membership",
                        principalColumn: "Membership_Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Customer_Membership_Code",
                table: "T_Customer",
                column: "Membership_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Customer");

            migrationBuilder.DropTable(
                name: "T_Membership");
        }
    }
}
