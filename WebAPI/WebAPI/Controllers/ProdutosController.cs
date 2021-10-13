using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }
        [HttpPost]
        public ActionResult BuscarProduto([FromBody]Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name ="ObterProduto")]
        public ActionResult<Produto> BuscarProdutoPorId(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if(produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPut("{id}")]
        public ActionResult AlterarProduto(int id, [FromBody]Produto produto)
        {
            if( id!= produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Produto> DeletarProduto(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            if(produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }

    }
}
