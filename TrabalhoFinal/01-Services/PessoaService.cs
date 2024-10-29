using System.Configuration.Internal;
using TrabalhoFinal._01_Services.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades;

namespace TrabalhoFinal._01_Services;

public class PessoaService:IPessoasServices
{
    public PessoaRepository repository { get; set; }
    public PessoaService(string connectionString)
    {
        repository = new PessoaRepository(connectionString);
    }
    public void Adicionar(Pessoa pessoa)
    {
        repository.Adicionar(pessoa);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Pessoa> Listar()
    {
        return repository.Listar();
    }
    public void BuscarTimePorId(int id)
    {
        //return repository.BuscarPorId(id);
    }
    public void Editar(int id, Pessoa editPessoa)
    {
        var p = repository.BuscarPorId(id);
        repository.Editar(p);
    }
}
