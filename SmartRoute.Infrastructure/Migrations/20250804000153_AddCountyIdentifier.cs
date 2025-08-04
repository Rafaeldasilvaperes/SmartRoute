using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRoute.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCountyIdentifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationIbgeCode",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginIbgeCode",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationIbgeCode",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "OriginIbgeCode",
                table: "Routes");
        }
    }
}
