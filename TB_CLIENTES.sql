--Aluno: Gabriel Siqueira Nascimento Silva
--Turma: TI-81

--CRIANDO O BANCO DE DADOS TI81_SIQUEIRA
create database TI81_SIQUEIRA	
go

--USANDO O BANCO TI81_SIQUEIRA
use TI81_SIQUEIRA
go

--CRIANDO TABELA TB_CLIENTES
create table TB_CLIENTES(
Tb_cli_codigo		int primary key identity (1,1),
Tb_cli_nome			varchar(50) not null,
Tb_cli_Endereco		varchar(50) not null,
Tb_cli_Cep			varchar(9) not null,
Tb_cli_cpf			varchar(14) not null,
Tb_cli_bairro		varchar(30) not null,
Tb_cli_fone			varchar(9) not null,
Tb_cli_cidade		varchar(30) not null,
Tb_cli_estado		varchar(2) not null
)

--CRIANDO PROCUDURE SP_NOVOCLIENTE
create procedure SP_NOVOCLIENTE
@Tb_cli_codigo		int output,
@Tb_cli_nome		varchar(50),
@Tb_cli_Endereco	varchar(50),
@Tb_cli_Cep			varchar(9),
@Tb_cli_cpf			varchar(14),
@Tb_cli_bairro		varchar(30),
@Tb_cli_fone		varchar(9),
@Tb_cli_cidade		varchar(30),
@Tb_cli_estado		varchar(2)
as
	begin
		insert into TB_CLIENTES(Tb_cli_nome, Tb_cli_Endereco, Tb_cli_Cep, Tb_cli_cpf, Tb_cli_bairro,Tb_cli_fone, Tb_cli_cidade, Tb_cli_estado)
		values (@Tb_cli_nome, @Tb_cli_Endereco, @Tb_cli_Cep, @Tb_cli_cpf, @Tb_cli_bairro, @Tb_cli_fone, @Tb_cli_cidade, @Tb_cli_estado)
		select @Tb_cli_codigo = @@IDENTITY
	end


--CRIANDO PROCUDURE SP_ATUALIZACLIENTE
create procedure SP_ATUALIZACLIENTE
@Tb_cli_codigo		int output,
@Tb_cli_nome		varchar(50),
@Tb_cli_Endereco	varchar(50),
@Tb_cli_Cep			varchar(9),
@Tb_cli_cpf			varchar(14),
@Tb_cli_bairro		varchar(30),
@Tb_cli_fone		varchar(9),
@Tb_cli_cidade		varchar(30),
@Tb_cli_estado		varchar(2)
as
	begin
		UPDATE TB_CLIENTES set		Tb_cli_nome			= @Tb_cli_nome, 
									Tb_cli_Endereco		= @Tb_cli_Endereco, 
									Tb_cli_Cep			= @Tb_cli_Cep, 
									Tb_cli_cpf			= @Tb_cli_cpf, 
									Tb_cli_bairro		= @Tb_cli_bairro,
									Tb_cli_fone			= @Tb_cli_fone, 
									Tb_cli_cidade		= @Tb_cli_cidade, 
									Tb_cli_estado		= @Tb_cli_estado
									where Tb_cli_codigo = @Tb_cli_codigo
	end


--CRIANDO PROCUDURE SP_SELECIONAPORCPF
create procedure SP_SELECIONAPORCPF
@Tb_cli_codigo		int output,
@Tb_cli_nome		varchar(50),
@Tb_cli_Endereco	varchar(50),
@Tb_cli_Cep			varchar(9),
@Tb_cli_cpf			varchar(14),
@Tb_cli_bairro		varchar(30),
@Tb_cli_fone		varchar(9),
@Tb_cli_cidade		varchar(30),
@Tb_cli_estado		varchar(2)
as
	begin
		select		Tb_cli_nome,			 
					Tb_cli_Endereco,		 
					Tb_cli_Cep,			
					Tb_cli_cpf,			 
					Tb_cli_bairro,		
					Tb_cli_fone,			 
					Tb_cli_cidade,		
					Tb_cli_estado		
					FROM TB_CLIENTES		WHERE Tb_cli_cpf = @Tb_cli_cpf
	end