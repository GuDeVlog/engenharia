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
                ViewBag.Operacao = "I";

                var jogo = new JogoViewModel();
                jogo.Data = DateTime.Now;
                return View("Tela", jogo);
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
                JogoDAO dao = new JogoDAO();
                var jogo = dao.Consulta(id);
                if (jogo == null)
                    return RedirectToAction("listagem");
                else
                    return View("Tela", jogo);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

        private void ValidaDados(JogoViewModel jogo, String Operacao)
        {
            JogoDAO dao = new JogoDAO();
            ModelState.Clear();
            if (jogo.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
            else if (Operacao == "I" && dao.Consulta(jogo.Id) != null)
                ModelState.AddModelError("Id", "Id já está em uso!");
            else if (Operacao == "A" && dao.Consulta(jogo.Id) == null)
                ModelState.AddModelError("Id", "Id não existe!");


            if (string.IsNullOrEmpty(jogo.Descricao))
                ModelState.AddModelError("Descricao", "Campo obrigatório");

            if (jogo.valor <= 0)
                ModelState.AddModelError("valor", "Campo obrigatório");

            if (jogo.CategoriaId <= 0)
                ModelState.AddModelError("CategoriaId", "Campo obrigatório");

            if (jogo.Data >= DateTime.Now)
                ModelState.AddModelError("Data", "Campo inválido. ");
        }


        public IActionResult Salvar(JogoViewModel jogo, String Operacao)
        {
            try
            {
                ValidaDados(jogo, Operacao);
                if (ModelState.IsValid)
                {
                    JogoDAO dao = new JogoDAO();
                    if (Operacao == "I")
                        dao.Incluir(jogo);
                    else
                        dao.Alterar(jogo);

                    return RedirectToAction("listagem");
                }
                else
                {
                    ViewBag.Operacao = Operacao;
                    return View("Tela", jogo);
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }


        public IActionResult Delete(int id)
        {
            try
            {
                JogoDAO dao = new JogoDAO();
                dao.Excluir(id);
                return RedirectToAction("listagem");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }

    }
}
