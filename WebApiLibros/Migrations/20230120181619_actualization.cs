using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLibros.Migrations
{
    public partial class actualization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_libros",
                table: "libros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_autores",
                table: "autores");

            migrationBuilder.RenameTable(
                name: "libros",
                newName: "Libro");

            migrationBuilder.RenameTable(
                name: "autores",
                newName: "Autor");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Libro",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Libro",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdAutor",
                table: "Libro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Autor",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Autor",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libro",
                table: "Libro",
                column: "IdLibro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autor",
                table: "Autor",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro",
                column: "IdAutor",
                principalTable: "Autor",
                principalColumn: "IdAutor",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_IdAutor",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libro",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autor",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "IdAutor",
                table: "Libro");

            migrationBuilder.RenameTable(
                name: "Libro",
                newName: "libros");

            migrationBuilder.RenameTable(
                name: "Autor",
                newName: "autores");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "autores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "autores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_libros",
                table: "libros",
                column: "IdLibro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_autores",
                table: "autores",
                column: "IdAutor");
        }
    }
}
