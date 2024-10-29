using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._01_Services.Interfaces;
using TrabalhoFinal._03_Entidades;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoasServices _service;
    public PessoaController(IConfiguration config)
    {
        string connectionString = config.GetConnectionString("DefaultConnection");
        _service = new PessoaService(connectionString);
    }
    [HttpPost("adicionar-pessoa")]
    public void AdicionarPessoa(Pessoa pessoa)
    {
        _service.Adicionar(pessoa);
    }
    [HttpGet("listar-pessoa")]
    public List<Pessoa> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-pessoa")]
    public void EditarPessoa(int id, Pessoa p)
    {
        _service.Editar(id, p);
    }
    [HttpDelete("deletar-pessoa")]
    public void DeletarPessoa(int id)
    {
        _service.Remover(id);
    }
}
