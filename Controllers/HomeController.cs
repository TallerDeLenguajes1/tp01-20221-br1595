using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tp01_20221_br1595.Models;
using AppProvincias.APIs;

namespace tp01_20221_br1595.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Problema1(string Numero)
        {
            try
            {
                string Resultado = "";
                int b = int.Parse(Numero);

                Resultado = Convert.ToString(b * b);
                return "El cuadrado de " + b + " es igual a " + Resultado;

            }
            catch(FormatException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
            catch(OverflowException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
        }

        public string Problema2(string Numero1, string Numero2)
        {
            try
            {
                float a = float.Parse(Numero1);
                float b = float.Parse(Numero2);
                float Operacion = a / b;

                var Resultado = Operacion.ToString("0.###");
                return a + " / " + b + " = " + Resultado;

            }
            catch (FormatException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
            catch (OverflowException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
            catch (DivideByZeroException Ex)
            {
                return "No es posible dividir un número en cero" + Ex.Message;
            }
        }

        public string Problema3()
        {
            APIProvincias apiProvincias = new APIProvincias();
            List<Provincia> prov = apiProvincias.GetListadoDeProvincias();
            
            string ListadoProvincias = "";
            for (int indice=0; indice < prov.Count; indice++)
            {
                ListadoProvincias += prov[indice].nombre + " - id = " + prov[indice].id + "\n";
            }
                return ListadoProvincias;
        }
        public string Problema4(string Numero1, string Numero2)
        {
            try
            {
                float a = float.Parse(Numero1);
                float b = float.Parse(Numero2);
                float Operacion = a / b;

                var Resultado = Operacion.ToString("0.###");
                return "Kilometros por litro: " + Resultado;

            }
            catch (FormatException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
            catch (OverflowException Ex)
            {
                return "Error en el ingreso de datos" + Ex.Message;
            }
            catch (DivideByZeroException Ex)
            {
                return "No es posible dividir un número en cero" + Ex.Message;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
