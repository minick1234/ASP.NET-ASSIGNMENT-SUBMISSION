using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DZ_LAB1.Migrations
{
    /// <inheritdoc />
    public partial class Assignment_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckWorkshop",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrderCost = table.Column<float>(type: "real", nullable: false),
                    TruckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckWorkshop", x => x.WorkOrderID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckWorkshop");
        }
    }
}
