using System;
using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class Orcamento : BaseEntity
{
    public decimal ValorTotal { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Aprovado { get; set; }

    public List<OrcamentoItem> Itens { get; private set; } = new List<OrcamentoItem>();

    public OrdemServico OrdemServico { get; private set; } = default!;
    public Orcamento(decimal valorTotal, DateTime dataCriacao, bool aprovado)
    {
        ValorTotal = valorTotal;
        DataCriacao = dataCriacao;
        Aprovado = aprovado;
    }

    public void AddItem(OrcamentoItem item)
    {
        // Lógica para adicionar um item ao orçamento
        Itens.Add(item);
        ValorTotal += item.Valor; // Atualiza o valor total do orçamento
    }


}
