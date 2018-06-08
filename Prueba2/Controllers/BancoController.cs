using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba2.Datos;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class BancoController : Controller
    {
        public BancoController()
        {
            
        }
        public ActionResult Index()
        {
            return View(BancoDb.ListaBancos);
        }

        public ActionResult Details(int id)
        {
            var banco = BancoDb.ListaBancos.Find(x => x.BancoId == id);
            return View(banco);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("BancoId,Nombre,Direccion,FechaRegistro")] Banco pBanco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (BancoDb.ListaBancos.Count == 0)
                        pBanco.BancoId = 1;
                    else
                        pBanco.BancoId = BancoDb.ListaBancos.Max(x => x.BancoId) + 1;

                    BancoDb.ListaBancos.Add(pBanco);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var banco = BancoDb.ListaBancos.Find(x => x.BancoId == id);
            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("BancoId,Nombre,Direccion,FechaRegistro")] Banco pBanco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var banco = BancoDb.ListaBancos.Find(x => x.BancoId == id);
                    banco.Nombre = pBanco.Nombre;
                    banco.Direccion = pBanco.Direccion;
                    banco.FechaRegistro = pBanco.FechaRegistro;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var banco = BancoDb.ListaBancos.Find(x => x.BancoId == id);
            return View(banco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BancoDb.ListaBancos.RemoveAll(x => x.BancoId == id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}