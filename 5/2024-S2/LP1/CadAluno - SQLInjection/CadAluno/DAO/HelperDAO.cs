using CadAluno.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAluno.DAO
{
    public static class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] p)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    if (p != null)
                        cmd.Parameters.AddRange(p);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ExecutaSQL(string sql, SqlParameter p)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    if (p != null)
                        cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                }
            }
        }






    }
}
