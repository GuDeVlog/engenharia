
using cadFuncionarioMVC_V1.Enumeradores;
using cadFuncionarioMVC_V1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadFuncionarioMVC_V1.DAO
{
    public class FuncionarioDAO
    {

        private SqlParameter[] CriaParametros(FuncionarioViewModel f)
        {

            SqlParameter[] p = {
                new SqlParameter("func_id", f.Id),
                new SqlParameter("func_nome", f.Nome),
                new SqlParameter("func_tipo", (char)f.Tipo),
                new SqlParameter("func_ativo", f.Ativo),
            };

            return p;
        }


        public void Inserir(FuncionarioViewModel f)
        {
            string sql = @"
                INSERT INTO funcionarios
                                  (func_id,   
                                   func_nome, 
                                   func_tipo ,
                                   func_Ativo)                   
                  VALUES      (@func_id    ,
                               @func_nome,  
				               @func_tipo , 
  			               @func_Ativo) ";

            HelperDAO.ExecutaSQL(sql, CriaParametros(f));
        }


        public void Alterar(FuncionarioViewModel f)
        {
            string sql = @"
                        UPDATE funcionarios
                              SET    func_nome = @func_nome,	  
			                         func_Ativo = @func_Ativo,
			                         func_tipo = @func_tipo
                              WHERE  func_id = @func_id";

            HelperDAO.ExecutaSQL(sql, CriaParametros(f));
        }

        public void Excluir(int id)
        {
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("func_id", id)
            };
            string sql = "DELETE funcionarios  WHERE  func_id = @func_id";
            HelperDAO.ExecutaSQL(sql, p);
        }



        public FuncionarioViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("func_id", id)
            };

            string sql = "SELECT * FROM   funcionarios    WHERE  func_id = @func_id";
            var tabela = HelperDAO.ExecutaSelect(sql, p);

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }


        public List<FuncionarioViewModel> Lista()
        {
            string sql = "SELECT *  FROM   funcionarios";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            var retorno = new List<FuncionarioViewModel>();

            foreach (DataRow registro in tabela.Rows)
                retorno.Add(MontaModel(registro));

            return retorno;
        }


        public int ProximoId()
        {
            string sql = "select isnull(max(func_id) +1, 1) as MAIOR from funcionarios ";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }

        public static FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel f = new FuncionarioViewModel();
            f.Id = Convert.ToInt32(registro["func_id"]);
            f.Nome = registro["func_nome"].ToString();
            f.Ativo = Convert.ToBoolean(registro["func_ativo"]);
            f.Tipo = (EnumTipoFuncionario)Convert.ToChar(registro["func_tipo"]);
            return f;
        }
    }
}


/*
CREATE PROCEDURE SpincluiFunc (@func_id             INT,
                               @func_nome      VARCHAR(max),
                               @func_tipo  varchar(1),
                               @func_Ativo    bit)
AS
  BEGIN
      INSERT INTO funcionarios
                  (func_id,   
                   func_nome, 
                   func_tipo ,
                   func_Ativo)                   
      VALUES      (@func_id    ,
                   @func_nome,  
				   @func_tipo , 
  			   @func_Ativo) 
end

go

CREATE PROCEDURE SpAlteraFunc (@func_id             INT,
							   @func_nome      VARCHAR(max),
							   @func_tipo  varchar(1),
							   @func_Ativo    bit)
							
AS
  BEGIN
      UPDATE funcionarios
      SET    func_nome = @func_nome,	  
			 func_Ativo = @func_Ativo,
			 func_tipo = @func_tipo
      WHERE  func_id = @func_id
  END

go

CREATE PROCEDURE SpexcluiFunc(@func_id INT)
AS
  BEGIN
      DELETE funcionarios  WHERE  func_id = @func_id
  END

go

CREATE PROCEDURE SpconsultaFunc (@func_id INT)
AS
  BEGIN
      SELECT * FROM   funcionarios    WHERE  func_id = @func_id
  END

go

CREATE PROCEDURE SpListagemFuncionarios
AS
  BEGIN
      SELECT *
      FROM   funcionarios
  END

go  


create procedure [dbo].[spProximoIdFunc] (@tabela varchar(max))
as
begin
	exec ('select isnull(max(func_id) +1, 1) as MAIOR from ' + @tabela)
end

  
*/