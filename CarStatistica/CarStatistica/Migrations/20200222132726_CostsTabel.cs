using Microsoft.EntityFrameworkCore.Migrations;

namespace CarStatistica.Migrations
{
    public partial class CostsTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostsId",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CostsId",
                table: "Cars",
                column: "CostsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Costs_CostsId",
                table: "Cars",
                column: "CostsId",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Costs_CostsId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CostsId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CostsId",
                table: "Cars");
        }
    }
}
