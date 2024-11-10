using CadAluno.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            SqlConnection conexao = ConexaoBD.GetConexao();
            try
            {
                //devemos substituir a ',' por '.'
                string mensalidade = aluno.Mensalidade.ToString().Replace(',', '.');
                // set dateformat dmy; este comando serve para alterar a
                //forma como o SQL Server entende o formato de data
                string sql = String.Format("set dateformat dmy; " +
                "insert into alunos(id, nome, mensalidade, cidadeId, dataNascimento)" +
                "values ( {0}, '{1}', {2}, {3}, '{4}')", aluno.Id,
                aluno.Nome, mensalidade, aluno.CidadeId, aluno.DataNascimento);
                SqlCommand comando = new SqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Excluir(int id)
        {            
            var cx = ConexaoBD.GetConexao();
            try
            {
                string sql = $"delete alunos where id ={id}";

                var cmd = new SqlCommand(sql, cx);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cx.Close();
            }


        }


        public void Alterar(AlunoViewModel aluno)
        {
            SqlConnection cx = ConexaoBD.GetConexao();
            try
            {
                String mensalidade = aluno.Mensalidade
                    .ToString().Replace(',', '.');

                string sql = $"set dateformat dmy;" +
                    $"update alunos set " +
                    $"nome='{aluno.Nome}'," +
                    $"cidadeId={aluno.CidadeId}, " +
                    $"mensalidade={mensalidade}," +
                    $"dataNascimento='{aluno.DataNascimento}' " +
                    $"where id={aluno.Id}";

                SqlCommand cmd = new SqlCommand(sql, cx);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cx.Close();
            }
        }


    }
}