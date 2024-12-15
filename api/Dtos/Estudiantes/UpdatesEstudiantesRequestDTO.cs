using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Estudiantes
{
    public class UpdatesEstudiantesRequestDTO
    {
 
        public string Password { get; set; }  
        public string Name { get; set; }  
        public string Apellidos { get; set; }  
        public string Rol { get; set; }  
        public string Email { get; set; }  
        public string Telefono { get; set; }  
        public string Estado { get; set; } 
        public DateTime FechaRegistro { get; set; }  
    }
}