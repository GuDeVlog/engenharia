using CadastroAlunoV1.Models;
using MySqlConnector;
using System.Data;

namespace CadastroAlunoV1.DAO
{
    public class AlunoDAO
    {
        public void Inserir(AlunoViewModel aluno)
        {
            string sql =
            "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
            "values ( @id, @nome, @mensalidade, @cidadeId, @dataNascimento)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }
        public void Alterar(AlunoViewModel aluno)
        {
            string sql =
            "update alunos set nome = @nome, " +
            "mensalidade = @mensalidade, " +
            "cidadeId = @cidadeId," +
            "dataNascimento = @dataNascimento where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }
        private MySqlParameter[] CriaParametros(AlunoViewModel aluno)
        {
            MySqlParameter[] parametros = new MySqlParameter[5];
            parametros[0] = new MySqlParameter("id", aluno.Id);
            parametros[1] = new MySqlParameter("nome", aluno.Nome);
            parametros[2] = new MySqlParameter("mensalidade", aluno.Mensalidade);
            parametros[3] = new MySqlParameter("cidadeId", aluno.CidadeId);
            parametros[4] = new MySqlParameter("dataNascimento", aluno.DataNascimento);

            if (aluno.Mensalidade == null)
                parametros[2] = new MySqlParameter("mensalidade", DBNull.Value);
            else
                parametros[2] = new MySqlParameter("mensalidade", aluno.Mensalidade);

            return parametros;
        }
        public void Excluir(int id)
        {
            string sql = "delete alunos where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        private AlunoViewModel MontaAluno(DataRow registro)
        {
            AlunoViewModel a = new AlunoViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Nome = registro["nome"].ToString();
            a.CidadeId = Convert.ToInt32(registro["cidadeId"]);
            a.DataNascimento = Convert.ToDateTime(registro["dataNascimento"]);
            a.Mensalidade = Convert.ToDouble(registro["mensalidade"]);

            if (registro["Mensalidade"] != DBNull.Value)
                a.Mensalidade = Convert.ToDouble(registro["mensalidade"]);

            return a;
        }

public AlunoViewModel Consulta(int id)
        {
            string sql = "select * from alunos where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaAluno(tabela.Rows[0]);
        }
        public List<AlunoViewModel> Listagem()
        {
            List<AlunoViewModel> lista = new List<AlunoViewModel>();
            string sql = "select * from alunos order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaAluno(registro));
            return lista;
        }
    }
}
