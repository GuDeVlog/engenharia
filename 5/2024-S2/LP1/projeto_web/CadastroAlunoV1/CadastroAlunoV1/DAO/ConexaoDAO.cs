using MySqlConnector;

namespace CadastroAlunoV1.DAO
{
    public static class ConexaoBD
    {
        public static MySqlConnection GetConexao()
        {
            string strCon = "Server=localhost; Database=AULADB; Uid=diego; Pwd=Ogeid-880171;";
            MySqlConnection conexao = new MySqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}
