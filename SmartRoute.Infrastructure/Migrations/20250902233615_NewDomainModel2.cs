using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRoute.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDomainModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DeliveryRoute");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "DeliveryRoute",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "CreatedAt",
                table: "DeliveryRoute",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "DeliveryRoute");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DeliveryRoute");
        }
    }
}
