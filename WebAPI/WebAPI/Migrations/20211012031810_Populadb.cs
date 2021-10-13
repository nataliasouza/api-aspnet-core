using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas','https://www.pexels.com/pt-br/foto/alimentacao-almoco-amor-comendo-3044/')");

            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Lanches','https://www.pexels.com/pt-br/foto/hamburguer-em-bandeja-de-madeira-marrom-1108117/')");

            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Pizzas','https://www.pexels.com/pt-br/foto/fotografia-em-foco-raso-de-varias-pizzas-1566837/')");


            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                " Values('Vinho Jacobs Creek','Vinho Tinto 750 ml',159.55," +
                "'https://www.pexels.com/pt-br/foto/garrafa-de-reserva-de-jacob-s-creek-com-copo-de-vinho-2912108/',25,now(),(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Coca Cola',' Refrigerante de Cola 600 ml', 7.00," +
                "'https://www.pexels.com/pt-br/foto/latas-e-copos-de-coca-cola-com-linhas-50593/',50,now(),(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Guaraná Antartica',' Refrigerante de Guaraná 2L', 9.00," +
                "'https://www.pexels.com/pt-br/foto/latas-e-copos-de-coca-cola-com-linhas-50593/',80,now(),(Select CategoriaId from Categorias where Nome='Bebidas'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('X Burguer',' Lanche de Hamburguer', 15.00," +
                "'https://www.pexels.com/pt-br/foto/foto-de-close-up-de-hamburguer-1639562/',10,now(),(Select CategoriaId from Categorias where Nome='Lanches'))");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "Values('Pizza de Calabresa','Pizza', 35.00," +
                "'https://www.pexels.com/pt-br/foto/pizza-com-caixa-na-mesa-280453/',20,now(),(Select CategoriaId from Categorias where Nome='Pizzas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
