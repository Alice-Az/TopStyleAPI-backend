using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopStyleAPI.Migrations
{
    /// <inheritdoc />
    public partial class changenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderNew_UserNew_UserId",
                table: "OrderNew");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductNew_OrderNew_OrderId",
                table: "OrderProductNew");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductNew_ProductNew_ProductId",
                table: "OrderProductNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNew",
                table: "UserNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductNew",
                table: "ProductNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductNew",
                table: "OrderProductNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderNew",
                table: "OrderNew");

            migrationBuilder.RenameTable(
                name: "UserNew",
                newName: "UsersNew");

            migrationBuilder.RenameTable(
                name: "ProductNew",
                newName: "ProductsNew");

            migrationBuilder.RenameTable(
                name: "OrderProductNew",
                newName: "OrderProductsNew");

            migrationBuilder.RenameTable(
                name: "OrderNew",
                newName: "OrdersNew");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductNew_ProductId",
                table: "OrderProductsNew",
                newName: "IX_OrderProductsNew_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductNew_OrderId",
                table: "OrderProductsNew",
                newName: "IX_OrderProductsNew_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderNew_UserId",
                table: "OrdersNew",
                newName: "IX_OrdersNew_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersNew",
                table: "UsersNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsNew",
                table: "ProductsNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductsNew",
                table: "OrderProductsNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersNew",
                table: "OrdersNew",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductsNew_OrdersNew_OrderId",
                table: "OrderProductsNew",
                column: "OrderId",
                principalTable: "OrdersNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductsNew_ProductsNew_ProductId",
                table: "OrderProductsNew",
                column: "ProductId",
                principalTable: "ProductsNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersNew_UsersNew_UserId",
                table: "OrdersNew",
                column: "UserId",
                principalTable: "UsersNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductsNew_OrdersNew_OrderId",
                table: "OrderProductsNew");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductsNew_ProductsNew_ProductId",
                table: "OrderProductsNew");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersNew_UsersNew_UserId",
                table: "OrdersNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersNew",
                table: "UsersNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsNew",
                table: "ProductsNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersNew",
                table: "OrdersNew");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductsNew",
                table: "OrderProductsNew");

            migrationBuilder.RenameTable(
                name: "UsersNew",
                newName: "UserNew");

            migrationBuilder.RenameTable(
                name: "ProductsNew",
                newName: "ProductNew");

            migrationBuilder.RenameTable(
                name: "OrdersNew",
                newName: "OrderNew");

            migrationBuilder.RenameTable(
                name: "OrderProductsNew",
                newName: "OrderProductNew");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersNew_UserId",
                table: "OrderNew",
                newName: "IX_OrderNew_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductsNew_ProductId",
                table: "OrderProductNew",
                newName: "IX_OrderProductNew_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductsNew_OrderId",
                table: "OrderProductNew",
                newName: "IX_OrderProductNew_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNew",
                table: "UserNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductNew",
                table: "ProductNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderNew",
                table: "OrderNew",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductNew",
                table: "OrderProductNew",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderNew_UserNew_UserId",
                table: "OrderNew",
                column: "UserId",
                principalTable: "UserNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductNew_OrderNew_OrderId",
                table: "OrderProductNew",
                column: "OrderId",
                principalTable: "OrderNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductNew_ProductNew_ProductId",
                table: "OrderProductNew",
                column: "ProductId",
                principalTable: "ProductNew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
