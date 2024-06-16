using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteDeCriacaoDeApi1.Context;
using TesteDeCriacaoDeApi1.Models;

namespace TesteDeCriacaoDeApi1.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : Controller
{
    public readonly ApplicationDbContext db;

    public CategoriasController(ApplicationDbContext DB)
    {
        db = DB;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        try
        {
            IEnumerable<Categoria> categorias = await db.Categoria.ToListAsync();

            if (categorias is null)
                return NotFound("Nenhuma categoria encontrada na base de dados");

            return Ok(categorias);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Servidor Internal Error");
    }
    
    [HttpGet("produtos")]
    public async Task<ActionResult> GetCategoriasComProdutos()
    {
        try
        {
            IEnumerable<Categoria> categorias = await db.Categoria.Include(p=> p.Produtos).ToListAsync();

            if (categorias is null)
                return NotFound("Nenhuma categoria encontrada na base de dados");

            return Ok(categorias);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Servidor Internal Error");
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria(int id)
    {
        try
        {
            var categoria = await db.Categoria.FirstOrDefaultAsync(x => x.CategoriasId == id);

            if (categoria is null)
                return NotFound("Categoria não encontrada");

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Sercidor internal Error");
    }

    [HttpPost]
    public async Task<ActionResult> PostCategoria(Categoria categoria)
    {
        try
        {
            if (categoria is null)
                return BadRequest("Informe ao menos uma categoria a ser adicionada");

            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriasId }, categoria);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Servidor internal erroe");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> PutCategoria(int id, Categoria categoria)
    {
        try
        {
            if (categoria is null)
                return BadRequest("Deve informar ao menos uma categoria pra poder modifica-la");

            db.Entry(categoria).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Servidor internal erroe");
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCategoria(int id)
    {
        try
        {
          var categoria  = await db.Categoria.FirstOrDefaultAsync(x => x.CategoriasId == id);

            if (categoria is null)
            {
                return BadRequest("Produto nsão encontrado na base de dados.");
            }

            db.Remove(categoria);
            await db.SaveChangesAsync();

            return Ok("Categoria removida com sucesso");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        return StatusCode(500, "Servidor internal erroe");
    }
}
