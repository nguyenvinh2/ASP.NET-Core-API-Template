using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoLists",
                columns: new[] { "ListID", "ListName" },
                values: new object[] { 1, "Dummy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoLists",
                keyColumn: "ListID",
                keyValue: 1);
        }
    }
}
