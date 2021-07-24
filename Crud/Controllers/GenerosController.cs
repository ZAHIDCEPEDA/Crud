using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    [Authorize]
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrador , Usuario")]
        // GET: GenerosController
        public ActionResult Index()
        {
            List<Genero> ltsgenero = _context.Generos.ToList();
            return View(ltsgenero);
        }
        [Authorize(Roles = "Administrador , Usuario")]
        // GET: GenerosController/Details/5
        public ActionResult Details(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(z=>z.Codigo==id);
            return View(genero);
        }
        [Authorize(Roles = "Administrador")]
        // GET: GenerosController/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        // POST: GenerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(genero);
                    _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "Administrador")]
        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(z => z.Codigo == id);
            return View(genero);
        }
        [Authorize(Roles = "Administrador")]
        // POST: GenerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {
            if (id != genero.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(genero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero registro = _context.Generos.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                _context.Remove(registro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero registro = _context.Generos.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                registro.Estado = 0;
                _context.Update(registro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero registro = _context.Generos.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                registro.Estado = 1;
                _context.Update(registro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
