using System.ComponentModel.DataAnnotations;
using myCvApi.Data;

namespace myCvApi.Models;
public class Projeto 
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
    public string NomeProjeto { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "A imagem ou GIF é obrigatória.")]
    public string Imagem { get; set; }
    [Required(ErrorMessage = "A URL do Git Hub é obrigatória.")]
    public string URLGithub { get; set; }
    public string URLVisita { get; set; }
    public int LinguagemId { get; set; }
     public virtual Linguagem Linguagem { get; set; }
}