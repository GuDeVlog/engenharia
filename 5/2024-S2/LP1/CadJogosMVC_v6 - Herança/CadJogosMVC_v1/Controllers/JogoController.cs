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
            ViewBag.Operacao = "I";
            PreparaComboCategorias();

            return View("Tela", jogo);
        }


        private void PreparaComboCategorias()
        {
            CategoriaDAO dao = new CategoriaDAO();
            var lista = dao.Lista();

            List<SelectListItem> listaRetorno = new List<SelectListItem>();
            foreach (var categ in lista)
            {
                listaRetorno.Add(new SelectListItem(categ.Descricao, categ.Id.ToString()));
            }

            ViewBag.Categorias = listaRetorno;
        }


        private void ValidaDados(string operacao, JogoViewModel jogo)
        {
            ModelState.Clear();//apaga os eventuas erros em inglês

            JogoDAO dao = new JogoDAO();
            if (operacao == "I" && dao.Consulta(jogo.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso.");
            if (operacao == "A" && dao.Consulta(jogo.Id) == null)
                ModelState.AddModelError("Id", "Jogo não existe.");
            if (jogo.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");

            if (string.IsNullOrEmpty(jogo.Descricao))
                ModelState.AddModelError("Descricao", "Preencha o nome.");
            if (jogo.Valor < 0)
                ModelState.AddModelError("Valor", "Campo obrigatório.");
            if (jogo.CategoriaID <= 0)
                ModelState.AddModelError("Categoriad", "Informe o código da categoria.");
            if (jogo.DataAquisicao > DateTime.Now)
                ModelState.AddModelError("DataAquisicao", "Data inválida!");
        }



        public IActionResult Salvar(JogoViewModel jogo, string Operacao)
        {
            try
            {
                ValidaDados(Operacao, jogo);

                if (ModelState.IsValid)
                {
                    JogoDAO dao = new JogoDAO();
                    if (Operacao == "I")
                        dao.Insert(jogo);
                    else
                        dao.Update(jogo);
                    return RedirectToAction("Index");
                }
                else
                {
                    PreparaComboCategorias();
                    ViewBag.Operacao = Operacao;
                    return View("Tela", jogo);
                }
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
                ViewBag.Operacao = "A";
                JogoDAO dao = new JogoDAO();
                PreparaComboCategorias();

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
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.Message));
            }

        }       
        
    }
}

