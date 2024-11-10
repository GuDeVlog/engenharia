using cadFuncionarioMVC_V1.DAO;
using cadFuncionarioMVC_V1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cadFuncionarioMVC_V1.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.Lista();
                return View(dao.Lista());
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
                FuncionarioDAO dao = new FuncionarioDAO();
                FuncionarioViewModel f = new FuncionarioViewModel();
                f.Id = dao.ProximoId();

                ViewBag.Operacao = "I";
                return View("Form", f);
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
                FuncionarioDAO dao = new FuncionarioDAO();
                FuncionarioViewModel f = dao.Consulta(id);
                if (f != null)
                {
                    ViewBag.Operacao = "A";
                    return View("Form", f);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Salvar(FuncionarioViewModel f, string Operacao)
        {
            try
            {
                try
                {
                    FuncionarioDAO dao = new FuncionarioDAO();
                    if (f.Id <= 0)
                        ModelState.AddModelError("Id", "Id incorreto!");
                    else if (Operacao == "I" && dao.Consulta(f.Id) != null)
                        ModelState.AddModelError("Id", "Id em uso!");
                    else if (Operacao == "A" && dao.Consulta(f.Id) == null)
                        ModelState.AddModelError("Id", "Id não existe!");

                    if (string.IsNullOrEmpty(f.Nome))
                        ModelState.AddModelError("Nome", "Campo obrigatório");

                    if (ModelState.IsValid)
                    {
                        if (Operacao == "I")
                            dao.Inserir(f);
                        else
                            dao.Alterar(f);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Operacao = Operacao;
                        return View("Form", f);
                    }
                }
                catch (Exception erro) { return View("Error", new ErrorViewModel(erro.ToString())); }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Apagar(int id)
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

    }
}
