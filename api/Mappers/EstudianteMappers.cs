using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.Estudiantes;
using api.Models;

namespace api.Mappers
{
    public static class EstudianteMappers
    {
        public static EstudiantesDto ToEstudiantesDto(this Estudiantes estudiantesModel)
        {
            return new EstudiantesDto
            {
                Id = estudiantesModel.Id,
                Code = estudiantesModel.Code,
                Password = estudiantesModel.Password,
                Name = estudiantesModel.Name,
                Apellidos = estudiantesModel.Apellidos,
                Rol = estudiantesModel.Rol,
                Email = estudiantesModel.Email,
                Telefono = estudiantesModel.Telefono,
                Estado = estudiantesModel.Estado,
                FechaRegistro = estudiantesModel.FechaRegistro
            };
        }
        public static Estudiantes ToEstudiantesFromCreateDTO(this CreateEstudiantesRequestDtos EstudiantesDto)
        {
                return new Estudiantes{
                Code = EstudiantesDto.Code,
                Password = EstudiantesDto.Password,
                Name = EstudiantesDto.Name,
                Apellidos = EstudiantesDto.Apellidos,
                Rol = EstudiantesDto.Rol,
                Email = EstudiantesDto.Email,
                Telefono = EstudiantesDto.Telefono,
                Estado = EstudiantesDto.Estado,
                FechaRegistro = EstudiantesDto.FechaRegistro
                };          

        }
    }

}