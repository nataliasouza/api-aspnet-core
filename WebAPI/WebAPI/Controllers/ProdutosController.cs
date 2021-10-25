using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> BuscarProduto()
        {
            try
            {
                return _context.Produtos.AsNoTracking().ToList();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar obter os produtos!");
            }
        }

        [HttpGet("{id}", Name ="ObterProduto")]
        public ActionResult<Produto> BuscarProdutoPorId(int id)
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound($"O produto com id ={id} não foi encontrado");
                }
                return produto;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar obter o produto: {id}!");
            }
            
        }

        [HttpPost]
        public ActionResult SalvarProduto([FromBody] Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar salvar o produto: {produto}!");
            }
        }

        [HttpPut("{id}")]
        public ActionResult AlterarProduto(int id, [FromBody]Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest();
                }
                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"O Produto com o id ={id} foi atualizado");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar alterar o produto!");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Produto> DeletarProduto(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto == null)
                {
                    return NotFound();
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return produto;
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o produto de id {id}!");
            }
        }

    }
}
