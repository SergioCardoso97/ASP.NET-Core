using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class CursoController : Controller
{
    private EscuelaContext _context;
    public IActionResult Index(string id)
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        if (id == null)
        {
            return View("MultiCurso", _context.Cursos.ToList());
        }
        else
        {
            var curso = from cur in _context.Cursos
                        where cur.Id == id
                        select cur;

            return View(curso.SingleOrDefault());
        }

    }
    public IActionResult MultiCurso()
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        return View(_context.Cursos.ToList());
    }
    public IActionResult Create()
    {
        ViewBag.Fecha = DateTime.Now;
        return View();
    }
    [HttpPost]
    public IActionResult Create(Curso curso)
    {
        ViewBag.Fecha = DateTime.Now;
        if (ModelState.IsValid)
        {
            curso.EscuelaId = _context.Escuelas.FirstOrDefault().Id;
            curso.Id = Guid.NewGuid().ToString();
            _context.Cursos.Add(curso);
            _context.SaveChanges();
            return RedirectToAction("MultiCurso","Curso");
        }
        else
        {
            return View(curso);
        }
    }
    public IActionResult Update(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        var curso = _context.Cursos.Find(id);
        return View(curso);
    }
    [HttpPost]
    public IActionResult Update(Curso curso)
    {
        ViewBag.Fecha = DateTime.Now;

        if (ModelState.IsValid)
        {
            var cursoUpdate = (from cur in _context.Cursos
                            where cur.Id == curso.Id
                            select cur).SingleOrDefault();
            if (cursoUpdate != null)
            {
                cursoUpdate.Nombre = curso.Nombre;
                cursoUpdate.Jornada = curso.Jornada;
                cursoUpdate.Dirección = curso.Dirección;
                _context.Cursos.Update(cursoUpdate);
                _context.SaveChanges();
                return RedirectToAction("MultiCurso","Curso");
            }
            else
            {
                return View(curso);
            }
        }
        else
        {
            return View(curso);
        }
    }
    public IActionResult Delete(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        _context.Cursos.Remove(_context.Cursos.Find(id));
        _context.SaveChanges();
        return View("MultiCurso",_context.Cursos.ToList());
    }

    public CursoController(EscuelaContext context)
    {
        _context = context;
    }
}