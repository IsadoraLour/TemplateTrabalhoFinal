using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidades;

public class Pessoa
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Testando mensagem de erro")]
    [MaxLength(100,ErrorMessage ="Nome acima do limite máximo")]
    [MinLength(3,ErrorMessage ="Nome abaixo do limite máximo")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "ultrapassou os limites")]
    [Range(0,100,ErrorMessage = "")]
    [EmailAddress(ErrorMessage ="Email inválido")]
    [Phone (ErrorMessage ="Telefone inválido")]
    [Url (ErrorMessage ="URL inválido")]
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
}
