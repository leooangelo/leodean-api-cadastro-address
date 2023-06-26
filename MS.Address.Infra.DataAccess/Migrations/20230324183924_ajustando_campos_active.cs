using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Address.Infra.DataAccess.Migrations
{
    public partial class ajustando_campos_active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Address");
        }
    }
}
