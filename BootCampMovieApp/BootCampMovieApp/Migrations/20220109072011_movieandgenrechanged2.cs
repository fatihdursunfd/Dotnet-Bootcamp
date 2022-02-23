using Microsoft.EntityFrameworkCore.Migrations;

namespace BootCampMovieApp.Migrations
{
    public partial class movieandgenrechanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genre_GenreListGenreId",
                table: "GenreMovie");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "GenreListGenreId",
                table: "GenreMovie",
                newName: "GenresGenreId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genre_GenresGenreId",
                table: "GenreMovie",
                column: "GenresGenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovie_Genre_GenresGenreId",
                table: "GenreMovie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GenreMovie",
                newName: "GenreListGenreId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovie_Genre_GenreListGenreId",
                table: "GenreMovie",
                column: "GenreListGenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
