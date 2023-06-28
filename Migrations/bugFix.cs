using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class bugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalZookeeper_Animals_AnimalsAnimalId",
                table: "AnimalZookeeper");

            migrationBuilder.RenameColumn(
                name: "AnimalsAnimalId",
                table: "AnimalZookeeper",
                newName: "AnimalsId");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Animals",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalZookeeper_Animals_AnimalsId",
                table: "AnimalZookeeper",
                column: "AnimalsId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalZookeeper_Animals_AnimalsId",
                table: "AnimalZookeeper");

            migrationBuilder.RenameColumn(
                name: "AnimalsId",
                table: "AnimalZookeeper",
                newName: "AnimalsAnimalId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Animals",
                newName: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalZookeeper_Animals_AnimalsAnimalId",
                table: "AnimalZookeeper",
                column: "AnimalsAnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
