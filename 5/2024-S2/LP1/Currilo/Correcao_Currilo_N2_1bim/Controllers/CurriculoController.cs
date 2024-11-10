using Correcao_Currilo_N2_1bim.DAO;
using Correcao_Currilo_N2_1bim.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correcao_Currilo_N2_1bim.Controllers
{
    public class CurriculoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                return View(dao.Listagem());
            }
            catch (Exception erro)
            {
                return View("Erro", erro.ToString());
            }
        }


        public IActionResult NovoRegistro()
        {
            try
            {
                ViewBag.operacao = "I";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel cv = new CurriculoViewModel();
                cv.DataNascimento = DateTime.Now;
                cv.Id = dao.ProximoId();

                return View("Form", cv);
            }
            catch (Exception erro)
            {
                return View("Erro", erro.ToString());
            }
        }



        public IActionResult Salvar(CurriculoViewModel cv, string operacao)
        {
            try
            {
                var dao = new CurriculoDAO();
                if (operacao == "I")
                    dao.Inserir(cv);
                else
                    dao.Alterar(cv);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }



        public IActionResult Editar(int id)
        {
            try
            {
                ViewBag.operacao = "A";
                CurriculoDAO dao = new CurriculoDAO();
                CurriculoViewModel cv = dao.Consulta(id);
                return View("Form", cv);
            }
            catch (Exception erro)
            {
                return View("Erro", erro.ToString());
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Erro", erro.ToString());
            }
        }



        public IActionResult Exibir(int id)
        {
            try
            {
                CurriculoDAO dao = new CurriculoDAO();
                var cv = dao.Consulta(id);
                return View("ExibirCurriculoFormatado", cv);
            }
            catch (Exception erro)
            {
                return View("Erro", erro.ToString());
            }
        }

    }
}
