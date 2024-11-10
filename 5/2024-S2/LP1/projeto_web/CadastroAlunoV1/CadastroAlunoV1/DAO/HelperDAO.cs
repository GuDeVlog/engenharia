using MySqlConnector;
using System.Data;

namespace CadastroAlunoV1.DAO
{
    public static class HelperDAO
    {
        public static void ExecutaSQL(string sql, MySqlParameter[] parametros)
        {
            using (MySqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    if (parametros != null)
                        comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
        public static DataTable ExecutaSelect(string sql, MySqlParameter[] parametros)
        {
            using (MySqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conexao))
                {
                    if (parametros != null)
                        adapter.SelectCommand.Parameters.AddRange(parametros);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    conexao.Close();
                    return tabela;
                }
            }
        }
    }
}
