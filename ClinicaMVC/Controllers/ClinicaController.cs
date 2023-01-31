using Clinica.Data;
using ClinicaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Clinica.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly DbClinicaContext context;

        public ClinicaController(DbClinicaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var medicos = context.Medicos.ToList();
            return View(medicos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View("Create", medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var medico = ObtenerUno(id);
            if (medico == null)
                return NotFound();
            else
                return View("Details", medico);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medico = ObtenerUno(id);
            if (medico == null)
                return NotFound();
            else
                return View("Delete", medico);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var medico = ObtenerUno(id);
            if (medico == null)
                return NotFound();
            else
            {
                context.Medicos.Remove(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var medico = new Medico();
            return View("Edit", medico);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Medico m)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Entry(m).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private Medico ObtenerUno(int id)
        {
            return context.Medicos.Find(id);
        }
    }
}
