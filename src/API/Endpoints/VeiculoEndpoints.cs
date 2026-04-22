using System;
using CQRS.Demo.API.CQRS;
using CQRS.Demo.API.CQRS.Commands;

namespace CQRS.Demo.API.Endpoints;

public static class VeiculoEndpoints
{
   
  public static RouteGroupBuilder Map(WebApplication app)
  {
        var group = app.MapGroup("/veiculos");

        group.MapPost("/criarmarca", (CriarNovaMarcaCommand command, Dispatcher dispatcher) =>
        {
            dispatcher.Send(command);
            return Results.Ok();
        });
        return group;
  }
}
