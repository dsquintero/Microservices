﻿using PersonasMicroservice.Domain.Entities;
using PersonasMicroservice.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasContext _context;

        public PersonaRepository(PersonasContext context)
        {
            _context = context;
        }
        public async Task<List<Persona>> GetAll()
        {
            return await _context.Personas.Include("TipoPersona").Where(w => w.Activo == true).ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _context.Personas
                .Include("TipoPersona")
                .FirstOrDefaultAsync(p => p.Id == id && p.Activo == true);
        }

        public async Task<Persona> GetByIdentificacion(int TipoPersona, string Identificacion)
        {
            return await _context.Personas
                .Include("TipoPersona")
                .FirstOrDefaultAsync(p => p.IdTipoPersona == TipoPersona && p.Identificacion.Equals(Identificacion) && p.Activo == true);
        }

        public async Task<string> Create(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
            return $"Persona creada con ID: {persona.Id}";
        }

        public async Task<string> Update(int id, Persona persona)
        {
            var personaExistente = await _context.Personas.Where(w => w.Id == id && w.Activo == true).FirstOrDefaultAsync();
            if (personaExistente == null)
            {
                return "Persona no encontrada.";
            }

            // Actualiza los campos necesarios
            personaExistente.Nombre = persona.Nombre;
            personaExistente.Fecha_Nacimiento = persona.Fecha_Nacimiento;

            await _context.SaveChangesAsync();
            return $"Persona con ID: {id} actualizada correctamente.";
        }

        public async Task<string> Delete(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return "Persona no encontrada.";
            }
            persona.Activo = false;
            //_context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return $"Persona con ID: {id} eliminada correctamente.";
        }
    }
}