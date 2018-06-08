using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prueba2.Datos;
using Prueba2.Models;

namespace Prueba2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            OrdenPagoDb.ListaMoneda.Add(new Moneda { MonedaId = 1, NombreMoneda = "Soles" });
            OrdenPagoDb.ListaMoneda.Add(new Moneda { MonedaId = 2, NombreMoneda = "Dolares" });

            OrdenPagoDb.ListaEstado.Add(new Estado { EstadoId = 1, NombreEstado = "Pagada" });
            OrdenPagoDb.ListaEstado.Add(new Estado { EstadoId = 1, NombreEstado = "Declinada" });
            OrdenPagoDb.ListaEstado.Add(new Estado { EstadoId = 1, NombreEstado = "Fallida" });
            OrdenPagoDb.ListaEstado.Add(new Estado { EstadoId = 1, NombreEstado = "Anulada" });

            BancoDb.ListaBancos.Add(new Banco { BancoId = 1, Nombre = "BCP", Direccion = "Chorrillos", FechaRegistro = DateTime.Now });
            BancoDb.ListaBancos.Add(new Banco { BancoId = 2, Nombre = "Continental", Direccion = "San isidro", FechaRegistro = DateTime.Now });
            BancoDb.ListaBancos.Add(new Banco { BancoId = 3, Nombre = "Interbank", Direccion = "San borja", FechaRegistro = DateTime.Now });

            SucursalDb.Lista.Add(new Sucursal { SucursalId = 1, Nombre = "BCP Surco", Direccion = "Surco", FechaRegistro = DateTime.Now, BancoId = 1, BancoAsignado = new Banco { BancoId = 1, Nombre = "BCP", Direccion = "Chorrillos", FechaRegistro = DateTime.Now } });
            SucursalDb.Lista.Add(new Sucursal { SucursalId = 2, Nombre = "BCP Lince", Direccion = "Lince", FechaRegistro = DateTime.Now, BancoId = 1, BancoAsignado = new Banco { BancoId = 1, Nombre = "BCP", Direccion = "Chorrillos", FechaRegistro = DateTime.Now } });
            SucursalDb.Lista.Add(new Sucursal { SucursalId = 3, Nombre = "Continental Barranco", Direccion = "Barranco", FechaRegistro = DateTime.Now, BancoId = 1, BancoAsignado = new Banco { BancoId = 2, Nombre = "Continental", Direccion = "San isidro", FechaRegistro = DateTime.Now } });

            OrdenPagoDb.ListaPago.Add
                (
                    new OrdenPago
                    {
                        OrdenPagoId = 1,
                        EstadoId = 1,
                        EstadoPago = new Estado
                        {
                            EstadoId = 1,
                            NombreEstado = "Pagada"
                        },
                        FechaPago = DateTime.Now,
                        MonedaId = 1,
                        MonedaPago = new Moneda
                        {
                            MonedaId = 1,
                            NombreMoneda = "Soles"
                        },
                        Monto = 100,
                        SucursalId = 1,
                        SucursalPago = new Sucursal
                        {
                            SucursalId = 1,
                            Nombre = "BCP Surco",
                            Direccion = "Surco",
                            FechaRegistro = DateTime.Now,
                            BancoId = 1,
                            BancoAsignado = new Banco
                            {
                                BancoId = 1,
                                Nombre = "BCP",
                                Direccion = "Chorrillos",
                                FechaRegistro = DateTime.Now
                            }
                        }
                    }
                );
        }
    }
}
