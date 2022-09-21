using System;
using System.Collections.Generic;

namespace ASP.NET_Core.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        public List<Evaluación> ?Evaluaciones { get; set; }
        public string ?CursoId { get; set; }
        public Curso ?Curso { get; set; }
        public string ?Sexo { get; set; }
        public string ?Edad { get; set; }
    }
}