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
    public class JogoDAO : PadraoDAO<JogoViewModel>
    {
        protected override SqlParameter[] CriaParametros(JogoViewModel jogo)
        {
            SqlParameter[] p = {
                new SqlParameter("id", jogo.Id),
                new SqlParameter("descricao", jogo.Descricao),
                new SqlParameter("categoriaID", jogo.CategoriaID),
                new SqlParameter("data_aquisicao", jogo.DataAquisicao),
                new SqlParameter("valor_locacao", jogo.Valor),
            };
            return p;
        }

        protected override JogoViewModel MontaModel(DataRow registro)
        {
            JogoViewModel Jogo = new JogoViewModel();
            Jogo.Id = Convert.ToInt32(registro["id"]);
            Jogo.Descricao = registro["descricao"].ToString();
            Jogo.CategoriaID = Convert.ToInt32(registro["categoriaID"]);
            Jogo.Valor = Convert.ToDouble(registro["valor_locacao"]);
            Jogo.DataAquisicao = Convert.ToDateTime(registro["data_aquisicao"]);

            if (registro.Table.Columns.Contains("DescricaoCategoria"))
                Jogo.DescricaoCategoria = registro["DescricaoCategoria"].ToString();

            return Jogo;
        }

        protected override void SetTabela()
        {
            Tabela = "jogos";
            NomeSpListagem = "spListagemJogos";
        }


        public List<JogoViewModel> ConsultaAvancadaJogos(string descricao,
                                 int categoria,
                                 DateTime dataInicial,
                                 DateTime dataFinal)
        {
            SqlParameter[] p = {
                         new SqlParameter("descricao", descricao),
                         new SqlParameter("categoria", categoria),
                         new SqlParameter("dataInicial", dataInicial),
                         new SqlParameter("dataFinal", dataFinal),
                         };
            var tabela = HelperDAO.ExecutaProcSelect("spConsultaAvancadaJogos", p);
            var lista = new List<JogoViewModel>();
            foreach (DataRow dr in tabela.Rows)
                lista.Add(MontaModel(dr));
            return lista;
        }
    }
}


/*
--select * from jogos

create procedure spInsert_Jogos
(
@id int,
@descricao varchar(max),
@valor_locacao money,
@categoriaId int,
@Data_aquisicao datetime
)
as
begin
insert into Jogos
(id, descricao, valor_locacao, categoriaID, data_aquisicao)
values
(@id, @descricao, @valor_locacao, @categoriaID, @data_aquisicao)
end
GO


create procedure spUpdate_Jogos
(
@id int,
@descricao varchar(max),
@valor_locacao money,
@categoriaId int,
@Data_aquisicao datetime
)
as
begin
update jogos set
descricao = @descricao,
valor_locacao = @valor_locacao,
@categoriaId = @categoriaId,
data_aquisicao = @Data_aquisicao
where id = @id
end
GO 
  
 * */
