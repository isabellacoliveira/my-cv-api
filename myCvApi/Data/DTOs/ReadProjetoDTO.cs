using System.ComponentModel.DataAnnotations;

namespace myCvApi.Data;
public class ReadProjetoDto
{
    public string NomeProjeto { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }
    public string URLGithub { get; set; }
    public string URLVisita { get; set; }
}