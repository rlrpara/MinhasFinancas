using MinhasFinancas.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities;

[Table("USUARIO")]
public class Usuario : EntityBase
{
    [Nota(Tamanho = 11)]
    [Column("CPF", Order = 2)]
    public string? CPF { get; set; }

    [Nota(Tamanho = 50)]
    [Column("EMAIL", Order = 3)]
    public string? Email { get; set; }

    [Nota()]
    [Column("SENHA", Order = 4)]
    public string? Senha { get; set; }

    [Nota()]
    [Column("NOME", Order = 5)]
    public string? Nome { get; set; }

    [Nota()]
    [Column("ADMINISTRADOR", Order = 6)]
    public bool Administrador { get; set; }

    [Nota(ChaveEstrangeira = "EMPRESA")]
    [Column("ID_EMPRESA", Order = 7)]
    public int CodigoSistema { get; set; }
}
