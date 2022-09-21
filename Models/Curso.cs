using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public override string Nombre {set;get;}
        [Required(ErrorMessage = "El campo es requerido")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> ?Asignaturas{ get; set; }
        public List<Alumno> ?Alumnos{ get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string ?Dirección { get; set; }
        public string ?EscuelaId { get; set; }
        public Escuela ?Escuela { get; set; }

    }
}