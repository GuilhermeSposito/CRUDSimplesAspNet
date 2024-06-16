using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteDeCriacaoDeApi1.Migrations
{
    /// <inheritdoc />
    public partial class insercaoemprodutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO produto (nome,descricao,valor,estoque,datacadastro,categoriaid,imagemurl) VALUES ('COCA-COLA LATA','BEBIDA GELADA DE 350ML',5.50,50,NOW(),1,'coca.jpg')");
            mb.Sql("INSERT INTO produto (nome,descricao,valor,estoque,datacadastro,categoriaid,imagemurl) VALUES ('BACON','DELICIOSO LANCHE DA BACON',29.50,10,NOW(),2, 'lanche.jpeg')");
            mb.Sql("INSERT INTO produto (nome,descricao,valor,estoque,datacadastro,categoriaid,imagemurl) VALUES ('PIZZA MARGUERITA','PIZZA COM QUEIJO E MOLHO DE TOMATE',45.50,10,NOW(),3, 'pizza.jpeg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM produto");
        }
    }
}
