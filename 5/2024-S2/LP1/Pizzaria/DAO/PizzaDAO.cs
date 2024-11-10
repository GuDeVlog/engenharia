
using Pizzaria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.DAO
{
    public class PizzaDAO : PadraoDAO<PizzaViewModel>
    {
        protected override SqlParameter[] CriaParametros(PizzaViewModel pizza)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("id", pizza.Id);
            parametros[1] = new SqlParameter("descricao", pizza.Descricao);
            return parametros;
        }

        protected override PizzaViewModel MontaModel(DataRow registro)
        {
            PizzaViewModel a = new PizzaViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.Descricao = registro["descricao"].ToString();            
            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "tbPizza";            
        }
    }
}


/* 

CREATE procedure [dbo].[spInsert_tbPizza]
(
 @id int,
 @descricao varchar(max) 
)
as
begin
 insert into tbPizza
 (id, descricao)
 values
 (@id, @descricao)
end
GO

CREATE procedure [dbo].[spUpdate_tbPizza]
(
 @id int,
 @descricao varchar(max)
)
as
begin
 update tbPizza set descricao = @descricao where id = @id 
end


*/