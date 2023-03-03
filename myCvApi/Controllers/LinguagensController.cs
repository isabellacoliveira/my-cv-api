using System.Collections;
using AutoMapper;
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

}
