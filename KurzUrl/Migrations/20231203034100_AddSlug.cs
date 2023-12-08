using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurzUrl.Migrations
{
    /// <inheritdoc />
    public partial class AddSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortUrl",
                table: "Urls");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Urls",
                newName: "Slug");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Urls",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ShortUrl",
                table: "Urls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
