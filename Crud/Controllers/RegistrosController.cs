using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RegistrosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            List<Registro> registros = new List<Registro>();
            registros = _applicationDbContext.Registro.ToList();
            return View(registros);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Registro registro)
        {
            try
            {
                _applicationDbContext.Add(registro);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(registro);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            if (registro == null)
                return RedirectToAction("Index");
            return View(registro);
        }
        [HttpPost]
        public IActionResult Edit(int id, Registro registro)
        {
            if (id != registro.Codigo)
                return RedirectToAction("Index");
            try
            {
                _applicationDbContext.Add(registro);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return View(registro);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Registro registro = _applicationDbContext.Registro.Where(z => z.Codigo == id).FirstOrDefault();
            try
            {
                _applicationDbContext.Add(registro);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
