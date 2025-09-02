using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRoute.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDomainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "DeliveryRoute");

            migrationBuilder.DropColumn(
                name: "DestinationIbgeCode",
                table: "DeliveryRoute");

            migrationBuilder.RenameColumn(
                name: "OriginIbgeCode",
                table: "DeliveryRoute",
                newName: "OriginAddress");

            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "DeliveryRoute",
                newName: "DestinationAddress");

            migrationBuilder.AddColumn<double>(
                name: "DestinationLatitude",
                table: "DeliveryRoute",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DestinationLongitude",
                table: "DeliveryRoute",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OriginLatitude",
                table: "DeliveryRoute",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OriginLongitude",
                table: "DeliveryRoute",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationLatitude",
                table: "DeliveryRoute");

            migrationBuilder.DropColumn(
                name: "DestinationLongitude",
                table: "DeliveryRoute");

            migrationBuilder.DropColumn(
                name: "OriginLatitude",
                table: "DeliveryRoute");

            migrationBuilder.DropColumn(
                name: "OriginLongitude",
                table: "DeliveryRoute");

            migrationBuilder.RenameColumn(
                name: "OriginAddress",
                table: "DeliveryRoute",
                newName: "OriginIbgeCode");

            migrationBuilder.RenameColumn(
                name: "DestinationAddress",
                table: "DeliveryRoute",
                newName: "Origin");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "DeliveryRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationIbgeCode",
                table: "DeliveryRoute",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
