using CadAlunoMVC.DAO;
using CadAlunoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace CadAlunoMVC.Controllers
{
    public class CidadeController : PadraoController<CidadeViewModel>
    {
        public CidadeController() {
            DAO = new CidadeDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(CidadeViewModel model, string operacao)
        {
            base.ValidaDados(model, operacao);
            if (string.IsNullOrEmpty(model.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
        }
    }
}