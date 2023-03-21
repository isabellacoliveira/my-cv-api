using System.ComponentModel.DataAnnotations;
using myCvApi.Data;

namespace myCvApi.Models;
public class Projeto 
{
    public int Id { get; set; }
    public string NomeProjeto { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }
    public string URLGithub { get; set; }
    public string URLVisita { get; set; }
    public int? LinguagemId { get; set; }
    public virtual Linguagem Linguagem { get; set; }
}