using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MS.Address.Infra.DataAccess.Migrations
{
    public partial class coluna_CustomerID_EstabelecimentoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "EstablishmentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "EstablishmentId",
                table: "Address");
        }
    }
}
