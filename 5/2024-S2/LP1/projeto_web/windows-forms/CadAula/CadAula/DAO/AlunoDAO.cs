using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadAula.Model;
using MySql.Data.MySqlClient;
using CadAula.DAO;
using System.Data;

namespace CadAula.DAO
{
    public class AlunoDAO
    {
        private MySqlParameter[] CriaParametros(AlunoViewModel aluno)
        {
            MySqlParameter[] parametros = new MySqlParameter[]
            {
                new MySqlParameter("@id", MySqlDbType.Int32){ Value = aluno.id },
                new MySqlParameter("@nome", MySqlDbType.VarChar, 50){ Value = aluno.nome },
                new MySqlParameter("@mensalidade", MySqlDbType.Decimal){ Value = aluno.mensalidade },
                new MySqlParameter("@cidadeId", MySqlDbType.Int32){ Value = aluno.cidadeId },
                new MySqlParameter("@dataNascimento", MySqlDbType.DateTime){ Value = aluno.dataDeNascimento },
            };
            return parametros;
        }

        /// <summary>
        /// Método para inserir um aluno no BD
        /// </summary>
        /// <param name="aluno">objeto aluno com todas os atributos preenchidos</param>
        public void Inserir(AlunoViewModel aluno)
        {
            string sql =
            "INSERT INTO alunos (id, nome, mensalidade, cidadeId, dataNascimento) " +
            "VALUES (@id, @nome, @mensalidade, @cidadeId, @dataNascimento)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }

        /// <summary>
        /// Altera um aluno no banco de dados
        /// </summary>
        /// <param name="aluno">objeto aluno com todas os atributos preenchidos</param>
        public void Alterar(AlunoViewModel aluno)
        {
            string sql =
            "UPDATE alunos SET nome=@nome, mensalidade=@mensalidade, " +
            "cidadeId=@cidadeId, dataNascimento=@dataNascimento WHERE id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(aluno));
        }

        /// <summary>
        /// Exclui um aluno no banco de dados.
        /// </summary>
        /// <param name="id">id do aluno</param>
        public void Excluir(int id)
        {
            //fazendo com sobrecarga enviando um unico parametro sem vetor
            /*HelperDAO.ExecutaSQL(sql, new MySqlParameter(id:id));*/
            string sql = "DELETE FROM alunos WHERE id = @id";
            MySqlParameter[] parametros = new MySqlParameter[]
            {
                new MySqlParameter("@id", MySqlDbType.Int32) { Value = id }
            };
            HelperDAO.ExecutaSQL(sql, parametros);
        }


        public AlunoViewModel Consulta(int id)
        {
            using (MySqlConnection cx = ConexaoDB.GetConexao())
            {
                string sql = "SELECT * FROM alunos WHERE id = @id";
                using (MySqlCommand comando = new MySqlCommand(sql, cx))
                {
                    // Adiciona o parâmetro à consulta
                    comando.Parameters.AddWithValue("@id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                    {
                        DataTable tabela = new DataTable();
                        adapter.Fill(tabela);

                        if (tabela.Rows.Count == 0)
                            return null;

                        // Cria o objeto AlunoViewModel a partir dos dados retornados
                        DataRow registro = tabela.Rows[0];
                        var aluno = new AlunoViewModel
                        {
                            id = Convert.ToInt32(registro["id"]),
                            nome = registro["nome"].ToString(),
                            cidadeId = Convert.ToInt32(registro["cidadeId"]),
                            mensalidade = Convert.ToDouble(registro["mensalidade"]),
                            dataDeNascimento = Convert.ToDateTime(registro["dataNascimento"])
                        };

                        return aluno;
                    }
                }
            }
        }

    }

}
