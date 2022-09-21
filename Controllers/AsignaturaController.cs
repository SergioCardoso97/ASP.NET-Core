using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Core.Controllers;

public class  AsignaturaController: Controller
{
    private EscuelaContext _context;
    [Route("Asignatura/Index/")]
    [Route("Asignatura/Index/{asignaturaId}")]
    public IActionResult Index(string asignaturaId)
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        if(asignaturaId == null)
        {        
            return View("MultiAsignatura",_context.Asignaturas.ToList());
        }else
        {
            var asignatura = from asig in _context.Asignaturas
                         where asig.Id == asignaturaId
                         select asig;
        
            return View(asignatura.SingleOrDefault());
        }
        
    }
    public IActionResult MultiAsignatura()
    {
        ViewBag.CosaDinamica = "La Monja";
        ViewBag.Fecha = DateTime.Now;
        List<SelectListItem> lst = new List<SelectListItem>();
        foreach (var curso in _context.Cursos)
        {
            lst.Add(new SelectListItem() { Text = curso.Nombre, Value = curso.Id });
        }
        ViewBag.Cursos = lst;
        return View(_context.Asignaturas.ToList());
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
    public IActionResult Create(Asignatura asignatura)
    {
        ViewBag.Fecha = DateTime.Now;
        if (ModelState.IsValid)
        {
            asignatura.Id = Guid.NewGuid().ToString();
            asignatura.CursoId = asignatura.CursoId;
            _context.Asignaturas.Add(asignatura);
            _context.SaveChanges();
            return RedirectToAction("MultiAsignatura","Asignatura");
        }
        else
        {
            return View(asignatura);
        }
    }
    public IActionResult Update(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        var asignatura = _context.Asignaturas.Find(id);
        List<SelectListItem> lst = new List<SelectListItem>();
        foreach (var curso in _context.Cursos)
        {
            lst.Add(new SelectListItem() { Text = curso.Nombre, Value = curso.Id });
        }
        ViewBag.Cursos = lst;
        return View(asignatura);
    }
    [HttpPost]
    public IActionResult Update(Asignatura asignatura)
    {
        ViewBag.Fecha = DateTime.Now;

        if (ModelState.IsValid)
        {
            var asignaturaUpdate = (from cur in _context.Asignaturas
                            where cur.Id == asignatura.Id
                            select cur).SingleOrDefault();
            if (asignaturaUpdate != null)
            {
                asignaturaUpdate.Nombre = asignatura.Nombre;
                asignaturaUpdate.CursoId = asignatura.CursoId;
                _context.Asignaturas.Update(asignaturaUpdate);
                _context.SaveChanges();
                return RedirectToAction("MultiAsignatura","Asignatura");
            }
            else
            {
                return View(asignatura);
            }
        }
        else
        {
            return View(asignatura);
        }
    }
    public IActionResult Delete(string id)
    {
        ViewBag.Fecha = DateTime.Now;
        _context.Asignaturas.Remove(_context.Asignaturas.Find(id));
        _context.SaveChanges();
        return RedirectToAction("MultiAsignatura","Asignatura");
    }
    public AsignaturaController(EscuelaContext context)
    {
        _context = context;
    }
}