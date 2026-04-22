using System;

namespace CQRS.Demo.API.CQRS.Commands;

public record CriarNovoVeiculoCommand(string Marca, string Modelo, string Placa, int Ano) : ICommand;

