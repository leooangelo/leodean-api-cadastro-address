using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Address.Infra.DataAccess.Migrations
{
    public partial class ajuste_colunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstablishmentId",
                table: "Address",
                newName: "EstablishmentID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Address",
                newName: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstablishmentID",
                table: "Address",
                newName: "EstablishmentId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Address",
                newName: "CustomerId");
        }
    }
}
