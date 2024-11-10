
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
    public class IngredientesPizzaDAO : PadraoDAO<IngredientesPizzaViewModel>
    {
        protected override SqlParameter[] CriaParametros(IngredientesPizzaViewModel ingredientes)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("id", ingredientes.Id);
            parametros[1] = new SqlParameter("Pizzaid", ingredientes.PizzaId);
            parametros[2] = new SqlParameter("descricao", ingredientes.Descricao);
            return parametros;
        }

        protected override IngredientesPizzaViewModel MontaModel(DataRow registro)
        {
            var a = new IngredientesPizzaViewModel();
            a.Id = Convert.ToInt32(registro["id"]);
            a.PizzaId = Convert.ToInt32(registro["Pizzaid"]);
            a.Descricao = registro["descricao"].ToString();            
            return a;
        }

        protected override void SetTabela()
        {
            Tabela = "tbIngredientesPizza";
            NomeSpListagem = "spListagemIngredientesPizza";
        }

        public virtual List<IngredientesPizzaViewModel> Listagem(int pizzaId)
        {
            var p = new SqlParameter[]
            {
               new SqlParameter("Pizzaid", pizzaId)             
            };
            var tabela = HelperDAO.ExecutaProcSelect(NomeSpListagem, p);
            var lista = new List<IngredientesPizzaViewModel>();
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));

            return lista;
        }
    }
}


/* 


CREATE procedure [dbo].[spInsert_tbIngredientesPizza]
(
 @id int,
 @pizzaId int,A
 @descricao varchar(max) 
)
as
begin
 insert into tbIngredientesPizza
 (id, pizzaID, descricao)
 values
 (@id,@pizzaId,  @descricao)
end


GO

CREATE procedure [dbo].[spUpdate_tbIngredientesPizza]
(
 @id int,
 @pizzaid int,
 @descricao varchar(max)
)
as
begin
 update tbIngredientesPizza set 
   descricao = @descricao , 
   pizzaid = @pizzaid
 where id = @id 
end
GO


create procedure spListagemIngredientesPizza
(@pizzaId int)
as
begin
   select * from tbIngredientesPizza
   where pizzaId = @pizzaId
end
GO

*/