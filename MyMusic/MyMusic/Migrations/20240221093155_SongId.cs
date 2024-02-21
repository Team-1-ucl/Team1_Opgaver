using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMusic.Migrations
{
    public partial class SongId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Album_AlbumsAlbumId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsArtistId",
                table: "AlbumArtist");

            migrationBuilder.RenameColumn(
                name: "SongId",
                table: "Song",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreAlbumId",
                table: "GenreAlbum",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artist",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArtistsArtistId",
                table: "AlbumArtist",
                newName: "ArtistsId");

            migrationBuilder.RenameColumn(
                name: "AlbumsAlbumId",
                table: "AlbumArtist",
                newName: "AlbumsId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumArtist_ArtistsArtistId",
                table: "AlbumArtist",
                newName: "IX_AlbumArtist_ArtistsId");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Album",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Album_AlbumsId",
                table: "AlbumArtist",
                column: "AlbumsId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsId",
                table: "AlbumArtist",
                column: "ArtistsId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Album_AlbumsId",
                table: "AlbumArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsId",
                table: "AlbumArtist");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Song",
                newName: "SongId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GenreAlbum",
                newName: "GenreAlbumId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Artist",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "ArtistsId",
                table: "AlbumArtist",
                newName: "ArtistsArtistId");

            migrationBuilder.RenameColumn(
                name: "AlbumsId",
                table: "AlbumArtist",
                newName: "AlbumsAlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumArtist_ArtistsId",
                table: "AlbumArtist",
                newName: "IX_AlbumArtist_ArtistsArtistId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Album",
                newName: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Album_AlbumsAlbumId",
                table: "AlbumArtist",
                column: "AlbumsAlbumId",
                principalTable: "Album",
                principalColumn: "AlbumId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumArtist_Artist_ArtistsArtistId",
                table: "AlbumArtist",
                column: "ArtistsArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
