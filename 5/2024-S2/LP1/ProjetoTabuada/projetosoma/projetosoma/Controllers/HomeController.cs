using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetosoma.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace projetosoma.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult EfetuaSoma(int valor1, int valor2)
        {
            ResultadoViewModel resultadoView = new ResultadoViewModel();
            resultadoView.Valor1 = valor1;
            resultadoView.Valor2 = valor2;
            resultadoView.Resultado = valor1 + valor2;

            return View("Index", resultadoView);
        }



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ResultadoViewModel model = new ResultadoViewModel();
            return View(model);
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
    }
}
