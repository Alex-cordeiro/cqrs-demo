using System;
using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class Marca : BaseEntity
{
    public string Nome { get; private set; }

    public Marca(string nome)
    {
        Nome = nome;
    }

    public List<Modelo> Modelos { get; private set; } = default!;
}
