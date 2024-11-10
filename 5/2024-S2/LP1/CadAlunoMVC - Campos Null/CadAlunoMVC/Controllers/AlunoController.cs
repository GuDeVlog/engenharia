using CadAlunoMVC.DAO;
using CadAlunoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadAlunoMVC.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            AlunoDAO dao = new AlunoDAO();
            List<AlunoViewModel> lista = dao.Listagem();
            return View("index", lista);
        }
        public IActionResult Create()
        {
            AlunoViewModel aluno = new AlunoViewModel();
            aluno.DataNascimento = DateTime.Now;
            aluno.Id = 1;
            return View("Form", aluno);
        }
        public IActionResult Salvar(AlunoViewModel aluno)
        {
            AlunoDAO dao = new AlunoDAO();
            dao.Inserir(aluno);
            return RedirectToAction("index");
        }

    }
}
