using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        List<SelectListItem> lst = new List<SelectListItem>();
        foreach (var curso in _context.Cursos)
        {
            lst.Add(new SelectListItem() { Text = curso.Nombre, Value = curso.Id });
        }
        ViewBag.Cursos = lst;
        return View( _context.Alumnos.ToList());
    }
    public IActionResult Create()
    {
        ViewBag.Fecha = DateTime.Now;
        List<SelectListItem> lst = new List<SelectListItem>();
        foreach (var curso in _context.Cursos)
        {
            lst.Add(new SelectListItem() { Text = curso.Nombre, Value = curso.Id });
        }
        ViewBag.Cursos = lst;
        return View();
    }
    [HttpPost]
    public IActionResult Create(Alumno alumno)
    {
        ViewBag.Fecha = DateTime.Now;
        if (ModelState.IsValid)
        {
            alumno.Id = Guid.NewGuid().ToString();
            alumno.CursoId = alumno.CursoId;
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return RedirectToAction("MultiAlumno","Alumno");
        }
        else
        {
            return View(alumno);
        }
    }
    public IActionResult Update(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        var alumno = _context.Alumnos.Find(id);
        List<SelectListItem> lst = new List<SelectListItem>();
        foreach (var curso in _context.Cursos)
        {
            lst.Add(new SelectListItem() { Text = curso.Nombre, Value = curso.Id });
        }
        ViewBag.Cursos = lst;
        return View(alumno);
    }
    [HttpPost]
    public IActionResult Update(Alumno alumno)
    {
        ViewBag.Fecha = DateTime.Now;

        if (ModelState.IsValid)
        {
            var alumnoUpdate = (from cur in _context.Alumnos
                            where cur.Id == alumno.Id
                            select cur).SingleOrDefault();
            if (alumnoUpdate != null)
            {
                alumnoUpdate.Nombre = alumno.Nombre;
                alumnoUpdate.CursoId = alumno.CursoId;
                alumnoUpdate.Sexo = alumno.Sexo;
                alumnoUpdate.Edad = alumno.Edad;
                _context.Alumnos.Update(alumnoUpdate);
                _context.SaveChanges();
                return RedirectToAction("MultiAlumno","Alumno");
            }
            else
            {
                return View(alumno);
            }
        }
        else
        {
            return View(alumno);
        }
    }
    public IActionResult Delete(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        _context.Alumnos.Remove(_context.Alumnos.Find(id));
        _context.SaveChanges();
        return RedirectToAction("MultiAlumno","Alumno");
    }
    public AlumnoController(EscuelaContext context)
    {
        _context = context;
    }
}