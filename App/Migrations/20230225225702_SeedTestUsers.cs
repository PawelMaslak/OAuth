using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordTestString",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "PasswordTestString", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, new byte[] { 20, 177, 150, 13, 74, 33, 76, 163, 180, 94, 55, 149, 71, 141, 138, 108, 131, 1, 140, 125, 76, 229, 140, 14, 101, 108, 152, 50, 40, 209, 187, 187 }, new byte[] { 135, 174, 196, 68, 234, 27, 64, 98, 253, 1, 58, 195, 199, 77, 0, 30, 155, 108, 48, 175, 46, 9, 120, 175, 3, 174, 46, 78, 192, 154, 242, 124, 67, 130, 138, 176, 105, 201, 191, 67, 13, 139, 56, 74, 211, 231, 255, 251, 223, 144, 169, 53, 195, 156, 33, 200, 170, 63, 249, 35, 182, 154, 118, 145 }, "AdminPassword", 1, "Admin" },
                    { 2, new byte[] { 30, 111, 158, 170, 143, 10, 195, 219, 44, 173, 168, 175, 222, 0, 202, 47, 73, 113, 214, 108, 163, 248, 255, 226, 155, 41, 227, 87, 30, 177, 104, 50 }, new byte[] { 70, 75, 208, 191, 67, 133, 60, 170, 63, 217, 109, 153, 173, 18, 110, 164, 146, 194, 53, 2, 12, 224, 202, 231, 136, 191, 233, 213, 104, 244, 83, 11, 109, 23, 94, 28, 86, 202, 176, 70, 248, 23, 14, 107, 128, 116, 137, 31, 23, 32, 229, 39, 239, 118, 139, 88, 94, 133, 180, 1, 230, 172, 5, 252 }, "UserPassword", 2, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PasswordTestString",
                table: "Users");
        }
    }
}
