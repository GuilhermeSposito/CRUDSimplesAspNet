using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using TesteDeCriacaoDeApi1.Context;
using TesteDeCriacaoDeApi1.Models;

namespace TesteDeCriacaoDeApi1.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    public readonly ApplicationDbContext _Context;

    public ProdutosController(ApplicationDbContext context)
    {
        _Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable>> GetProdutos()
    {
        List<Produto> produtos = new List<Produto>();
        try
        {
            produtos = await _Context.Produto.ToListAsync();

            if (produtos.Count() == 0)
            {
                return NotFound("Nenhum produto foi encontrado");
            }

            return produtos;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return produtos;
    }

    [HttpGet("{id:int}", Name = "ObterProduto")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        Produto produto = null;
        try
        {
            produto = await _Context.Produto.Where(x => x.ProdutosId == id).FirstOrDefaultAsync();

            if (produto is null)
            {
                return NotFound("Produto procurado não foi encontrado na base de dados");
            }

            return produto;
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return produto;
    }

    [HttpPost]
    public async Task<ActionResult> PostProduto(Produto produto)
    {
        try
        {
            if (produto is null)
                return BadRequest("Por favor envie um produto no body");

            await _Context.Produto.AddAsync(produto);
            await _Context.SaveChangesAsync();

            return new CreatedAtRouteResult(
                "ObterProduto",
                new { id = produto.ProdutosId },
                produto
                );
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Internal Server Error");
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutProduto(int id, Produto produto)
    {
        try
        {
            if (produto is null)
                return BadRequest("Por favor informe um produto para ser alterado");

            _Context.Entry(produto).State = EntityState.Modified;
            await _Context.SaveChangesAsync();


            return Ok("Produto Modificado com sucesso!");

        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Internal Server Error");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduto(int id)
    {
        try
        {
            Produto produto = _Context.Produto.FirstOrDefault(x => x.ProdutosId == id);

            if (produto is null)
            {
                return BadRequest("Produto não encontrado na base de dados");
            }

            _Context.Produto.Remove(produto);
            await _Context.SaveChangesAsync();

            return Ok("Produto Removido com sucesso!");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Internal Server Error");
    }
}
