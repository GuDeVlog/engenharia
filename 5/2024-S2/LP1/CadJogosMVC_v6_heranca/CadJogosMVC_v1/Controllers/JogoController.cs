using CadJogosMVC_v1.DAO;
using CadJogosMVC_v1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace CadJogosMVC_v1.Controllers
{
    public class JogoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                return View("Listagem", dao.Listagem());
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }

        public IActionResult NovoJogo()
        {
            JogoViewModel jogo = new JogoViewModel();
            jogo.Id = (new JogoDAO()).ProximoId();
            jogo.DataAquisicao = DateTime.Now;
            MontaComboCategoria();
            return View("Tela", jogo);
        }


        public IActionResult Salvar(JogoViewModel jogo)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                if (dao.Consulta(jogo.Id) == null)
                    dao.Insert(jogo);
                else
                    dao.Update(jogo);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }


        public IActionResult Editar(int id)
        {
            try
            {
                MontaComboCategoria();
                JogoDAO dao = new JogoDAO();
                return View("Tela", dao.Consulta(id));
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }

        }


        public IActionResult Delete(int id)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                dao.Delete(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }


        private void MontaComboCategoria()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            CategoriaDAO dao = new CategoriaDAO();
            foreach (var c in dao.Listagem())
                lista.Add(
                    new SelectListItem(c.Descricao, c.Id.ToString()));

            ViewBag.Categorias = lista;
        }



        public IActionResult ExibeConsultaAvancada()
        {
            try
            {
                MontaComboCategoria();
                ViewBag.Categorias.Insert(0, new SelectListItem("TODAS", "0"));
                return View("ConsultaAvancada");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }
        }



        public IActionResult ObtemDadosConsultaAvancada(
                             string descricao,
                             int categoria,
                             DateTime dataInicial,
                             DateTime dataFinal)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                if (string.IsNullOrEmpty(descricao))
                    descricao = "";
                if (dataInicial.Date == Convert.ToDateTime("01/01/0001"))
                    dataInicial = SqlDateTime.MinValue.Value;
                if (dataFinal.Date == Convert.ToDateTime("01/01/0001"))
                    dataFinal = SqlDateTime.MaxValue.Value;
                var lista = dao.ConsultaAvancadaJogos(descricao, categoria, dataInicial, dataFinal);
                return PartialView("pvGridJogos", lista);
            }
            catch (Exception erro)
            {
                return Json(new { erro = true, msg = erro.Message });
            }
        }


    }
}
