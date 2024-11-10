using CadAluno.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadAluno.DAO
{
    public class AlunoDAO
    {
        /// <summary>
        /// Método usado para inserir um registro no BD
        /// </summary>
        /// <param name="aluno">o objeto aluno contendo os campos</param>
        public void Inserir(AlunoViewModel aluno)
        {
            string sql =
            "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
            "values ( @id, @nome, @mensalidade, @cidadeId, @dataNascimento)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }

        public void Excluir(int id)
        {
            string sql = $"delete alunos where id =@id";
            /*SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };*/

            HelperDAO.ExecutaSQL(sql, new SqlParameter("id", id));
        }

        private SqlParameter[] CriaParametros(AlunoViewModel aluno)
        {
            SqlParameter[] p = new SqlParameter[]
                {
                    new SqlParameter("id", aluno.Id),
                    new SqlParameter("nome", aluno.Nome),
                    new SqlParameter("cidadeId", aluno.CidadeId),
                    new SqlParameter("mensalidade", aluno.Mensalidade),
                    new SqlParameter("dataNascimento", aluno.DataNascimento)
                };
            return p;
        }


        public void Alterar(AlunoViewModel aluno)
        {
            string sql = "update alunos set " +
            "nome=@nome,cidadeId=@cidadeId,mensalidade=@mensalidade," +
            "dataNascimento=@dataNascimento where id=@id";

            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }

        public AlunoViewModel Consultar(int id)
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from alunos where id =" + id;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    if (tabela.Rows.Count == 0)
                        return null;
                    else
                    {
                        DataRow registro = tabela.Rows[0];

                        var aluno = new AlunoViewModel();
                        aluno.Id = Convert.ToInt32(registro["id"]);
                        aluno.Nome = registro["nome"].ToString();
                        aluno.CidadeId = Convert.ToInt32(registro["Cidadeid"]);
                        aluno.Mensalidade = Convert.ToDouble(registro["mensalidade"]);
                        aluno.DataNascimento = Convert.ToDateTime(registro["datanascimento"]);
                        return aluno;
                    }
                }

            }
        }


        public List<AlunoViewModel> ConsultarTodosAlunos()
        {
            using (SqlConnection cx = ConexaoBD.GetConexao())
            {
                string sql = "select * from alunos order by nome ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, cx))
                {
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    List<AlunoViewModel> lista = new List<AlunoViewModel>();

                    foreach(DataRow registro in tabela.Rows)
                    {   
                        var aluno = new AlunoViewModel();
                        aluno.Id = Convert.ToInt32(registro["id"]);
                        aluno.Nome = registro["nome"].ToString();
                        aluno.CidadeId = Convert.ToInt32(registro["Cidadeid"]);
                        aluno.Mensalidade = Convert.ToDouble(registro["mensalidade"]);
                        aluno.DataNascimento = Convert.ToDateTime(registro["datanascimento"]);
                        lista.Add(aluno);
                    }
                    return lista;
                }

            }

        }

    }
}