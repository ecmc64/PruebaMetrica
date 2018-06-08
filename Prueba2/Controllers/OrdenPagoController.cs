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
    public class OrdenPagoController : Controller
    {
        public ActionResult Index()
        {
            return View(OrdenPagoDb.ListaPago);
        }

        public ActionResult Details(int id)
        {
            var ordenPago = OrdenPagoDb.ListaPago.Find(x => x.OrdenPagoId == id);
            return View(ordenPago);
        }

        public ActionResult Create()
        {
            ViewData["SucursalId"] = new SelectList(SucursalDb.Lista, "SucursalId", "Nombre");
            ViewData["MonedaId"] = new SelectList(OrdenPagoDb.ListaMoneda, "MonedaId", "NombreMoneda");
            ViewData["EstadoId"] = new SelectList(OrdenPagoDb.ListaEstado, "EstadoId", "NombreEstado");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("OrdenPagoId,Monto,MonedaId,EstadoId,SucursalId,FechaPago")] OrdenPago pOrdenPago)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var estado = OrdenPagoDb.ListaEstado.Find(x => x.EstadoId == pOrdenPago.EstadoId);
                    var moneda = OrdenPagoDb.ListaMoneda.Find(x => x.MonedaId == pOrdenPago.MonedaId);
                    var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == pOrdenPago.SucursalId);

                    pOrdenPago.MonedaPago = moneda;
                    pOrdenPago.EstadoPago = estado;
                    pOrdenPago.SucursalPago = sucursal;
                    if (OrdenPagoDb.ListaPago.Count == 0)
                        pOrdenPago.OrdenPagoId = 1;
                    else
                        pOrdenPago.OrdenPagoId = OrdenPagoDb.ListaPago.Max(x => x.OrdenPagoId) + 1;

                    OrdenPagoDb.ListaPago.Add(pOrdenPago);
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
            var ordenPago = OrdenPagoDb.ListaPago.Find(x => x.OrdenPagoId == id);
            ViewData["SucursalId"] = new SelectList(SucursalDb.Lista, "SucursalId", "Nombre", ordenPago.SucursalId);
            ViewData["MonedaId"] = new SelectList(OrdenPagoDb.ListaMoneda, "MonedaId", "NombreMoneda", ordenPago.MonedaId);
            ViewData["EstadoId"] = new SelectList(OrdenPagoDb.ListaEstado, "EstadoId", "NombreEstado", ordenPago.EstadoId);

            return View(ordenPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("OrdenPagoId,Monto,MonedaId,EstadoId,SucursalId,FechaPago")] OrdenPago pOrdenPago)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var ordenPago = OrdenPagoDb.ListaPago.Find(x => x.OrdenPagoId == id);
                    ordenPago.Monto = pOrdenPago.Monto;
                    ordenPago.MonedaId = pOrdenPago.MonedaId;
                    ordenPago.SucursalId = pOrdenPago.SucursalId;
                    ordenPago.EstadoId = pOrdenPago.EstadoId;

                    var estado = OrdenPagoDb.ListaEstado.Find(x => x.EstadoId == pOrdenPago.EstadoId);
                    var moneda = OrdenPagoDb.ListaMoneda.Find(x => x.MonedaId == pOrdenPago.MonedaId);
                    var sucursal = SucursalDb.Lista.Find(x => x.SucursalId == pOrdenPago.SucursalId);

                    ordenPago.MonedaPago = moneda;
                    ordenPago.EstadoPago = estado;
                    ordenPago.SucursalPago = sucursal;
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
            var ordenPago = OrdenPagoDb.ListaPago.Find(x => x.OrdenPagoId == id);
            return View(ordenPago);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                OrdenPagoDb.ListaPago.RemoveAll(x => x.OrdenPagoId == id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}