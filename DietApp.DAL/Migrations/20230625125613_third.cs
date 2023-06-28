using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietApp.DAL.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Calorie = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealsFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portion = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealsFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealsFoods_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealsFoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreateOn", "IsActive", "UpdateOn" },
                values: new object[,]
                {
                    { 1, "Süt Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6588), true, null },
                    { 2, "Et Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6591), true, null },
                    { 3, "KuruBaklagil Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6592), true, null },
                    { 4, "Ekmek Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6593), true, null },
                    { 5, "Sebze Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6593), true, null },
                    { 6, "Meyve Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6594), true, null },
                    { 7, "Yağ Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6594), true, null },
                    { 8, "Tatlı Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6595), true, null },
                    { 9, "Kuruyemiş Grubu", new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(6596), true, null }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreateOn", "IsActive", "MealName", "UpdateOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(5296), true, "Kahvaltı", null },
                    { 2, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(5299), true, "Öğle Yemeği", null },
                    { 3, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(5300), true, "Akşam Yemeği", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateOn", "Email", "IsActive", "Password", "UpdateOn", "UserName", "UserTypes" },
                values: new object[] { 1, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(3870), "admin@gmail.com", true, "123456", null, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calorie", "CategoryId", "CreateOn", "Description", "FoodName", "IsActive", "UpdateOn" },
                values: new object[,]
                {
                    { 1, 11400.0, 1, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8264), "1 su bardağı,200 ml", "Süt", true, null },
                    { 2, 69000.0, 2, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8267), "1 köfte, 30gr", "Kıyma", true, null },
                    { 3, 80000.0, 3, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8267), "4 yemek kaşığı, 25gr", "Mercimek", true, null },
                    { 4, 68000.0, 4, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8268), "3 yemek kaşığı, 50gr", "Makarna", true, null },
                    { 5, 25000.0, 5, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8272), "4 yemek kaşığı, 200gr", "Brokoli(Pişmiş)", true, null },
                    { 6, 60000.0, 6, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8273), "1 küçük boy, 120gr", "Elma", true, null },
                    { 7, 45000.0, 7, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8274), "1 tatlı kaşığı, 5gr", "Tereyağ", true, null },
                    { 8, 68000.0, 8, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8275), "1 yemek kaşığı, 30gr", "Bal", true, null },
                    { 9, 45000.0, 9, new DateTime(2023, 6, 25, 15, 56, 13, 84, DateTimeKind.Local).AddTicks(8303), "2 adet, 8gr", "Ceviz içi", true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodName",
                table: "Foods",
                column: "FoodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealName",
                table: "Meals",
                column: "MealName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealsFoods_FoodId",
                table: "MealsFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsFoods_MealId",
                table: "MealsFoods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsFoods_UserId",
                table: "MealsFoods",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealsFoods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
