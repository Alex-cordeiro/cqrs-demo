using System;

namespace CQRS.Demo.API.CQRS.Commands;

public record CriarNovaMarcaCommand : ICommand
{
    public string Nome { get; init; } = string.Empty;
}
