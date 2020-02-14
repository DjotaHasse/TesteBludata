using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteBludata.Migrations
{
    public partial class FornecedorFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaId",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Fornecedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaId",
                table: "Fornecedor",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaId",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Fornecedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Empresa_EmpresaId",
                table: "Fornecedor",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
