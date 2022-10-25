using GreenLeavesAPI.Data;
using GreenLeavesAPI.DataGLModels;
using Microsoft.EntityFrameworkCore;

namespace GreenLeavesAPI.Services;

public class PersonaService{
    private readonly GreenLeavesContext _context;

    public PersonaService(GreenLeavesContext context){
        _context = context;
    }

        public async Task<IEnumerable<Persona>> GetAll(){
        return await _context.Personas.ToListAsync();
    }

     public async Task<Persona?> GetById(int id){
        return await _context.Personas.FindAsync(id);
     }

     public async Task<Persona> Create(Persona newPersona){
        _context.Personas.Add(newPersona);
        await _context.SaveChangesAsync();

        return newPersona;
     }

     public async Task Update(int id, Persona Persona){
        var existingPersona = await GetById(id);

        if(existingPersona is not null){
            existingPersona.Name = Persona.Name;
            existingPersona.PhoneNumber = Persona.PhoneNumber;
            existingPersona.Email = Persona.Email;

            await _context.SaveChangesAsync();
        }
     }

     public async Task Delete(int id){
        var PersonaToDelete = await GetById(id);

        if(PersonaToDelete is not null){
            _context.Personas.Remove(PersonaToDelete);
            await _context.SaveChangesAsync();
        }
     }
}
