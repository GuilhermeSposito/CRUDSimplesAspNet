using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TesteDeCriacaoDeApi1.Models;

[Table("produto")]
public class Produto
{
    [Key]
    [Column("produtosid")] public int? ProdutosId { get; set; }

    [Column("nome")] [Required] [StringLength(100)] public string? Nome { get; set; } = string.Empty;

    [Column("descricao")] [Required] [StringLength(100)] public string? Descricao { get; set; } = string.Empty;

    [Required] [Column(TypeName = "decimal(10,2)")] public decimal valor {  get; set; } 

    [Column("estoque")] public float Estoque { get; set; }  
    [Column("datacadastro")] public DateTime DataCadastro {  get; set; }
    [Column("categoriaid")] public int CategoriaId { get; set; }
    [JsonIgnore][NotMapped]public Categoria? Categoria { get; set; }

    [Column("imagemurl")][Required] [StringLength(300)] public string? ImagemUrl {  get; set; }
}
