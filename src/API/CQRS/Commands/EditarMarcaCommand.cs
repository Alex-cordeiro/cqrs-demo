using System;

namespace CQRS.Demo.API.CQRS.Commands;

public record EditarMarcaCommand : CriarNovaMarcaCommand
{
    public Guid Id { get; init; }
}

