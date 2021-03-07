using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodosService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    UserFK = table.Column<string>(nullable: true),
                    ParentTodoListFK = table.Column<string>(nullable: true),
                    CompletedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserFK = table.Column<string>(nullable: true),
                    CompletedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    TodoListId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedUsers", x => new { x.UserId, x.TodoListId });
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_TodoLists_TodoListId",
                        column: x => x.TodoListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Password", "PhoneNo", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { "f542d1a5-5e0d-48c0-8d21-2a33afa76ad1", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(7386), new TimeSpan(0, 0, 0, 0, 0)), null, "test1", "12345678", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(7400), new TimeSpan(0, 0, 0, 0, 0)), "test1" },
                    { "0db8035f-f5a2-4fe2-89a2-e918363a0e2c", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8952), new TimeSpan(0, 0, 0, 0, 0)), null, "test2", "12345678", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8954), new TimeSpan(0, 0, 0, 0, 0)), "test2" },
                    { "4ecc4884-3f1b-4340-9e2b-ec5b9de100c7", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(8999), new TimeSpan(0, 0, 0, 0, 0)), null, "test3", "12345678", new DateTimeOffset(new DateTime(2021, 3, 5, 4, 16, 59, 288, DateTimeKind.Unspecified).AddTicks(9001), new TimeSpan(0, 0, 0, 0, 0)), "test3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscribedUsers_TodoListId",
                table: "SubscribedUsers",
                column: "TodoListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SubscribedUsers");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
