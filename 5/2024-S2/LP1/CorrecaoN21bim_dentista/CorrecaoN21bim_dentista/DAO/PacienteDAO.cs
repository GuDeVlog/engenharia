using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using CorrecaoN21bim_dentista.Models;

namespace CorrecaoN21bim_dentista.DAO
{
    public class PacienteDAO
    {
        public void Inserir(PacienteViewModel paciente)
        {
            string sql =
            "insert into tbPaciente(id, nome)" +
            "values ( @id, @nome)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(paciente));
        }
        public void Alterar(PacienteViewModel paciente)
        {
            string sql =
            "update tbPaciente set nome = @nome " +
            "where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(paciente));
        }

        private SqlParameter[] CriaParametros(PacienteViewModel aluno)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("id", aluno.Id);
            parametros[1] = new SqlParameter("nome", aluno.Nome); return parametros;
        }

        public void Excluir(int id)
        {
            string sql = "delete tbPaciente where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }

        private PacienteViewModel MontaObjeto(DataRow registro)
        {
            PacienteViewModel a = new PacienteViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            return a;
        }

        public PacienteViewModel Consulta(int id)
        {
            string sql = "select * from tbPaciente where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaObjeto(tabela.Rows[0]);
        }

        public List<PacienteViewModel> Listagem()
        {
            List<PacienteViewModel> lista = new List<PacienteViewModel>();
            string sql = "select * from tbPaciente order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaObjeto(registro));
            return lista;
        }

        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from tbPaciente";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

    }
}
