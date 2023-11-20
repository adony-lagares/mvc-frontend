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
      if (ModelState.IsValid)
      {
        _context.Contatos.Add(contact);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
      }
      return View(contact);
    }

    public IActionResult Edit(int id)
    {
      var contato = _context.Contatos.Find(id);

      if (contato == null)
        return NotFound();

      return View();
    }

    [HttpPost]
    public IActionResult Edit(Contato contact)
    {
      var contactData = _context.Contatos.Find(contact.Id);

      contactData.Name = contact.Name;
      contactData.PhoneNumber = contact.PhoneNumber;
      contactData.Active = contact.Active;

      _context.Contatos.Update(contactData);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
      var contact = _context.Contatos.Find(id);

      if (contact == null)
        return RedirectToAction(nameof(Index));

      return View(contact);

    }


    public IActionResult Delete(int id)
    {
      var contact = _context.Contatos.Find(id);

      if (contact == null)
        return RedirectToAction(nameof(Index));

      return View(contact);
    }

    [HttpPost]
    public IActionResult Delete(Contato contact)
    {
      var ContactData = _context.Contatos.Find(contact.Id);
      _context.Contatos.Remove(ContactData);
      _context.SaveChanges();

      return RedirectToAction(nameof(Index));
    }
  }
}