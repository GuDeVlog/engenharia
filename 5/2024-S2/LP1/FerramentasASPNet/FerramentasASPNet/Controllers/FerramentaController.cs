using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerramentasASPNet.DAO;
using FerramentasASPNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerramentasASPNet.Controllers
{
    public class FerramentaController : Controller
    {
        public IActionResult Index()
        {
            FerramentaDAO dao = new FerramentaDAO();
            var lista = dao.Listagem();
            return View(lista);
        }



        public IActionResult Create()
        {
            FerramentaViewModel f = new FerramentaViewModel();
            ViewBag.operacao = "I";
            return View("Form", f);
        }


        public IActionResult Edit(int id)
        {
            FerramentaDAO dao = new FerramentaDAO();
            FerramentaViewModel f = dao.Consulta(id);
            ViewBag.operacao = "A";
            return View("Form", f);
        }

        public IActionResult Salvar(FerramentaViewModel f,
                                    string operacao)
        {
            FerramentaDAO dao = new FerramentaDAO();

            ModelState.Clear();
            if (string.IsNullOrEmpty(f.Descricao))
                ModelState.AddModelError("Descricao", "Campo obrigatório!");
            if (f.FabricanteId <= 0)
                ModelState.AddModelError("FabricanteId", "Campo obrigatório!");

            if (ModelState.IsValid)
            {
                if (operacao == "I")
                    dao.Inserir(f);
                else
                    dao.Alterar(f);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.operacao = operacao;
                return View("form", f);
            }
        }


        public IActionResult Apagar(int id)
        {
            FerramentaDAO dao = new FerramentaDAO();
            dao.Excluir(id);
            return RedirectToAction("Index");
        }





    }
}