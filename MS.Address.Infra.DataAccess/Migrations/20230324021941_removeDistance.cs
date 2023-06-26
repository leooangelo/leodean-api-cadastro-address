using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Address.Infra.DataAccess.Migrations
{
    public partial class removeDistance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Address",
                type: "int",
                maxLength: 15,
                nullable: true);
        }
    }
}
