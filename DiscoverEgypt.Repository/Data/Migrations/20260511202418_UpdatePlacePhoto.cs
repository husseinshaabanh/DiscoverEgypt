using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscoverEgypt.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlacePhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacePhoto_Places_PlaceId",
                table: "PlacePhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacePhoto",
                table: "PlacePhoto");

            migrationBuilder.RenameTable(
                name: "PlacePhoto",
                newName: "PlacePhotos");

            migrationBuilder.RenameIndex(
                name: "IX_PlacePhoto_PlaceId",
                table: "PlacePhotos",
                newName: "IX_PlacePhotos_PlaceId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "PlacePhotos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacePhotos",
                table: "PlacePhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacePhotos_Places_PlaceId",
                table: "PlacePhotos",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacePhotos_Places_PlaceId",
                table: "PlacePhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacePhotos",
                table: "PlacePhotos");

            migrationBuilder.RenameTable(
                name: "PlacePhotos",
                newName: "PlacePhoto");

            migrationBuilder.RenameIndex(
                name: "IX_PlacePhotos_PlaceId",
                table: "PlacePhoto",
                newName: "IX_PlacePhoto_PlaceId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "PlacePhoto",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacePhoto",
                table: "PlacePhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacePhoto_Places_PlaceId",
                table: "PlacePhoto",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
