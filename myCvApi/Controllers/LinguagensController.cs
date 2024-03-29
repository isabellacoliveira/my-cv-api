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
public class LinguagensController : ControllerBase
{
    private static List<Linguagem> linguagens = new List<Linguagem>();
    private static int Id = 0; 
    private LinguagemContext _context;
    private IMapper _mapper;

    public LinguagensController(LinguagemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaLinguagem([FromBody] CreateLinguagemDto linguagemDto)
    {
        Linguagem linguagem = _mapper.Map<Linguagem>(linguagemDto);
        _context.Linguagens.Add(linguagem); 
        _context.SaveChanges(); 
        return CreatedAtAction(nameof(RecuperaLinguagemPorId), new { Id = linguagem.Id }, linguagemDto);
    }

    [HttpGet]
    public IEnumerable<ReadLinguagemDto> RecuperaLinguagens([FromQuery] int? linguagemId = null)
    {
        if(linguagemId == null)
        {
            return _mapper.Map<List<ReadLinguagemDto>>(_context.Linguagens.ToList()); 
        }
        return _mapper.Map<List<ReadLinguagemDto>>(_context.Linguagens.FromSqlRaw($"SELECT Id, Nome, Cor, CorTexto, Imagem from LINGUAGENS WHERE linguagens.linguagemId = {linguagemId}").ToList());
    }


    [HttpGet("{id}")]
    public IActionResult RecuperaLinguagemPorId(int id)
    {
        Linguagem linguagem = _context.Linguagens.FirstOrDefault(linguagem => linguagem.Id == id);
        if(linguagem != null)
        {
            ReadLinguagemDto linguagemDto = _mapper.Map<ReadLinguagemDto>(linguagem);
            return Ok(linguagemDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaLinguagem(int id, [FromBody] UpdateLinguagemDto linguagemDto)
    {
        var linguagem = _context.Linguagens.FirstOrDefault(linguagem => linguagem.Id == id);
        if(linguagem == null) return NotFound(); 
        _mapper.Map(linguagemDto, linguagem); 
        _context.SaveChanges(); 
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaLinguagemParcial(int id, JsonPatchDocument<UpdateLinguagemDto> patch)
    {
            var linguagem = _context.Linguagens.FirstOrDefault(
            linguagem => linguagem.Id == id);
            if(linguagem == null) return NotFound();
            var linguagemParaAtualizar = _mapper.Map<UpdateLinguagemDto>(linguagem);
            patch.ApplyTo(linguagemParaAtualizar, ModelState);
            if(!TryValidateModel(linguagemParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(linguagemParaAtualizar, linguagem);
            _context.SaveChanges();
            return NoContent(); 
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeletaLinguagem(int id)
    {
        var linguagem = _context.Linguagens.FirstOrDefault(linguagem => linguagem.Id == id);
        if(linguagem == null) return NotFound(); 
        
        _context.Remove(linguagem); 
        _context.SaveChanges(); 
        return NoContent(); 
    }

}
