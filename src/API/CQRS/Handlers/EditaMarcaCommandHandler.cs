using System;
using CQRS.Demo.API.CQRS.Commands;
using CQRS.Demo.API.Data.Interfaces;
using CQRS.Demo.API.Domain;
using CQRS.Demo.API.Models;

namespace CQRS.Demo.API.CQRS.Handlers;

public class EditaMarcaCommandHandler : ICommandHandler<EditarMarcaCommand>
{
    private readonly IBaseRepository<Marca> _marcaRepository;

    public EditaMarcaCommandHandler(IBaseRepository<Marca> marcaRepository)
    {
        _marcaRepository = marcaRepository;
        result = new Result();
    }

    public Result result { get ; set;}

    public async Task<Result> Handle(EditarMarcaCommand command)
    {
        if (command.Id == Guid.Empty)
            throw new ArgumentException("O Id da marca é obrigatório.");

        result.Ensure(await _marcaRepository.Exist(command.Id));
        if (!result.IsSuccess)
            throw new ArgumentException("Marca não encontrada.");

        return result; 
    }
}
