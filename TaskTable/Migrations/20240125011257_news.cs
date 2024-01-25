using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTable.Migrations
{
    public partial class news : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_Statuses_StatusId",
                table: "MyTasks");

            migrationBuilder.DropIndex(
                name: "IX_MyTasks_StatusId",
                table: "MyTasks");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { 1, "Создана" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { 2, "В работе" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { 3, "Завершена" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_StatusId",
                table: "MyTasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_Statuses_StatusId",
                table: "MyTasks",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
