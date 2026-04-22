using System;
using CQRS.Demo.API.CQRS.Commands;
using CQRS.Demo.API.Data.Interfaces;
using CQRS.Demo.API.Domain;

namespace CQRS.Demo.API.CQRS.Handlers;

public class CriarNovoVeiculoCommandhandler : ICommandHandler<CriarNovoVeiculoCommand>
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMarcaRepository _marcaRepository;
    private readonly IModeloRepository _modeloRepository;
    public CriarNovoVeiculoCommandhandler(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public Task Handle(CriarNovoVeiculoCommand command)
    {
        if (command is null)
            throw new ArgumentNullException(nameof(command));
        return Task.CompletedTask;
    }
}
