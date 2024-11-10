using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogos1.DAO
{
    public static class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using(var conexao = ConexaoBD.GetConexao())
            {
                using(var command = new SqlCommand(sql, conexao))
                {
                    if (parametros!= null)                    
                        command.Parameters.AddRange(parametros);                    
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
        {
           using(SqlConnection conexao = ConexaoBD.GetConexao())
           {
                using(SqlDataAdapter sqlCommand = new SqlDataAdapter(sql, conexao))
                {
                    if(parametros?.Count() > 0)                    
                        sqlCommand.SelectCommand.Parameters.AddRange(parametros);
                    
                    DataTable tabela = new DataTable();
                    sqlCommand.Fill(tabela);
                    return tabela;
                }
           }
        }
    }
}