using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Potencia_ex_10._1.DAO
{
    internal class ConexaoDB
    {

        public static MySqlConnection getConexao()
        {
            String strCon= "Server=localhost; Database=AULADB; Uid=diego; Pwd=Ogeid-880171;";
            MySqlConnection conexao = new MySqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
