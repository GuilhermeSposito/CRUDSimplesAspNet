using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeCriacaoDeApi1.Models;

[Table("categoria")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();  
    }

    [Key]
    [Column("categoriasid")]public int CategoriasId { get; set; }

    [Required]
    [StringLength(100)]
    [Column("nome")]public string? Nome { get; set; }  = string.Empty;

    [Required]
    [StringLength(300)]
    [Column("imagemurl")] public string? ImagemUrl { get; set; } = string.Empty;

    [StringLength(50)]
    [Column("numerodeserie")]public string? numerodeserie { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
