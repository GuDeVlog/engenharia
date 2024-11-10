using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 
using System.Data.SqlClient;

namespace CadAula.DAO
{
    public static class ConexaoDB
    {
        /// <summary>
        /// Método Estático que retorna uma conexão aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static MySqlConnection GetConexao()
        {
            // Atualize a string de conexão com os detalhes do seu banco de dados MySQL
            string strCon = "Server=localhost; Database=AULADB; Uid=diego; Pwd=Ogeid-880171;";
            MySqlConnection conexao = new MySqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
