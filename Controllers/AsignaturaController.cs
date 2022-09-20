using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

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
        return View(_context.Asignaturas.ToList());
    }
    public AsignaturaController(EscuelaContext context)
    {
        _context = context;
    }
}