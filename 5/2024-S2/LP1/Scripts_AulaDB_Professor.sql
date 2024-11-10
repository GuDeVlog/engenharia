USE [master]
GO
/****** Object:  Database [AulaDB]    Script Date: 15/05/2024 20:27:57 ******/
CREATE DATABASE [AulaDB] ON  PRIMARY 
( NAME = N'AulaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AulaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AulaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AulaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AulaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AulaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AulaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AulaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AulaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AulaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AulaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AulaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AulaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AulaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AulaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AulaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AulaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AulaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AulaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AulaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AulaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AulaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AulaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AulaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AulaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AulaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AulaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AulaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AulaDB] SET  MULTI_USER 
GO
ALTER DATABASE [AulaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AulaDB] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AulaDB', N'ON'
GO
USE [AulaDB]
GO
/****** Object:  Table [dbo].[Alunos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alunos](
	[Id] [int] NOT NULL,
	[nome] [varchar](50) NULL,
	[mensalidade] [decimal](18, 2) NULL,
	[cidadeId] [int] NULL,
	[DataNascimento] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id] [int] NOT NULL,
	[descricao] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cidades]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cidades](
	[id] [int] NOT NULL,
	[nome] [varchar](30) NULL,
	[IMAGEM] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dependente]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dependente](
	[id] [int] NOT NULL,
	[FuncionarioId] [int] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionario](
	[id] [int] NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[cpf] [varchar](15) NOT NULL,
	[Telefone] [varchar](150) NOT NULL,
	[salario] [decimal](18, 2) NOT NULL,
	[FormacaoAcademica] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funcionarios]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funcionarios](
	[func_id] [int] NOT NULL,
	[func_nome] [varchar](max) NULL,
	[func_tipo] [char](1) NULL,
	[func_ativo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jogos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jogos](
	[id] [int] NOT NULL,
	[descricao] [varchar](50) NULL,
	[valor_locacao] [decimal](18, 2) NULL,
	[data_aquisicao] [datetime] NULL,
	[categoriaID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoItem]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PedidoId] [int] NOT NULL,
	[CidadeId] [int] NOT NULL,
	[Qtde] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spAlteraAluno]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAlteraAluno]
(
 @id int,
 @nome varchar(max),
 @mensalidade money,
 @cidadeId int,
 @DataNascimento datetime
)
as
begin
 update alunos set
 nome = @nome,
 mensalidade = @mensalidade,
 cidadeId = @cidadeId,
 dataNascimento = @dataNascimento
 where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spAlteraJogo]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spAlteraJogo]
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
/****** Object:  StoredProcedure [dbo].[spConsulta]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spConsulta]
(
 @id int ,
 @tabela varchar(max)
)
as
begin
 declare @sql varchar(max);
 set @sql = 'select * from ' + @tabela +
 ' where id = ' + cast(@id as varchar(max))
 exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultaAluno]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spConsultaAluno]
(
 @id int
)
as
begin
 select * from Alunos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultaAvancadaJogos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spConsultaAvancadaJogos]
(
 @descricao varchar(max),
@categoria int,
@dataInicial datetime,
@dataFinal datetime)
as
begin
declare @categIni int
declare @categFim int
set @categIni = case @categoria when 0 then 0 else @categoria end
set @categFim = case @categoria when 0 then 999999 else @categoria end
 select jogos.*, Categorias.descricao as 'DescricaoCategoria'
from Jogos
inner join Categorias on jogos.categoriaId = categorias.id
where jogos.descricao like '%' + @descricao + '%' and
 jogos.data_aquisicao between @dataInicial and @dataFinal and
 jogos.categoriaID between @categIni and @categFim;
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultaCidade]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  procedure [dbo].[spConsultaCidade]
(@id int)
as
begin
  select * from cidades where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spConsultaJogo]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[spConsultaJogo]
(
	@id int
)
as
begin
	select * from jogos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spDelete]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spDelete]
(
 @id int ,
 @tabela varchar(max)
)
as
begin
 declare @sql varchar(max);
 set @sql = ' delete ' + @tabela +
 ' where id = ' + cast(@id as varchar(max))
 exec(@sql)
end
GO
/****** Object:  StoredProcedure [dbo].[spExcluiAluno]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spExcluiAluno]
(
 @id int
)
as
begin
 delete alunos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spExcluiJogo]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spExcluiJogo]
(
	@id int
)
as
begin
	delete jogos where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spIncluiAluno]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spIncluiAluno]
(
 @id int,
 @nome varchar(max),
 @mensalidade money,
 @cidadeId int,
 @DataNascimento datetime
)
as
begin
 insert into Alunos
 (id, nome, mensalidade, cidadeId, DataNascimento)
 values
 (@id, @nome, @mensalidade, @cidadeId, @DataNascimento)
end
GO
/****** Object:  StoredProcedure [dbo].[spIncluiJogo]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[spIncluiJogo]
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
/****** Object:  StoredProcedure [dbo].[spInsert_Alunos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsert_Alunos]
(
 @id int,
 @nome varchar(max),
 @mensalidade money,
 @cidadeId int,
 @DataNascimento datetime
)
as
begin
 insert into Alunos
 (id, nome, mensalidade, cidadeId, DataNascimento)
 values
 (@id, @nome, @mensalidade, @cidadeId, @DataNascimento)
end
GO
/****** Object:  StoredProcedure [dbo].[spInsert_Cidades]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsert_Cidades]
(
 @id int,
 @nome varchar(max) ,
 @imagem varbinary(max)
)
as
begin
 insert into Cidades (id, nome, Imagem) values (@id, @nome , @imagem)
end

GO
/****** Object:  StoredProcedure [dbo].[spInsert_Jogos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[spInsert_Jogos]
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
/****** Object:  StoredProcedure [dbo].[spInsert_Pedido]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsert_Pedido]
 @id int,
 @data datetime
as
begin
 insert into pedido(data) values (@data)
end
GO
/****** Object:  StoredProcedure [dbo].[spInsert_PedidoItem]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsert_PedidoItem]
 @id int,
 @PedidoId int,
 @CidadeId int,
 @Qtde int
as
begin
 insert into pedidoItem(pedidoId, cidadeId, Qtde)
 values (@PedidoId, @CidadeId, @Qtde)
end
GO
/****** Object:  StoredProcedure [dbo].[spListagem]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListagem]
(
 @tabela varchar(max),
 @ordem varchar(max))
as
begin
 exec('select * from ' + @tabela +
 ' order by ' + @ordem)
end
GO
/****** Object:  StoredProcedure [dbo].[spListagemAlunos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spListagemAlunos]
@tabela varchar(max),
@ordem varchar(max)
as
begin
	select Alunos.*, Cidades.Nome as NomeCidade 
	from alunos 
	Left join cidades on alunos.CidadeId = cidades.id 
   order by nome 
end
GO
/****** Object:  StoredProcedure [dbo].[spListagemCategorias]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListagemCategorias]
as
begin
	select * from categorias order by descricao
end

GO
/****** Object:  StoredProcedure [dbo].[spListagemCidades]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListagemCidades]
as
begin
 select * from cidades order by nome
end
GO
/****** Object:  StoredProcedure [dbo].[spListagemJogos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spListagemJogos]
 @tabela varchar(max),
 @ordem varchar(max)
as
begin
	select jogos.*, categorias.descricao as 'DescricaoCategoria'
	from Jogos
	left join categorias on categorias.id = jogos.categoriaID

end
GO
/****** Object:  StoredProcedure [dbo].[spProximoId]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spProximoId]
(@tabela varchar(max))
as
begin
 exec('select isnull(max(id) +1, 1) as MAIOR from '
 +@tabela)
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_Alunos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdate_Alunos]
(
 @id int,
 @nome varchar(max),
 @mensalidade money,
 @cidadeId int,
 @DataNascimento datetime
)
as
begin
 update alunos set
 nome = @nome,
 mensalidade = @mensalidade,
 cidadeId = @cidadeId,
 dataNascimento = @dataNascimento
 where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdate_Cidades]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spUpdate_Cidades]
(
 @id int,
 @nome varchar(max) ,
 @imagem varbinary(max)
)
as
begin
 update cidades set nome = @nome , imagem=@imagem where id = @id
end
GO
/****** Object:  StoredProcedure [dbo].[spupdate_Jogo]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spupdate_Jogo]
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
/****** Object:  StoredProcedure [dbo].[spupdate_Jogos]    Script Date: 15/05/2024 20:27:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spupdate_Jogos]
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
USE [master]
GO
ALTER DATABASE [AulaDB] SET  READ_WRITE 
GO
