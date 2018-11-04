using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoList_ListID",
                table: "ToDoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList");

            migrationBuilder.RenameTable(
                name: "ToDoList",
                newName: "ToDoLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists",
                column: "ListID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoLists_ListID",
                table: "ToDoItems",
                column: "ListID",
                principalTable: "ToDoLists",
                principalColumn: "ListID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_ToDoLists_ListID",
                table: "ToDoItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoLists",
                table: "ToDoLists");

            migrationBuilder.RenameTable(
                name: "ToDoLists",
                newName: "ToDoList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoList",
                table: "ToDoList",
                column: "ListID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_ToDoList_ListID",
                table: "ToDoItems",
                column: "ListID",
                principalTable: "ToDoList",
                principalColumn: "ListID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
