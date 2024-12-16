using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new ProdutoService(_config);
            _mapper = mapper;
        }

        [HttpPost("adicionar-produto")]
        public IActionResult Adicionarproduto(Produto produtoDTO)
        {
            _service.Adicionar(produtoDTO);
            return CreatedAtAction(nameof(ListarProduto), new { id = produtoDTO.Id }, produtoDTO);
        }


        [HttpGet("listar-produto")]
        public ActionResult<List<Produto>> ListarProduto()
        {
            var produto = _service.Listar();
            return Ok(produto);
        }

        [HttpPut("editar-produto")]
        public IActionResult Editarproduto(Produto produto)
        {
            _service.Editar(produto);
            return NoContent();
        }

        [HttpDelete("deletar-produto/{id}")]
        public IActionResult DeletarProduto(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
    

