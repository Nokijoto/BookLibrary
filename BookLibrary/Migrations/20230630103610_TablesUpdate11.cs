using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class TablesUpdate11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_genres");

            migrationBuilder.DropTable(
                name: "books_series");

            migrationBuilder.DropTable(
                name: "series_authors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.RenameIndex(
                name: "book_id2",
                table: "book_shelfs",
                newName: "book_id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "book_id1",
                table: "book_shelfs",
                newName: "book_id2");

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    parent_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.genre_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    published_date = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    serie_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    series_uuid = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series", x => x.series_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "book_genres",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int(11)", nullable: false),
                    genre_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_genres", x => new { x.book_id, x.genre_id });
                    table.ForeignKey(
                        name: "FK_BookGenres_Books",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK_BookGenres_Genres",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "genre_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "books_series",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int(11)", nullable: false),
                    series_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books_series", x => new { x.book_id, x.series_id });
                    table.ForeignKey(
                        name: "FK_BooksSeries_Books",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK_BooksSeries_Series",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "series_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "series_authors",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "int(11)", nullable: false),
                    author_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_authors", x => new { x.series_id, x.author_id });
                    table.ForeignKey(
                        name: "FK_SeriesAuthors_Authors",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_SeriesAuthors_Series",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "series_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "book_id1",
                table: "book_genres",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "genre_id",
                table: "book_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "book_id3",
                table: "books_series",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "series_id",
                table: "books_series",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "author_id1",
                table: "series_authors",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "series_id1",
                table: "series_authors",
                column: "series_id");
        }
    }
}
