using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using CorrecaoN21bim_dentista.Models;

namespace CorrecaoN21bim_dentista.DAO
{
    public class AtendimentoDAO
    {
        public void Inserir(AtendimentoViewModel Atendimento)
        {
            string sql =
            "insert into tbAtendimento(id, pacienteId, dataProcedimento,tipoProcedimento,observacoes,preco)" +
            "values ( @id, @pacienteId, @dataProcedimento,@tipoProcedimento,@observacoes,@preco)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Atendimento));
        }
        public void Alterar(AtendimentoViewModel Atendimento)
        {
            string sql =
            "update tbAtendimento set " +
            "pacienteId= @pacienteId, " +
            "dataProcedimento=@dataProcedimento," +
            "tipoProcedimento=@tipoProcedimento," +
            "observacoes=@observacoes," +
            "preco=@preco " +
            "where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Atendimento));
        }

        private SqlParameter[] CriaParametros(AtendimentoViewModel a)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("pacienteId", a.PacienteId);
            parametros[1] = new SqlParameter("dataProcedimento", a.DataProcedimento);
            parametros[2] = new SqlParameter("tipoProcedimento", a.TipoProcedimento);
            if (a.Observacoes == null)
                parametros[3] = new SqlParameter("observacoes", DBNull.Value);
            else
                parametros[3] = new SqlParameter("observacoes", a.Observacoes);
            parametros[4] = new SqlParameter("preco", a.Preco);
            parametros[5] = new SqlParameter("id", a.Id);

            return parametros;
        }

        public void Excluir(int id)
        {
            string sql = "delete tbAtendimento where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }

        private AtendimentoViewModel MontaObjeto(DataRow registro)
        {
            AtendimentoViewModel a = new AtendimentoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.PacienteId = Convert.ToInt32(registro["Pacienteid"]);
            a.DataProcedimento = Convert.ToDateTime(registro["DataProcedimento"]);
            a.TipoProcedimento = Convert.ToInt32(registro["TipoProcedimento"]);
            a.Preco = Convert.ToDouble(registro["preco"]);
            if (registro["observacoes"] != DBNull.Value)
                a.Observacoes = registro["observacoes"].ToString();
            return a;
        }

        public AtendimentoViewModel Consulta(int id)
        {
            string sql = "select * from tbAtendimento where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaObjeto(tabela.Rows[0]);
        }

        public List<AtendimentoViewModel> Listagem()
        {
            List<AtendimentoViewModel> lista = new List<AtendimentoViewModel>();
            string sql = "select * from tbAtendimento";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaObjeto(registro));
            return lista;
        }

        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from tbAtendimento";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

    }
}
