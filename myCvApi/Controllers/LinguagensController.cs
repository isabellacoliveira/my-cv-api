using System.Collections;
using Microsoft.AspNetCore.Mvc;
using myCvApi.Models;

namespace myCvApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LinguagensController : ControllerBase
{
    private static List<Linguagem> linguagens = new List<Linguagem>();
    private static int Id = 0; 
    [HttpPost]
    public void AdicionaLinguagem([FromBody] Linguagem linguagem)
    {
        linguagens.Add(linguagem);
    }

    [HttpGet]
    public IEnumerable<Linguagem> RecuperaLinguagens()
    {
        return linguagens;
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaLinguagemPorId(int id)
    {
        var linguagem = linguagens.FirstOrDefault(linguagem => linguagem.Id == id);
        if(linguagem == null) return NotFound();
        return Ok(linguagem);
    }

}
