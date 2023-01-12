using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipeserver.Migrations
{
    /// <inheritdoc />
    public partial class UserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietary_Recipes_RecipeId",
                table: "Dietary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietary",
                table: "Dietary");

            migrationBuilder.RenameTable(
                name: "Dietary",
                newName: "Dietaries");

            migrationBuilder.RenameIndex(
                name: "IX_Dietary_RecipeId",
                table: "Dietaries",
                newName: "IX_Dietaries_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietaries",
                table: "Dietaries",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Userid",
                table: "Recipes",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Dietaries_Recipes_RecipeId",
                table: "Dietaries",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Users_Userid",
                table: "Recipes",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dietaries_Recipes_RecipeId",
                table: "Dietaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Users_Userid",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_Userid",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dietaries",
                table: "Dietaries");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Dietaries",
                newName: "Dietary");

            migrationBuilder.RenameIndex(
                name: "IX_Dietaries_RecipeId",
                table: "Dietary",
                newName: "IX_Dietary_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dietary",
                table: "Dietary",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dietary_Recipes_RecipeId",
                table: "Dietary",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
