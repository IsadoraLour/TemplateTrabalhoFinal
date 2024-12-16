using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using System.Net.Http.Json;

namespace FrontEnd.UseCases
{
    public class FuncionarioUC
    {
        private readonly HttpClient _client;

        public FuncionarioUC(HttpClient cliente)
        {
            _client = cliente;
        }

        public Funcionario CadastrarFuncionario(Funcionario funcionario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Funcionario/adicionar-funcionario", funcionario).Result;

            Funcionario funcionarioCadastrado = response.Content.ReadFromJsonAsync<Funcionario>().Result;
            return funcionarioCadastrado;
        }

        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
        {
            return _client.GetFromJsonAsync<ReadFuncionarioDTO>("Funcionario/listar-funcionario=" + id).Result;
        }
    }
}
