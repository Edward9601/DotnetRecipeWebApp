using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ImageTableNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseImages_Recipes_RecipeId",
                table: "BaseImages");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseImages_Users_UserId",
                table: "BaseImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseImages",
                table: "BaseImages");

            migrationBuilder.RenameTable(
                name: "BaseImages",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_BaseImages_UserId",
                table: "Images",
                newName: "IX_Images_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseImages_RecipeId",
                table: "Images",
                newName: "IX_Images_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Recipes_RecipeId",
                table: "Images",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Recipes_RecipeId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Users_UserId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "BaseImages");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UserId",
                table: "BaseImages",
                newName: "IX_BaseImages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_RecipeId",
                table: "BaseImages",
                newName: "IX_BaseImages_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseImages",
                table: "BaseImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseImages_Recipes_RecipeId",
                table: "BaseImages",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseImages_Users_UserId",
                table: "BaseImages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
