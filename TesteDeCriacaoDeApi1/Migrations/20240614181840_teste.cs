using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteDeCriacaoDeApi1.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO categoria (nome,imagemurl) VALUES ('BEBIDAS', 'BEBIDAS.JPEG')");
            mb.Sql("INSERT INTO categoria (nome,imagemurl) VALUES ('LANCHES', 'LANCHES.JPEG')");
            mb.Sql("INSERT INTO categoria (nome,imagemurl) VALUES ('PIZZAS', 'PIZZAS.JPEG')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM categoria");
        }
    }
}
