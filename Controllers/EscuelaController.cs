using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_Core.Models;

namespace ASP.NET_Core.Controllers;

public class  EscuelaController: Controller
{
    public IActionResult Index()
    {
        var escuela = new Escuela();
        escuela.AñoFundacion = 2005;
        escuela.EscuelaId = new Guid().ToString();
        escuela.Nombre = "Platzi School";
        ViewBag.CosaDinamica = "Cualquier Cosa";
        return View(escuela);
    }
}