using CadAluno.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAluno.DAO
{
    internal static class HelperDAO
    {
        internal static void ExecutaSQL(string sql, SqlParameter[] p)
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

        internal static void ExecutaSQL(string sql, SqlParameter p)
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


        internal static DataTable ExecutaSelect(string sql, SqlParameter[] p)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    if (p != null)
                        adapter.SelectCommand.Parameters.AddRange(p);

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    return tabela;
                }
            }
        }
    }
}
