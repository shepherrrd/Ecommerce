using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Namefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Producer",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "porfilePictureUrl",
                table: "Producer",
                newName: "ProfilePictureURL");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Producer",
                newName: "Bio");

            migrationBuilder.RenameColumn(
                name: "movieCategory",
                table: "Movie",
                newName: "MovieCategory");

            migrationBuilder.RenameColumn(
                name: "porfilePictureUrl",
                table: "Movie",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Movie",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Movie",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Actors",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "porfilePictureUrl",
                table: "Actors",
                newName: "ProfilePictureURL");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Actors",
                newName: "Bio");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Movie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Producer",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureURL",
                table: "Producer",
                newName: "porfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Producer",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "MovieCategory",
                table: "Movie",
                newName: "movieCategory");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movie",
                newName: "porfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Movie",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movie",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Actors",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureURL",
                table: "Actors",
                newName: "porfilePictureUrl");

            migrationBuilder.RenameColumn(
                name: "Bio",
                table: "Actors",
                newName: "Biography");
        }
    }
}
