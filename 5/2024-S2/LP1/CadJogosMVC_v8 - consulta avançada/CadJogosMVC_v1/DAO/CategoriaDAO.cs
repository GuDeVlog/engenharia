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
    public class CategoriaDAO : PadraoDAO<CategoriaViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriaViewModel c)
        {
            SqlParameter[] p = {
                new SqlParameter("id", c.Id),
                new SqlParameter("descricao", c.Descricao),                
            };
            return p;
        }

        protected override CategoriaViewModel MontaModel(DataRow registro)
        {
            var c = new CategoriaViewModel();
            c.Id = Convert.ToInt32(registro["id"]);
            c.Descricao = registro["descricao"].ToString();            
            return c;
        }

        protected override void SetTabela()
        {
            Tabela = "categorias";
        }
    }
}

