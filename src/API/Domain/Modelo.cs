using System;
using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class Modelo : BaseEntity
{
    public string Nome { get; private set; }
    public Guid MarcaId { get; private set; }

    public Marca Marca { get; private set; } = default!;

    public List<Veiculo> Veiculos { get; private set; } = default!;

    private Modelo() { }
    public Modelo(string nome, Marca marca)
    {
        Nome = nome;
        Marca = marca;
    }
}
