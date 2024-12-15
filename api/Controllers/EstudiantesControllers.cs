using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Dtos.Estudiantes;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesControllers : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EstudiantesControllers(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var estudiantes = _context.Estudiante
                .ToList()
                .Select(s => s.ToEstudiantesDto())
                .ToList();

            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Estudiante = _context.Estudiante.Find(id);

            if (Estudiante == null)
            {
                return NotFound();
            }

            return Ok(Estudiante.ToEstudiantesDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEstudiantesRequestDtos estudiantesDto)
        {
            if (estudiantesDto == null)
                return BadRequest("EstudiantesDto no puede ser nulo.");

            var estudiante = estudiantesDto.ToEstudiantesFromCreateDTO();
            _context.Estudiante.Add(estudiante);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = estudiante.Id }, estudiante.ToEstudiantesDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdatesEstudiantesRequestDTO updateDto)
        {
            var estudiante = _context.Estudiante.FirstOrDefault(x => x.Id == id);

            if (estudiante == null)
            {
                return NotFound();
            }

            // Actualizar los campos
            estudiante.Password = updateDto.Password;
            estudiante.Name = updateDto.Name;
            estudiante.Apellidos = updateDto.Apellidos;
            estudiante.Rol = updateDto.Rol;
            estudiante.Email = updateDto.Email;
            estudiante.Telefono = updateDto.Telefono;
            estudiante.Estado = updateDto.Estado;
            estudiante.FechaRegistro = updateDto.FechaRegistro;

            // Guardar cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta adecuada
            return Ok(estudiante.ToEstudiantesDto());
        }

        [HttpDelete]
        [Route("{id}")]
       public IActionResult Delete([FromRoute] int id)
{
    // Find the student by ID
    var estudiantesModel = _context.Estudiante.FirstOrDefault(x => x.Id == id);
    
    // Check if the student exists
    if (estudiantesModel == null)
    {
        return NotFound();
    }

    // Remove the student
    _context.Estudiante.Remove(estudiantesModel);

    // Save changes to the database
    _context.SaveChanges();

    // Return a NoContent response
    return NoContent();
        }
   }
}