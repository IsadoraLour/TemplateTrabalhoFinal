namespace FrontEnd.Models.DTOs
{
    public class ReadEnderecoDTO
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public override string ToString()
        {
            return $"Endereço: {Rua}, {Numero} - {Bairro}, {Cidade}/{Estado} - CEP: {CEP}";
        }
    }
}
