using AutoMapper;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._03_Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        private readonly IMapper _mapper;

        public FuncionarioController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new FuncionarioService(_config);
            _mapper = mapper;
        }

        [HttpPost("adicionar-funcionario")]
        public IActionResult Adicionarfuncionario(Funcionario funcionarioDTO)
        {
            _service.Adicionar (funcionarioDTO);
            return CreatedAtAction(nameof(ListarFuncionario), new { id = funcionarioDTO.Id }, funcionarioDTO);
        }


        [HttpGet("listar-funcionario")]
        public ActionResult<List<Funcionario>> ListarFuncionario()
        {
            var funcionario = _service.Listar();
            return Ok(funcionario);
        }

        [HttpPut("editar-funcionario")]
        public IActionResult EditarFuncionario(Funcionario funcionario)
        {
            _service.Editar(funcionario);
            return NoContent();
        }

        [HttpDelete("deletar-funcionario/{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}




