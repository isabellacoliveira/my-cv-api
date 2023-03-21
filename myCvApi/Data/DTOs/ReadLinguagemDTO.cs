namespace myCvApi.Data;
public class ReadLinguagemDto 
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cor { get; set; }
    public string CorTexto { get; set; }
    public string Imagem { get; set; }
    public ICollection<ReadProjetoDto> Projetos { get; set; }

}