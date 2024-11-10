using CadJogosMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogosMVC.DAO
{
    public class JogoDAO
    {

        private SqlParameter[] CriaPamametros(JogoViewModel jogo)
        {
            SqlParameter[] parametros =
             {
                new SqlParameter("id", jogo.Id),
                new SqlParameter("descricao", jogo.Descricao),
                new SqlParameter("valor_locacao", jogo.valor),
                new SqlParameter("data_aquisicao", jogo.Data),
                new SqlParameter("categoriaId", jogo.CategoriaId)
             };
            return parametros;
        }

        public void Incluir(JogoViewModel jogo)
        {
            string sql =
                    @"
                        insert into  jogos                     
                        (id, descricao, valor_locacao,
                         data_aquisicao, categoriaId)       
                       values
                        (@Id, @Descricao, @valor_locacao,
                         @Data_aquisicao, @CategoriaId)";

            HelperDAO.ExecutaSQL(sql, CriaPamametros(jogo));
        }

        public void Alterar(JogoViewModel jogo)
        {
            string sql =
                @"
                       update  jogos                     
                       set                            
                        descricao = @descricao,
                        valor_locacao = @valor_locacao,
                        data_aquisicao = @data_aquisicao,
                        categoriaID = @categoriaID
                       where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaPamametros(jogo));
        }

        public void Excluir(int id)
        {
            string sql = $"delete jogos where id = " + id;
            HelperDAO.ExecutaSQL(sql, null);
        }


        public JogoViewModel Consulta(int id)
        {
            string sql = "select * from jogos where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaJogo(tabela.Rows[0]);
        }


        public List<JogoViewModel> Listar()
        {
            string sql = "select * from jogos order by id ";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            List<JogoViewModel> lista = new List<JogoViewModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaJogo(registro));
            }
            return lista;
        }


        private JogoViewModel MontaJogo(DataRow registro)
        {
            JogoViewModel j = new JogoViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                Descricao = registro["descricao"].ToString(),
                CategoriaId = Convert.ToInt32(registro["categoriaID"]),
                Data = Convert.ToDateTime(registro["data_aquisicao"]),
                valor = Convert.ToDouble(registro["valor_locacao"])
            };

            return j;
        }


        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from jogos";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }


    }
}
