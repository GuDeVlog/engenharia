using CorrecaoN21bim_dentista.DAO;
using CorrecaoN21bim_dentista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CorrecaoN21bim_dentista.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                var dao = new PacienteDAO();
                List<PacienteViewModel> lista = dao.Listagem();
                return View(lista);
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
                ViewBag.Operacao = "I";
                var paciente = new PacienteViewModel();
                PacienteDAO dao = new PacienteDAO();
                paciente.Id = dao.ProximoId();
                return View("Form", paciente);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                var dao = new PacienteDAO();
                PacienteViewModel paciente = dao.Consulta(id);
                if (paciente == null)
                    return RedirectToAction("index");
                else
                    return View("Form", paciente);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Salvar(PacienteViewModel paciente, string Operacao)
        {
            try
            {
                ValidaDados(paciente, Operacao);
                if (ModelState.IsValid)
                {
                    var dao = new PacienteDAO();
                    if (Operacao == "I")
                        dao.Inserir(paciente);
                    else
                        dao.Alterar(paciente);
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", paciente);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        private void ValidaDados(PacienteViewModel paciente, string operacao)
        {
            ModelState.Clear(); // limpa os erros criados automaticamente pelo Asp.net (que podem estar com msg em inglês)
            var dao = new PacienteDAO();
            if (paciente.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
            else
            {
                if (operacao == "I" && dao.Consulta(paciente.Id) != null)
                    ModelState.AddModelError("Id", "Código já está em uso.");
                if (operacao == "A" && dao.Consulta(paciente.Id) == null)
                    ModelState.AddModelError("Id", "Paciente não existe.");
            }

            if (string.IsNullOrEmpty(paciente.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
        }


        public IActionResult Delete(int id)
        {
            try
            {
                var dao = new PacienteDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

    }
}
