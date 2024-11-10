using ConsultaCEPViaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace ConsultaCEPViaAPI.Controllers
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


        public IActionResult ConsultaEndereco(string estado, string cidade, string rua)
        {
            try
            {
                var proxy = new WebProxy
                {
                    Address = new Uri("http://proxycefsa.cefsa.corp.local:8080"),
                    BypassProxyOnLocal = true,
                    UseDefaultCredentials = true, //não informaremos usuário e senha
                };
                var handler = new HttpClientHandler();
                handler.Proxy = proxy;
                using (var httpClient = new HttpClient(handler))
                {
                    string url = $"http://viacep.com.br/ws/{estado}/{cidade}/{rua}/json/";
                    using (var response = httpClient.GetAsync(url).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string resposta = response.Content.ReadAsStringAsync().Result;
                            return Content(resposta);
                        }
                        else
                        {
                            throw new Exception("Erro ao consultar. Code: " + response.StatusCode);
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }
    }
}
