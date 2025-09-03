using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinalTrans2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutPrixSansContrôle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Prix",
                table: "Realisations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Realisations");
        }
    }
}
