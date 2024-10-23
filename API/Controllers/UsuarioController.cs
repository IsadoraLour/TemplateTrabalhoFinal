using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new UsuarioService(_config);
            _mapper = mapper;
        }

        [HttpPost("adicionar-usuario")]
        public IActionResult AdicionarUsuario(Usuario usuarioDTO)
        {
            _service.Adicionar(usuarioDTO);
            return CreatedAtAction(nameof(ListarUsuarios), new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPost("fazer-login")]
        public ActionResult<Usuario> FazerLogin(UsuarioLoginDTO usuarioLogin)
        {
            Usuario usuario = _service.FazerLogin(usuarioLogin);
            if (usuario == null)
            {
                return Unauthorized();
            }
            return Ok(usuario);
        }

        [HttpGet("listar-usuarios")]
        public ActionResult<List<Usuario>> ListarUsuarios()
        {
            var usuarios = _service.Listar();
            return Ok(usuarios);
        }

        [HttpPut("editar-usuario")]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            _service.Editar(usuario);
            return NoContent();
        }

        [HttpDelete("deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
