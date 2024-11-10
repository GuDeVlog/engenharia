using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadAula.DAO
{
    public static class HelperDAO
    {
        /// <summary>
        /// Executa um comando SQL no banco de dados.
        /// </summary>
        /// <param name="sql">Comando SQL a ser executado.</param>
        /// <param name="parametros">Parâmetros do comando SQL.</param>
        public static void ExecutaSQL(string sql, MySqlParameter[] parametros)
        {
            // Obtém a conexão com o banco de dados MySQL
            using (MySqlConnection conexao = ConexaoDB.GetConexao())
            {
                // Cria um comando SQL usando a conexão
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    // Adiciona os parâmetros, se houver
                    if (parametros != null)
                    {
                        comando.Parameters.AddRange(parametros);
                    }

                    // Executa o comando SQL
                    comando.ExecuteNonQuery();
                }
            }
        }
    }

}
