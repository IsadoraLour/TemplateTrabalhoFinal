namespace TrabalhoFinal._01_Services.Interfaces
{
    public interface IUsuarioServices
    {
        void Adicionar(Usuario usuario);
        void Remover(int id);
        void Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
       
    }
}
