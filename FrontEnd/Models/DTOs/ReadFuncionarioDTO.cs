namespace FrontEnd.Models.DTOs
{
    public class ReadFuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public string Departamento { get; set; }

        public override string ToString()
        {
            return $"Funcionario: {Nome} - Cargo: {Cargo} - Salário: {Salario:C} - Departamento: {Departamento}";
        }
    }
}
