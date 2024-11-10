
using FerramentasASPNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FerramentasASPNet.DAO
{
    public class FerramentaDAO
    {
        public void Inserir(FerramentaViewModel f)
        {
            var p = CriaParametros(f);
            Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = new SqlParameter("operacao", "I");
            HelperDAO.ExecutaProc("spIncluiAlteraFerramenta", p);
        }


        public void Alterar(FerramentaViewModel f)
        {
            var p = CriaParametros(f);
            Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = new SqlParameter("operacao", "A");
            HelperDAO.ExecutaProc("spIncluiAlteraFerramenta",p);
        }        

        private SqlParameter[] CriaParametros(FerramentaViewModel f)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("id", f.Id);
            parametros[1] = new SqlParameter("descricao", f.Descricao);
            parametros[2] = new SqlParameter("fabricanteId", f.FabricanteId);            
            return parametros;
        }


        public void Excluir(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };

            HelperDAO.ExecutaProc("spExcluiFerramenta", p);
        }

        private FerramentaViewModel MontaVM(DataRow registro)
        {
            var  f = new FerramentaViewModel();
            f.Id = Convert.ToInt32(registro["id"]);
            f.Descricao = registro["descricao"].ToString();
            f.FabricanteId = Convert.ToInt32(registro["fabricanteId"]);
            
            return f;
        }

        public FerramentaViewModel Consulta(int id)
        {
            var p = new SqlParameter[]
            {
                new SqlParameter("id", id)
            };

            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaFerramenta", p );

            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaVM(tabela.Rows[0]);
        }

        public List<FerramentaViewModel> Listagem()
        {
            List<FerramentaViewModel> lista = new List<FerramentaViewModel>();
                        
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListaFerramentas", null);

            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaVM(registro));
            return lista;
        }
    }
}



/*

CREATE TABLE [dbo].[ferramentas](
Id [int] NOT NULL primary key identity (1,1),
descricao [varchar](50) NULL,
FabricanteId int );
GO

create procedure spIncluiAlteraFerramenta(
@operacao varchar(1),
@id int,
@descricao varchar(50),
@fabricanteId int
)
as
begin
  if (@operacao = 'I')
  begin
      insert into ferramentas (descricao, fabricanteId)
	  values
	  (@descricao, @fabricanteId)
  end
  else
  begin
     update ferramentas set descricao = @descricao, fabricanteId = @fabricanteId
	 where id = @id
  end 
end
GO


create procedure spExcluiFerramenta (@id int )
as
  delete ferramentas where id = @id
GO

create procedure spConsultaFerramenta(@id int)
as
   select * from ferramentas where id = @id
GO




create procedure spListaFerramentas
as
  select * from ferramentas order by id;
GO
 */
