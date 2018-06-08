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
    [Produces("application/json")]
    [Route("api/Servicio")]
    public class ServicioController : Controller
    {
        // GET: api/Servicio
        [HttpGet]
        public IEnumerable<OrdenPago> Get()
        {
            return OrdenPagoDb.ListaPago;
        }


        [Route("api/Servicio/{pSucursalId}/{pMonedaId}")]
        [HttpGet]
        public IEnumerable<OrdenPago> Get(int pSucursalId, int pMonedaId)
        {
            return OrdenPagoDb.ListaPago.Where(x => x.SucursalId == pSucursalId && x.MonedaId == pMonedaId);
        }

        // GET: api/Servicio/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Servicio
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Servicio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
