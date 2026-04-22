using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class Veiculo : BaseEntity
{
    public string Placa { get; private set; }
    public int Ano { get; private set; }

    public Guid ModeloId { get; private set; }
    public Modelo Modelo { get; private set; } 

    public List<OrdemServico> OrdensServico { get; private set; } = new List<OrdemServico>();

    private Veiculo() { }
    public Veiculo(string placa, int ano, Modelo modelo)
    {
        Placa = placa;
        Ano = ano;
        Modelo = modelo;
    }
}
