using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class Create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritesListId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoritesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoritesList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FavoritesListId",
                table: "Product",
                column: "FavoritesListId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesList_UserId",
                table: "FavoritesList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_FavoritesList_FavoritesListId",
                table: "Product",
                column: "FavoritesListId",
                principalTable: "FavoritesList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Orders_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_FavoritesList_FavoritesListId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Orders_OrderId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "FavoritesList");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Product_FavoritesListId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FavoritesListId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Product");
        }
    }
}
