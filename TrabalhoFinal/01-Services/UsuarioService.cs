using Core.Entidades;
using TrabalhoFinal._01_Services.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidades.DTO;

namespace TrabalhoFinal._01_Services;

public class UsuarioService : IUsuarioServices
{
    public UsuarioRepository repository { get; set; }

    public UsuarioService(string _config)
    {
        repository = new UsuarioRepository(_config);
    }

    public void Adicionar(Usuario usuario)
    {
        repository.Adicionar(usuario);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Usuario> Listar()
    {
        return repository.Listar();
    }

    public Usuario BuscarPorId(int id)
    {
        return repository.BuscarPorId(id);
    }

    public void Editar(Usuario usuarioEditado)
    {
        repository.Editar(usuarioEditado);
    }

   
}
