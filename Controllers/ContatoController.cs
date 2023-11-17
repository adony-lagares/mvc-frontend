using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_frontend.Context;
using mvc_frontend.Models;

namespace mvc_frontend.Controllers
{
    public class ContatoController : Controller
    {

      private readonly AgendaContext _context;

      public ContatoController(AgendaContext context)
      {
        _context = context;
      }
      public IActionResult Index() 
      {
        var contacts = _context.Contatos.ToList();
        return View(contacts);
      }

      public IActionResult Create()
      {
        return View();
      }

      [HttpPost]
      public IActionResult Create(Contato contact)
      {
        if(ModelState.IsValid)
        {
          _context.Contatos.Add(contact);
          _context.SaveChanges();
          return RedirectToAction(nameof(Index));
        }
        return View(contact);
      }
    }
}