using CadJogos1.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogos1.DAO
{
    public class JogoDAO
    {

        private SqlParameter[] CriaPamametros(JogoViewModel jogo)
        {
            SqlParameter[] parametros =
             {
                new SqlParameter("id", jogo.Id),
                new SqlParameter("descricao", jogo.Descricao),
                new SqlParameter("valor_locacao", jogo.Valor),
                new SqlParameter("data_aquisicao", jogo.Data),
                new SqlParameter("categoriaId", jogo.CategoriaId)
             };
            //List<int> minhalista = new List<int>(){ 1,2,3};
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
            string sql = "select * from jogos where id=" + id;
            var tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count > 0)            
                return MontaJogo(tabela.Rows[0]);            
            else
                return null;
        }

        private JogoViewModel MontaJogo(DataRow registro)
        {
            return new JogoViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                CategoriaId = Convert.ToInt32(registro["categoriaId"]),
                Descricao = registro["descricao"].ToString(),
                Valor = Convert.ToInt32(registro["valor_locacao"]),
                Data = Convert.ToDateTime(registro["data_aquisicao"]),
            };
        }



        public List<JogoViewModel> Listar()
        {
            string sql = "select * from jogos order by descricao";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            var lista = new List<JogoViewModel>();
            /*for (int n = 0; n < tabela.Rows.Count; n++)
                lista.Add(MontaJogo(tabela.Rows[n])); */
            
            foreach(DataRow registro in tabela.Rows)
                lista.Add(MontaJogo(registro)); 

            return lista;
        }

    }
}
