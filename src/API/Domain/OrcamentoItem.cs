using System;
using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class OrcamentoItem : BaseEntity
{
    public string Descricao { get; private set; }

    public decimal Valor { get; private set; }
    public Guid OrcamentoId { get; private set; }
    public Orcamento Orcamento { get; private set; } = default!;

    public OrcamentoItem(string descricao, decimal valor)
    {
        Descricao = descricao;
        Valor = valor;
    }
}
