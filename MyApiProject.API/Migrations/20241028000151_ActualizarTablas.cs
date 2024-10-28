using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApiProject.API.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersHistory_Orders_OrderId",
                table: "OrdersHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersHistory",
                table: "OrdersHistory");

            migrationBuilder.RenameTable(
                name: "OrdersHistory",
                newName: "orderHistories");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersHistory_OrderId",
                table: "orderHistories",
                newName: "IX_orderHistories_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderHistories",
                table: "orderHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHistories_Orders_OrderId",
                table: "orderHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHistories_Orders_OrderId",
                table: "orderHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderHistories",
                table: "orderHistories");

            migrationBuilder.RenameTable(
                name: "orderHistories",
                newName: "OrdersHistory");

            migrationBuilder.RenameIndex(
                name: "IX_orderHistories_OrderId",
                table: "OrdersHistory",
                newName: "IX_OrdersHistory_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersHistory",
                table: "OrdersHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersHistory_Orders_OrderId",
                table: "OrdersHistory",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
