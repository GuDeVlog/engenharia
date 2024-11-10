using CadAlunoMVC.DAO;
using CadAlunoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;

namespace CadAlunoMVC.Controllers
{
    public class AlunoController : PadraoController<AlunoViewModel>
    {
        public AlunoController()
        {
            DAO = new AlunoDAO();
            GeraProximoId = true;
        }

        protected override void ValidaDados(AlunoViewModel aluno, string operacao)
        {
            bool mensalidadeComErro = false;
            if (ModelState["mensalidade"].ValidationState == ModelValidationState.Invalid)
                mensalidadeComErro = true;

            base.ValidaDados(aluno, operacao);

            if (mensalidadeComErro)
                ModelState.AddModelError("Mensalidade", "Campo incorreto.");
            


            if (string.IsNullOrEmpty(aluno.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
            if (aluno.Mensalidade < 0)
                ModelState.AddModelError("Mensalidade", "Campo incorreto.");
            if (aluno.CidadeId <= 0)
                ModelState.AddModelError("CidadeId", "Informe o código da cidade.");
            if (aluno.DataNascimento > DateTime.Now)
                ModelState.AddModelError("DataNascimento", "Data inválida!");
        }

        protected override void PreencheDadosParaView(string Operacao, AlunoViewModel model)
        {
            base.PreencheDadosParaView(Operacao, model);
            model.DataNascimento = DateTime.Now;
            PreparaListaCidadesParaCombo();
        }

        private void PreparaListaCidadesParaCombo()
        {
            CidadeDAO cidadeDao = new CidadeDAO();
            var cidades = cidadeDao.Listagem();
            List<SelectListItem> listaCidades = new List<SelectListItem>();

            listaCidades.Add(new SelectListItem("Selecione uma cidade...", "0"));
            foreach (var cidade in cidades)
            {
                SelectListItem item = new SelectListItem(cidade.Nome, cidade.Id.ToString());
                listaCidades.Add(item);
            }
            ViewBag.Cidades = listaCidades;
        }
    }
}

