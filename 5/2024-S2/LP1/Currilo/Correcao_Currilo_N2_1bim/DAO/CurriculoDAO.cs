using Correcao_Currilo_N2_1bim.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Correcao_Currilo_N2_1bim.DAO
{
    public class CurriculoDAO
    {
        public void Inserir(CurriculoViewModel cv)
        {
            string sql =
                @"
            INSERT INTO [dbo].[Curriculo]
           ([id]
           ,[Nome]
           ,[Telefone]
           ,[Email]
           ,[pretensao_salarial]
           ,[Cargo_pretendido]
           ,[data_nascimento]
           ,[resumo_profissional]
           ,[Formacao_Academica1]
           ,[Formacao_Academica2]
           ,[Idioma1]
           ,[Idioma2])
     VALUES
           (@id, 
           @Nome,
           @Telefone, 
           @Email, 
           @pretensao_salarial, 
           @Cargo_pretendido,
           @data_nascimento, 
           @resumo_profissional, 
           @Formacao_Academica1, 
           @Formacao_Academica2, 
           @Idioma1, 
           @Idioma2)";

            HelperDAO.ExecutaSQL(sql, CriaParametros(cv));
        }


        public void Alterar(CurriculoViewModel cv)
        {
            string sql = @" UPDATE[dbo].[Curriculo]
                   SET
                      [Nome] =                @Nome,
                      [Telefone] =            @Telefone,
                      [Email] =               @Email,
                      [pretensao_salarial] =  @pretensao_salarial, 
                      [Cargo_pretendido] =    @Cargo_pretendido,
                      [data_nascimento] =     @data_nascimento,
                      [resumo_profissional] = @resumo_profissional,
                      [Formacao_Academica1] = @Formacao_Academica1,
                      [Formacao_Academica2] = @Formacao_Academica2,
                      [Idioma1] =             @Idioma1,
                      [Idioma2] =             @Idioma2
                  WHERE id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(cv));
        }


        private SqlParameter[] CriaParametros(CurriculoViewModel cv)
        {
            SqlParameter[] parametros = {
            new SqlParameter("id", cv.Id),
            new SqlParameter("Nome", cv.Nome),
            new SqlParameter("Telefone", cv.Telefone),
            new SqlParameter("Email", cv.Email),
            new SqlParameter("pretensao_salarial", cv.PretensaoSalarial),
            new SqlParameter("Cargo_pretendido", cv.CargoPretendido),
            new SqlParameter("data_nascimento", cv.DataNascimento),
            new SqlParameter("resumo_profissional", cv.Resumo),
            new SqlParameter("Formacao_Academica1", NullAsDBNull(cv.FormacaoAcademica1)),
            new SqlParameter("Formacao_Academica2", NullAsDBNull(cv.FormacaoAcademica2)),
            new SqlParameter("Idioma1", NullAsDBNull(cv.Idioma1)),
            new SqlParameter("Idioma2", NullAsDBNull(cv.Idioma2))
            };

            return parametros;
        }



        public void Excluir(int id)
        {
            string sql = "delete curriculo where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }

        private CurriculoViewModel MontaViewModel(DataRow registro)
        {
            var cv = new CurriculoViewModel()
            {
                Id = Convert.ToInt32(registro["id"]),
                Nome = registro["nome"].ToString(),
                DataNascimento = Convert.ToDateTime(registro["data_nascimento"]),
                PretensaoSalarial = Convert.ToDouble(registro["pretensao_salarial"]),
                CargoPretendido = registro["Cargo_pretendido"].ToString(),
                Email = registro["email"].ToString(),
                FormacaoAcademica1 = DbNullAsString(registro["Formacao_Academica1"]),
                FormacaoAcademica2 = DbNullAsString(registro["Formacao_Academica2"]),
                Idioma1 = DbNullAsString(registro["Idioma1"]),
                Idioma2 = DbNullAsString(registro["Idioma2"]),
                Resumo = registro["resumo_profissional"].ToString(),
                Telefone = registro["Telefone"].ToString(),
            };
            return cv;
        }

        public CurriculoViewModel Consulta(int id)
        {
            string sql = "select * from curriculo where id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaViewModel(tabela.Rows[0]);
        }


        public List<CurriculoViewModel> Listagem()
        {
            var lista = new List<CurriculoViewModel>();
            string sql = "select * from curriculo order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaViewModel(registro));
            return lista;
        }


        public int ProximoId()
        {
            string sql = "select isnull(max(id) +1, 1) as 'MAIOR' from curriculo";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }



        private object NullAsDBNull(object valor)
        {
            if (valor == null)
                return DBNull.Value;
            else
                return valor;
        }


        private string DbNullAsString(object valor)
        {
            if (valor == DBNull.Value)
                return null;
            else
                return valor.ToString();
        }


    }
}
