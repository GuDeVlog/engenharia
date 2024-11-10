using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Potencia_ex_10._1.DAO
{
    internal class HelperDAO
    {

        public static void ExecutaSql(string sql, MySqlParameter[] parametros)
        {
            using (MySqlConnection conexao = ConexaoDB.getConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    if (parametros != null) { 
                        comando.Parameters.AddRange(parametros);
                    }

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
