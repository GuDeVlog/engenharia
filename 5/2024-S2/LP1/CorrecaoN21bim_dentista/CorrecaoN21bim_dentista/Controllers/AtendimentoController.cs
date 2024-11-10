using CorrecaoN21bim_dentista.DAO;
using CorrecaoN21bim_dentista.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CorrecaoN21bim_dentista.Controllers
{
    public class AtendimentoController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                var dao = new AtendimentoDAO();
                List<AtendimentoViewModel> lista = dao.Listagem();
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
                PreparaListas();
                ViewBag.Operacao = "I";
                var a = new AtendimentoViewModel();
                AtendimentoDAO dao = new AtendimentoDAO();
                a.Id = dao.ProximoId();
                return View("Form", a);
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
                PreparaListas();
                ViewBag.Operacao = "A";
                var dao = new AtendimentoDAO();
                AtendimentoViewModel a = dao.Consulta(id);
                if (a == null)
                    return RedirectToAction("index");
                else
                    return View("Form", a);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Salvar(AtendimentoViewModel paciente, string Operacao)
        {
            try
            {
                ValidaDados(paciente, Operacao);
                if (ModelState.IsValid)
                {
                    var dao = new AtendimentoDAO();
                    if (Operacao == "I")
                        dao.Inserir(paciente);
                    else
                        dao.Alterar(paciente);
                    return RedirectToAction("index");
                }
                else
                {
                    PreparaListas();
                    ViewBag.Operacao = Operacao;
                    return View("Form", paciente);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        private void ValidaDados(AtendimentoViewModel atendimento, string operacao)
        {
            ModelState.Clear(); // limpa os erros criados automaticamente pelo Asp.net (que podem estar com msg em inglês)
            var dao = new AtendimentoDAO();
            if (atendimento.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
            else
            {
                if (operacao == "I" && dao.Consulta(atendimento.Id) != null)
                    ModelState.AddModelError("Id", "Código já está em uso.");
                if (operacao == "A" && dao.Consulta(atendimento.Id) == null)
                    ModelState.AddModelError("Id", "Id não existe.");
            }

            if (atendimento.Preco <= 0)
                ModelState.AddModelError("Preco", "Campo obrigatório.");

            if (atendimento.PacienteId <= 0)
                ModelState.AddModelError("PacienteId", "Campo obrigatório.");

            if (atendimento.TipoProcedimento <= 0)
                ModelState.AddModelError("TipoProcedimento", "Campo obrigatório.");
        }


        public IActionResult Delete(int id)
        {
            try
            {
                var dao = new AtendimentoDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        private void PreparaListas()
        {
            var Dao = new PacienteDAO();
            var pacientes = Dao.Listagem();
            List<SelectListItem> listaPacientes = new List<SelectListItem>();

            listaPacientes.Add(new SelectListItem("Selecione um paciente...", "0"));
            foreach (var p in pacientes)
            {
                SelectListItem item = new SelectListItem(p.Nome, p.Id.ToString());
                listaPacientes.Add(item);
            }
            ViewBag.Pacientes = listaPacientes;


            List<SelectListItem> listaProcedimentos = new List<SelectListItem>();
            listaProcedimentos.Add(new SelectListItem("Selecione um tipo...", "0"));
            listaProcedimentos.Add(new SelectListItem("Obturação", "1"));
            listaProcedimentos.Add(new SelectListItem("Limpeza", "2"));
            listaProcedimentos.Add(new SelectListItem("Canal", "3"));
            listaProcedimentos.Add(new SelectListItem("Extração", "4"));
            ViewBag.Procedimentos = listaProcedimentos;
        }

    }
}
