using MinhasFinancas.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities;

[Table("TRANSACAO")]
public class Transacao : EntityBase
{
    [Nota()]
    [Column(name: "TIPO", Order = 2)]
    public int Tipo { get; set; }

    [Nota()]
    [Column(name: "NOME", Order = 3)]
    public string? Nome { get; set; }

    [Nota()]
    [Column(name: "DATA_LANCAMENTO", Order = 4)]
    public DateTime? DataLancamento { get; set; }

    [Nota()]
    [Column(name: "VALOR", Order = 5)]
    public double Valor { get; set; }

}
