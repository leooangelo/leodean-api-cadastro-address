using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Address.Infra.DataAccess.Migrations
{
    public partial class InitialAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Street = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Complement = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Distance = table.Column<int>(type: "int", maxLength: 15, nullable: true),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
