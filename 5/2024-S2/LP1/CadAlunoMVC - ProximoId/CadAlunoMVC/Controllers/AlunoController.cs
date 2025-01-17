﻿using CadAlunoMVC.DAO;
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
            try
            {
                AlunoDAO dao = new AlunoDAO();
                List<AlunoViewModel> lista = dao.Listagem();
                return View("index", lista);
            }
            catch (Exception ex)
            {
                return View("error", new ErrorViewModel(ex.ToString()));
            }
        }
        public IActionResult Create()
        {
            try
            {
                AlunoViewModel aluno = new AlunoViewModel();
                aluno.DataNascimento = DateTime.Now;

                AlunoDAO dao = new AlunoDAO();
                aluno.Id = dao.ProximoId();
                return View("Form", aluno);
            }
            catch (Exception ex)
            {
                return View("error", new ErrorViewModel(ex.ToString()));
            }
        }


        public IActionResult Salvar(AlunoViewModel aluno)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                if (dao.Consulta(aluno.Id) == null)
                    dao.Inserir(aluno);
                else
                    dao.Alterar(aluno);

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View("error", new ErrorViewModel(ex.ToString()));
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return View("error", new ErrorViewModel(ex.ToString()));
            }
        }


        public IActionResult Edit(int id)
        {
            try
            {
                AlunoDAO dao = new AlunoDAO();
                AlunoViewModel aluno = dao.Consulta(id);
                if (aluno == null)
                    return RedirectToAction("index");
                else
                    return View("Form", aluno);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }



    }
}
