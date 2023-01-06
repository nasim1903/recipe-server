using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipeserver.Migrations
{
    /// <inheritdoc />
    public partial class newfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_Recipeid",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Recipeid",
                table: "Ingredients",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_Recipeid",
                table: "Ingredients",
                newName: "IX_Ingredients_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Dietary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    vegan = table.Column<bool>(type: "bit", nullable: false),
                    vegetarian = table.Column<bool>(type: "bit", nullable: false),
                    glutenFree = table.Column<bool>(type: "bit", nullable: false),
                    dairyFree = table.Column<bool>(type: "bit", nullable: false),
                    bulking = table.Column<bool>(type: "bit", nullable: false),
                    cutting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietary", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dietary_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalInformation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    ServingSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<int>(type: "int", nullable: true),
                    Fat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sodium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carbohydrates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalInformation", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeId",
                table: "Recipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietary_RecipeId",
                table: "Dietary",
                column: "RecipeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_NutritionalInformation_RecipeId",
                table: "Recipes",
                column: "RecipeId",
                principalTable: "NutritionalInformation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_NutritionalInformation_RecipeId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Dietary");

            migrationBuilder.DropTable(
                name: "NutritionalInformation");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Ingredients",
                newName: "Recipeid");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                newName: "IX_Ingredients_Recipeid");

            migrationBuilder.AlterColumn<int>(
                name: "Recipeid",
                table: "Ingredients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_Recipeid",
                table: "Ingredients",
                column: "Recipeid",
                principalTable: "Recipes",
                principalColumn: "id");
        }
    }
}
