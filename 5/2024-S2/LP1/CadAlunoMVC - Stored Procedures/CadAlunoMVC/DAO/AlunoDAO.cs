using CadAlunoMVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CadAlunoMVC.DAO
{
    public class AlunoDAO
    {
        public void Inserir(AlunoViewModel aluno) =>
            HelperDAO.ExecutaProc("spIncluiAluno", CriaParametros(aluno));


        public void Alterar(AlunoViewModel aluno)
        {
            HelperDAO.ExecutaProc("spAlteraAluno", CriaParametros(aluno));
        }
        private SqlParameter[] CriaParametros(AlunoViewModel aluno)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", aluno.Id);
            parametros[1] = new SqlParameter("nome", aluno.Nome);
            if (aluno.Mensalidade == null)
                parametros[2] = new SqlParameter("mensalidade", DBNull.Value);
            else
                parametros[2] = new SqlParameter("mensalidade", aluno.Mensalidade);

            parametros[3] = new SqlParameter("cidadeId", aluno.CidadeId);
            parametros[4] = new SqlParameter("dataNascimento", aluno.DataNascimento);
            return parametros;
        }
        public void Excluir(int id)
        {
            var p = new SqlParameter[]
                 {
                    new SqlParameter("id", id)
                 };
            HelperDAO.ExecutaProc("spExcluiAluno", p);
        }
        private AlunoViewModel MontaAluno(DataRow registro)
        {
            AlunoViewModel a = new AlunoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.CidadeId = Convert.ToInt32(registro["cidadeId"]);
            a.DataNascimento = Convert.ToDateTime(registro["dataNascimento"]);
            if (registro["mensalidade"] != DBNull.Value)
                a.Mensalidade = Convert.ToDouble(registro["mensalidade"]);

            if (registro.Table.Columns.Contains("NomeCidade"))
                a.NomeCidade = registro["NomeCidade"].ToString();

            return a;
        }

        public AlunoViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
                 {
                 new SqlParameter("id", id)
                 };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaAluno", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaAluno(tabela.Rows[0]);
        }

        public List<AlunoViewModel> Listagem()
        {
            List<AlunoViewModel> lista = new List<AlunoViewModel>();

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemAlunos", null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaAluno(registro));
            return lista;
        }


        public int ProximoId()
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("tabela", "alunos")
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}


/*
 * 
 * ref. pagina 55 da apostila, que está com erro.
ALTER procedure [dbo].[spListagemAlunos]  
as
begin
	select Alunos.*, Cidades.Nome as NomeCidade  
	from alunos  
	Left join cidades on alunos.CidadeId = cidades.id  
	order by nome
end
  
 * 
 * 
 * */
