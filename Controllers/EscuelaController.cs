using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class  EscuelaController: Controller
{
    private EscuelaContext _context;
    public IActionResult Index()
    {
        ViewBag.CosaDinamica = "Cualquier Cosa";
        var escuela =_context.Escuelas.FirstOrDefault();
        return View(escuela);
    }

    public EscuelaController(EscuelaContext context)
    {
        _context = context;
    }
}