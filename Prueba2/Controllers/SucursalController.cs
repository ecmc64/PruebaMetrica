using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba2.Datos;
using Prueba2.Models;

namespace Prueba2.Controllers
{
    public class SucursalController : Controller
    {
        public ActionResult Index()
        {
            return View(SucursalDb.Lista);
        }

        public ActionResult Details(int id)
        {
            var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == id);
            return View(sucursal);
        }

        public ActionResult Create()
        {
            ViewData["BancoId"] = new SelectList(BancoDb.ListaBancos, "BancoId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("SucursalId,Nombre,Direccion,FechaRegistro,BancoId")] Sucursal pSucursal)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (SucursalDb.Lista.Count == 0)
                        pSucursal.SucursalId = 1;
                    else
                        pSucursal.SucursalId = SucursalDb.Lista.Max(x => x.SucursalId) + 1;

                    var banco = BancoDb.ListaBancos.Find(x => x.BancoId == pSucursal.BancoId);
                    pSucursal.BancoAsignado = banco;
                    SucursalDb.Lista.Add(pSucursal);
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
            var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == id);
            ViewData["BancoId"] = new SelectList(BancoDb.ListaBancos, "BancoId", "Nombre",sucursal.BancoId);
            return View(sucursal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("SucursalId,Nombre,Direccion,FechaRegistro,BancoId")] Sucursal pSucursal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == id);

                    sucursal.Nombre = pSucursal.Nombre;
                    sucursal.Direccion = pSucursal.Direccion;
                    sucursal.FechaRegistro = pSucursal.FechaRegistro;
                    sucursal.BancoId = pSucursal.BancoId;

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
            var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == id);
            ViewData["BancoId"] = new SelectList(BancoDb.ListaBancos, "BancoId", "Nombre", sucursal.BancoId);
            return View(sucursal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    SucursalDb.Lista.RemoveAll(x => x.SucursalId == id);
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