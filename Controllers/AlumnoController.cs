using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class  AlumnoController: Controller
{
    private EscuelaContext _context;
    public IActionResult Index(string id)
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        if(id == null)
        {        
            return View("MultiAlumno",_context.Alumnos.ToList());
        }else
        {
            var alumno = from alum in _context.Alumnos
                         where alum.Id == id
                         select alum;
        
            return View(alumno.SingleOrDefault());
        }
        
    }
    public IActionResult MultiAlumno()
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        return View( _context.Alumnos.ToList());
    }
    public AlumnoController(EscuelaContext context)
    {
        _context = context;
    }
}