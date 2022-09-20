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
            var escuela = _context.Escuelas.FirstOrDefault();
            curso.Id = Guid.NewGuid().ToString();
            curso.EscuelaId = escuela.Id;
            _context.Cursos.Add(curso);
            _context.SaveChanges();

            return View("MultiCurso", _context.Cursos.ToList());
        }
        else
        {
            return View(curso);
        }
    }
    public CursoController(EscuelaContext context)
    {
        _context = context;
    }
}