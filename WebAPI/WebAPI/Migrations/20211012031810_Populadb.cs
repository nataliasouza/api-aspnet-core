using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Bebidas'," + "'http://www.google.com/')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("");
        }
    }
}
