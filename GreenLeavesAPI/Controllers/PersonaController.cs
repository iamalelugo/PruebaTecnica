using Microsoft.AspNetCore.Mvc;
using GreenLeavesAPI.Services;
using GreenLeavesAPI.DataGLModels;
using Microsoft.AspNetCore.Authorization;

namespace GreenLeavesAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PersonaController: ControllerBase{
    private readonly PersonaService _service;
    public PersonaController(PersonaService context){
        _service = context;
    }

    [HttpGet("getall")]
    public async Task<IEnumerable<Persona>> Get(){
        return await _service.GetAll();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Persona>> GetById(int id){
        var persona = await _service.GetById(id);

        if(persona is null){
            return PersonaNotFound(id);
        }
        return persona;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(Persona persona){
        var newPersona = await _service.Create(persona);

        return CreatedAtAction(nameof(GetById), new{ id = newPersona.Id}, persona);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, Persona persona){
        if(id != persona.Id){
            return BadRequest();
        }
        var clientToUpdate = await _service.GetById(id);
        if(clientToUpdate is not null){
            await _service.Update(id, persona);
            return NoContent();
        }
        else{
            return PersonaNotFound(id);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id){
        var personaToDelete = await _service.GetById(id);

        if(personaToDelete is not null){
            await _service.Delete(id);
            return Ok();
        }
        else{
            return PersonaNotFound(id);
        }
    }

    public NotFoundObjectResult PersonaNotFound(int id){
        return NotFound(new{ message = $"La persona con ID = {id} no existe"});
    }
}