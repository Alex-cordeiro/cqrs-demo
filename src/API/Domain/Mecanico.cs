using CQRS.Demo.API.Domain.Base;

namespace CQRS.Demo.API.Domain;

public class Mecanico : BaseEntity
{
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }

    public List<OrdemServico> OrdemServicos { get; private set; } = default!;

    public Mecanico(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    } 
}
