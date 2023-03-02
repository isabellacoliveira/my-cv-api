using System.ComponentModel.DataAnnotations;

namespace myCvApi.Models;
public class Linguagem 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome da linguagem é obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O nome da Cor é obrigatória.")]
    public string Cor { get; set; }
    [Required(ErrorMessage = "O nome da Cor do Texto é obrigatória.")]
    public string CorTexto { get; set; }
    [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
    public string Imagem { get; set; }
}