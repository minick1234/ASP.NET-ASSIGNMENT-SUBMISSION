using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DZ_LAB1.Migrations
{
    /// <inheritdoc />
    public partial class Assignment_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    routeNumber = table.Column<int>(type: "int", nullable: false),
                    routeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    routeLength = table.Column<float>(type: "real", nullable: false),
                    routePayPerKM = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    truckNum = table.Column<int>(type: "int", nullable: false),
                    truckModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truckMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    truckRouteNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _ConfirmationPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
