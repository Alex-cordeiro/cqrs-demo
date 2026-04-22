using System;
using CQRS.Demo.API.CQRS.Commands;
using CQRS.Demo.API.Data.Interfaces;
using CQRS.Demo.API.Domain;

namespace CQRS.Demo.API.CQRS.Handlers;

public class CriarNovaMarcaCommandHandler : ICommandHandler<CriarNovaMarcaCommand>
{
    private readonly IBaseRepository<Marca> _marcaRepository;

    public CriarNovaMarcaCommandHandler(IBaseRepository<Marca> marcaRepository)
    {
        _marcaRepository = marcaRepository;
    }

    public async Task Handle(CriarNovaMarcaCommand command)
    {
        if (command is null)
            throw new ArgumentNullException(nameof(command));

        var marca = new Marca(command.Nome);
        await _marcaRepository.Add(marca);

        await _marcaRepository.Commit();
    }
}
