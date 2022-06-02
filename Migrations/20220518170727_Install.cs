using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace WebAppCar1.Migrations
{
    public partial class Install : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    car_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    car_Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    car_Plate = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    car_ImageUrl = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    person_ID = table.Column<int>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.car_ID);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    person_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    person_FName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    person_LName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    person_Phone = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.person_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
