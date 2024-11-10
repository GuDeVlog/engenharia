using CadastroJogos.Controllers.DAO;
using CadastroJogos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CadastroJogos.Controllers
{
    public class JogoController : Controller
    {
        
            public IActionResult Index()
            {
                JogoDAO dao = new JogoDAO();
                List<JogoViewModel> lista = dao.Listagem();
                return View(lista);
            }

        
    }
}
