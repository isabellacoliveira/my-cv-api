using System.ComponentModel.DataAnnotations;

namespace myCvApi.Data;
public class CreateProjetoDto 
{
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
}