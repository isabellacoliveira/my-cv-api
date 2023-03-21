using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCvApi.Data;
using myCvApi.Models;

namespace myCvApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjetoController : ControllerBase
{
    private static List<Projeto> linguagens = new List<Projeto>();
    private static int Id = 0; 
    private LinguagemContext _context;
    private IMapper _mapper;

    public ProjetoController(LinguagemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaProjeto([FromBody] CreateProjetoDto projetoDto)
    {
        Projeto projeto = _mapper.Map<Projeto>(projetoDto);
        _context.Projetos.Add(projeto); 
        _context.SaveChanges(); 
        return CreatedAtAction(nameof(RecuperaProjetoPorId),  new {  
                                          linguagemId = projeto.LinguagemId }, projeto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetoDto> RecuperaLinguagens([FromQuery] int? projetoId = null)
    {
        if(projetoId == null)
        {
            return _mapper.Map<List<ReadProjetoDto>>(_context.Projetos.ToList()); 
        }
        return _mapper.Map<List<ReadProjetoDto>>(_context.Projetos.FromSqlRaw($"SELECT Id, Nome, Cor, CorTexto, Imagem from LINGUAGENS WHERE linguagens.ProjetoId = {projetoId}").ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProjetoPorId(int id)
    {
        Projeto Projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == id);
        if(Projeto != null)
        {
            ReadProjetoDto ProjetoDto = _mapper.Map<ReadProjetoDto>(Projeto);
            return Ok(ProjetoDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaProjeto(int id, [FromBody] UpdateProjetoDto ProjetoDto)
    {
        var Projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
        if(Projeto == null) return NotFound(); 
        _mapper.Map(ProjetoDto, Projeto); 
        _context.SaveChanges(); 
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaProjetoParcial(int id, JsonPatchDocument<UpdateProjetoDto> patch)
    {
            var Projeto = _context.Projetos.FirstOrDefault(
            Projeto => Projeto.Id == id);
            if(Projeto == null) return NotFound();
            var ProjetoParaAtualizar = _mapper.Map<UpdateProjetoDto>(Projeto);
            patch.ApplyTo(ProjetoParaAtualizar, ModelState);
            if(!TryValidateModel(ProjetoParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(ProjetoParaAtualizar, Projeto);
            _context.SaveChanges();
            return NoContent(); 
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletaProjeto(int id)
    {
        var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.Id == id);
        if(projeto == null) return NotFound(); 
        
        _context.Remove(projeto); 
        _context.SaveChanges(); 
        return NoContent(); 
    }

}
