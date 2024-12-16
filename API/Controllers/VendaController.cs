using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._01_Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaServices _service;
        private readonly IMapper _mapper;

        public VendaController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new VendaService(_config);
            _mapper = mapper;
        }

        [HttpPost("adicionar-venda")]
        public IActionResult AdicionarVenda(Venda vendaDTO)
        {
            var venda = _mapper.Map<Venda>(vendaDTO);
            _service.Adicionar(venda);
            return CreatedAtAction(nameof(BuscarVendaPorId), new { id = venda.Id }, venda);
        }

        [HttpGet("listar-vendas")]
        public ActionResult<List<Venda>> ListarVendas()
        {
            var vendas = _service.Listar();
            return Ok(vendas);
        }

        [HttpGet("buscar-por-id/{id}")]
        public ActionResult<Venda> BuscarVendaPorId(int id)
        {
            var vendaDTO = _service.BuscarPorId(id);
            if (vendaDTO == null)
            {
                return NotFound();
            }
            return Ok(vendaDTO);
        }

        [HttpPut("editar-venda")]
        public IActionResult EditarVenda(Venda venda)
        {
            _service.Editar(venda);
            return NoContent();
        }

        [HttpDelete("deletar-venda/{id}")]
        public IActionResult DeletarVenda(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
