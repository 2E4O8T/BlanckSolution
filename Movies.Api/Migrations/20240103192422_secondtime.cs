using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Api.Migrations
{
    public partial class secondtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Favorite",
                table: "Movies",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movies",
                newName: "Genre");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Movies",
                newName: "Favorite");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Movies",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
