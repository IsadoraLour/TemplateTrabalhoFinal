using AutoMapper;
using Core._03_Entidades.DTO.Venda;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._01_Services.Interfaces;

namespace API.Controllers;


[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly ICarrinhoServices _service;
    private readonly IMapper _mapper;
    public CarrinhoController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new CarrinhoService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-carrinho")]
    public void AdicionarAluno(Carrinho carrinhoDTO)
    {
        Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
        _service.Adicionar(carrinho);
    }
    [HttpGet("listar-carrinho")]
    public List<Carrinho> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpGet("listar-carrinho-do-usuario")]
    public List<ReadVendaReciboDTO> ListarCarrinhoDoUsuario([FromQuery] int usuarioId)
    {
        return _service.ListarCarrinhoDoUsuario(1);
    }
    [HttpPut("editar-carrinho")]
    public void EditarCarrinho(Carrinho p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-carrinho")]
    public void DeletarCarrinho(int id)
    {
        _service.Remover(id);
    }
}
