using CadJogosMVC.DAO;
using CadJogosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadJogosMVC.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult Listagem()
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                var listaJogos = dao.Listar();

                return View("listagem", listaJogos);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Create()
        {
            try
            {
                var jogo = new JogoViewModel();               
                jogo.Data = DateTime.Now;
                return View("Tela", jogo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

      
        public IActionResult Salvar(JogoViewModel jogo)
        {
            try
            {
                JogoDAO dao = new JogoDAO();                
                dao.Incluir(jogo);
                return RedirectToAction("listagem");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


       
    }
}
