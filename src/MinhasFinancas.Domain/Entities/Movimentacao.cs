using MinhasFinancas.Domain.Entities.Base;
using MinhasFinancas.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhasFinancas.Domain.Entities;

[Table("TRANSACAO")]
public class Movimentacao : EntityBase
{
    [Column(name: "TIPO")]
    public TipoTransacao Tipo { get; set; }

    [Column(name: "NOME")]
    public string? Nome { get; set; }

    [Column(name: "DATA_LANCAMENTO")]
    public DateTimeOffset DataLancamento { get; set; }

    [Column(name: "VALOR")]
    public double Valor { get; set; }

}
