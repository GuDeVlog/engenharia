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
    public class JogoDAO
    {
        private SqlParameter[] CriaParametros(JogoViewModel jogo)
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


        public void Inserir(JogoViewModel jogo)
        {          

            HelperDAO.ExecutaProc("spIncluiJogo", CriaParametros(jogo));
        }


        public void Alterar(JogoViewModel jogo)
        {
            
            HelperDAO.ExecutaProc("spAlteraJogo", CriaParametros(jogo));
        }

        public void Excluir(int id)
        {
            SqlParameter[] p = { new SqlParameter("id", id) };
            HelperDAO.ExecutaProc("spExcluiJogo", p);
        }


        public JogoViewModel Consulta(int id)
        {
            SqlParameter[] p = { new SqlParameter("id", id) };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spConsultaJogo", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }


        public List<JogoViewModel> Lista()
        {
            
            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemJogos", null);
            List<JogoViewModel> retorno = new List<JogoViewModel>();

            foreach (DataRow registro in tabela.Rows)
            {
                retorno.Add(MontaModel(registro));
            }

            return retorno;
        }


        public int ProximoId()
        {
            SqlParameter[] p = { new SqlParameter("tabela", "jogos") };
            DataTable tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }



        public  JogoViewModel MontaModel(DataRow registro)
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
 create procedure spIncluiJogo
(
	@id int,
	@descricao varchar(max),
	@valor_locacao money,
	@categoriaId int,
	@Data_aquisicao datetime
)
as
begin
  insert into jogos
  (id,descricao,valor_locacao,data_aquisicao,categoriaID)
  values
  (@id,@descricao,@valor_locacao, @data_aquisicao,@categoriaID)
end
GO

create procedure spAlteraJogo
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
		valor_locacao = @valor_locacao ,
		categoriaId = @categoriaId,
		Data_aquisicao = @Data_aquisicao
	where id = @id
end

GO
create procedure spExcluiJogo
(
	@id int
)
as
begin
	delete jogos where id = @id
end
GO


create procedure spConsultaJogo
(
	@id int
)
as
begin
	select * from jogos where id = @id
end
GO

create  procedure spListagemJogos
as
begin
	select jogos.*, categorias.descricao as 'DescricaoCategoria'
	from Jogos
	left join categorias on categorias.id = jogos.categoriaID

end

GO  
 * */
