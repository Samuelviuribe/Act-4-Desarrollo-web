using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Donaciones
    {   
        public int? EstudiantesId { get; set; } 
        //navigation propiety

        public Estudiantes? Estudiante { get; set; }

        public int Id { get; set; } 
        public string Donante { get; set; }  
        public string Telefono { get; set; }  
        public string Email { get; set; } 
        public decimal Monto { get; set; }  
        public string MetodoPago { get; set; }  
        public string Comentarios { get; set; }  
        public DateTime FechaDonacion { get; set; }
    }
}