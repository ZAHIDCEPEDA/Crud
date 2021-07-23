using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    [Authorize]
    public class RegistrosController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RegistrosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Authorize(Roles = "Administrador,Usuario")]
        public IActionResult Index()
        {
            List<Registro> registros = new List<Registro>();
            registros = _applicationDbContext.Registro.ToList();
            return View(registros);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Create(Registro registro)
        {
            try
            {
                registro.Estado = 1;
                _applicationDbContext.Add(registro);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(registro);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador,Usuario")]
        public IActionResult Details(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            if (registro == null)
                return RedirectToAction("Index");
            return View(registro);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            if (registro == null)
                return RedirectToAction("Index");
            return View(registro);
        }
        [Authorize(Roles = "Administrador,Usuario,")]
        [HttpPost]
        public IActionResult Edit(int id, Registro registro)
        {
            if (id != registro.Codigo)
                return RedirectToAction("Index");
            try
            {
                _applicationDbContext.Update(registro);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(registro);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                _applicationDbContext.Remove(registro);
                _applicationDbContext.SaveChanges();
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
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                registro.Estado = 0;
                _applicationDbContext.Update(registro);
                _applicationDbContext.SaveChanges();
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
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                registro.Estado = 1;
                _applicationDbContext.Update(registro);
                _applicationDbContext.SaveChanges();
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
