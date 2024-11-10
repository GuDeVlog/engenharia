using CadastroJogos.Models;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CadastroJogos.Controllers.DAO
{
    public class JogoDAO
    {
        private SqlParameter[] CriaParametros(JogoViewModel jogo)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            JogoViewModel Jogo = jogo;
            parametros[0] = new SqlParameter("id", jogo.Id);
            parametros[1] = new SqlParameter("Descrição", jogo.Descricao);
            parametros[2] = new SqlParameter("Valor", jogo.Valor);
            //parametros[3] = new SqlParameter("cidadeId", jogo.CidadeId);
            parametros[4] = new SqlParameter("Data locacao", jogo.DataLocacao);
            return parametros;
        }

        public void Inserir(JogoViewModel jogo)
        {
            string sql =
            "insert into jogos(id, descricao,valor,datalocacao)" +
            "values ( @id, @descricao,@valor,@datalocacao)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }

        public void Alterar(JogoViewModel jogo)
        {
            string sql =
            "update jogos set descricao=@descricao, valor=@valor, " +
            "datalocacao=@datalocacao where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(jogo));
        }

        public void Excluir(int id)
        {
            string sql = "delete jogo where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }


        private JogoViewModel MontaJogo(DataRow registro)

        {
            JogoViewModel j = new JogoViewModel();
            j. Id = Convert.ToInt32(registro["id"]);
            j.Descricao = registro["descricao"].ToString();
            j.DataLocacao = Convert.ToDateTime(registro["datalocacao"]);
            j.Valor = Convert.ToDouble(registro
           ["valor"]);
            return j;

        }

         public JogoViewModel Consulta(int id)
        {
            string sql = "select * from jogo where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaJogo(tabela.Rows[0]);
        }
        public List<JogoViewModel> Listagem()
        {
            List<JogoViewModel> lista = new List<JogoViewModel>();
            string sql = "select * from jogos order by descricao";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaJogo(registro));
            return lista;
        }
    }

}
