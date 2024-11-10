using EX_10._2.Enumeradores;
using EX_10._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EX_10._2.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Calcular(double valor,
                                      EnumMedidas unidadeMedida)
        {
            double resposta = 0;
            switch (unidadeMedida)
            {
                case EnumMedidas.centrimetro:
                    resposta = valor * 100;
                    break;
                case EnumMedidas.milimetro:
                    resposta = valor * 1000;
                    break;
                case EnumMedidas.quilometro:
                    resposta = valor / 1000;
                    break;
                case EnumMedidas.pe:
                    resposta = valor * 3.281;
                    break;
                case EnumMedidas.milha:
                    resposta = valor / 1609;
                    break;
            }

            return View("Index", resposta);
        }

    }
}
