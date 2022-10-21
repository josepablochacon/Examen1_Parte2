using Examen1_Parte2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1_Parte2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                using (accessEntities2 db = new accessEntities2())
                {




                    var contado = db.facturas.Where(factura => factura.observaciones.Equals("Factura de contado")).ToList();
                    var credito = db.facturas.Where(factura => factura.observaciones.Equals("Factura de credito")).ToList();


                    List<facturas_contado> Contado = db.facturas_contado.ToList();
                    

                    foreach (facturas factura in credito)
                    {
                        facturas_contado facturas_Contado = new facturas_contado();

                        facturas_Contado.id = factura.id;
                        facturas_Contado.numeroFactura = factura.numeroFactura;
                        facturas_Contado.monto = factura.monto;
                        facturas_Contado.mes = factura.mes;

                        Contado.Add(facturas_Contado);
                        db.facturas_contado.Add(facturas_Contado);
                        db.SaveChanges();
                        return null;
                    }

                    List<facturas_credito> Credito = db.facturas_credito.ToList();

                    foreach (facturas factura in credito)
                    {
                        facturas_credito facturas_credito = new facturas_credito();

                        facturas_credito.id = factura.id;
                        facturas_credito.numeroFactura = factura.numeroFactura;
                        facturas_credito.monto = factura.monto;
                        facturas_credito.mes = factura.mes;

                        Credito.Add(facturas_credito);
                        db.facturas_credito.Add(facturas_credito);
                        db.SaveChanges();
                        return null;
                    }



                    
                    for (int i = 1; i < 13; i++)
                    {
                        
                        decimal ContadoMonto = ((decimal?)db.facturas.Where(x => x.observaciones == "Factura de contado").Where(x => x.mes == i).Sum(s => (decimal?)s.monto)).GetValueOrDefault();
                        consolidado_contado MontoContado = new consolidado_contado();
                        MontoContado.id = db.consolidado_contado.Count();
                        MontoContado.mes = i;
                        MontoContado.total = ContadoMonto;

                        if (MontoContado.total > 0)
                        {
                            db.consolidado_contado.Add(MontoContado);
                            db.SaveChanges();
                        }
                    }


                    var debbug = 1;


                }
            }



          


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}