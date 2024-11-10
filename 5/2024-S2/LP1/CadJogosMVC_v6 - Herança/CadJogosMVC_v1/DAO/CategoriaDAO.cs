using CadJogosMVC_v1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadJogosMVC_v1.DAO
{
    public class CategoriaDAO
    {
        private SqlParameter[] CriaParametros(CategoriaViewModel c)
        {
            SqlParameter[] p = {
                new SqlParameter("id", c.Id),                
            };
            return p;
        }


        public void Inserir(CategoriaViewModel c)
        {
            HelperDAO.ExecutaProc("spIncluiCategoria", CriaParametros(c));
        }


        public void Alterar(CategoriaViewModel c)
        {
            
            HelperDAO.ExecutaProc("spAlteraCategoria", CriaParametros(c));
        }

        public void Excluir(int id)
        {
            SqlParameter[] p = { new SqlParameter("id", id) };
            HelperDAO.ExecutaProc("spExcluiCategoria", p);
        }


        public CategoriaViewModel Consulta(int id)
        {
            SqlParameter[] p = { new SqlParameter("id", id) };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaCategoria", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }


        public List<CategoriaViewModel> Lista()
        {
            
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemCategorias", null);
            List<CategoriaViewModel> retorno = new List<CategoriaViewModel>();

            foreach (DataRow registro in tabela.Rows)
            {
                retorno.Add(MontaModel(registro));
            }

            return retorno;
        }


        public int ProximoId()
        {
            SqlParameter[] p = { new SqlParameter("tabela", "categorias") };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }



        public static CategoriaViewModel MontaModel(DataRow registro)
        {
            CategoriaViewModel categ = new CategoriaViewModel();
            categ.Id = Convert.ToInt32(registro["id"]);
            categ.Descricao = registro["descricao"].ToString();
            return categ;
        }

    }
}


/*

create procedure spListagemCategorias
as
begin
	select * from categorias
end

GO  

GO  
 * */
