using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HJKHJLK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_ArtistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Musics");

            migrationBuilder.CreateTable(
                name: "ArtistMusics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistMusics_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMusics_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusics_ArtistId",
                table: "ArtistMusics",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusics_MusicId",
                table: "ArtistMusics",
                column: "MusicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistMusics");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Musics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_ArtistId",
                table: "Musics",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Artists_ArtistId",
                table: "Musics",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
