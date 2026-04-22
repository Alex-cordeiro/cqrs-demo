using System;
using CQRS.Demo.API.Domain.Base;
using CQRS.Demo.API.Domain.Enum;

namespace CQRS.Demo.API.Domain;

public class OrdemServico : BaseEntity
{
    public Guid VeiculoId { get; private set; }
    public Guid OrcamentoId { get; private set; }
    public Guid MecanicoId { get; private set; }
    public DateTime DataEntrada { get; private set; }
    public DateTime? DataFechamento { get; private set; }
    public EStatusOrdem Status { get; private set; }

    public Orcamento Orcamento { get; private set; } = default!;
    public Veiculo Veiculo { get; private set; } = default!;
    public Mecanico Mecanico { get; private set; } = default!;
    public OrdemServico(Guid veiculoId, Guid orcamentoId)
    {
        VeiculoId = veiculoId;
        OrcamentoId = orcamentoId;
        DataEntrada = DateTime.UtcNow;
        Status = EStatusOrdem.Aberta;
    }

    public void FecharOrdem()
    {
        DataFechamento = DateTime.UtcNow;
        Status = EStatusOrdem.Concluida;
    }

    public void VincularOrcamento(Orcamento orcamento)
    {
        Orcamento = orcamento;
    }
}
