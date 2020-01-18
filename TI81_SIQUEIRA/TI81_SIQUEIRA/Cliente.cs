using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TI81_SIQUEIRA
{
    class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public Cliente() { }

        public Cliente (int codigo, string nome, string endereco, string cep, string cpf, string bairro, string telefone, string cidade, string estado)
        {
            Codigo = codigo;
            Nome = nome;
            Endereco = endereco;
            CEP = cep;
            CPF = cpf;
            Bairro = bairro;
            Telefone = telefone;
            Cidade = cidade;
            Estado = estado;
        }

        public Cliente(string nome, string endereco, string cep, string cpf, string bairro, string telefone, string cidade, string estado)
        {
            Nome = nome;
            Endereco = endereco;
            CEP = cep;
            CPF = cpf;
            Bairro = bairro;
            Telefone = telefone;
            Cidade = cidade;
            Estado = estado;
        }

        //INSERIR CLIENTE
        public int gravar()
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "SP_NOVOCLIENTE";
            comm.Parameters.Add("@Tb_cli_codigo", 0).Direction = ParameterDirection.Output;
            comm.Parameters.Add("@Tb_cli_nome", SqlDbType.VarChar).Value = Nome;
            comm.Parameters.Add("@Tb_cli_Endereco", SqlDbType.VarChar).Value = Endereco;
            comm.Parameters.Add("@Tb_cli_Cep", SqlDbType.VarChar).Value = CEP;
            comm.Parameters.Add("@Tb_cli_cpf", SqlDbType.VarChar).Value = CPF;
            comm.Parameters.Add("@Tb_cli_bairro", SqlDbType.VarChar).Value = Bairro;
            comm.Parameters.Add("@Tb_cli_fone", SqlDbType.VarChar).Value = Telefone;
            comm.Parameters.Add("@Tb_cli_cidade", SqlDbType.VarChar).Value = Cidade;
            comm.Parameters.Add("@Tb_cli_estado", SqlDbType.VarChar).Value = Estado;
            comm.ExecuteNonQuery();
            Codigo = Convert.ToInt32(comm.Parameters["@Tb_cli_codigo"].Value);    //comm.ExecuteScalar());
            comm.Connection.Close();

            return Codigo;
        }

        public bool alterar()
        {
            bool alterou = false;
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = Banco.Abrir();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "SP_ATUALIZACLIENTE";
                comm.Parameters.Add("@Tb_cli_codigo", SqlDbType.Int).Value = Codigo;              //.Direction = ParameterDirection.Output;
                comm.Parameters.Add("@Tb_cli_nome", SqlDbType.VarChar).Value = Nome;
                comm.Parameters.Add("@Tb_cli_Endereco", SqlDbType.VarChar).Value = Endereco;
                comm.Parameters.Add("@Tb_cli_Cep", SqlDbType.VarChar).Value = CEP;
                comm.Parameters.Add("@Tb_cli_cpf", SqlDbType.VarChar).Value = CPF;
                comm.Parameters.Add("@Tb_cli_bairro", SqlDbType.VarChar).Value = Bairro;
                comm.Parameters.Add("@Tb_cli_fone", SqlDbType.VarChar).Value = Telefone;
                comm.Parameters.Add("@Tb_cli_cidade", SqlDbType.VarChar).Value = Cidade;
                comm.Parameters.Add("@Tb_cli_estado", SqlDbType.VarChar).Value = Estado;
                comm.ExecuteNonQuery();
                comm.Connection.Close();
                alterou = true;
            }
            catch (Exception ex)
            {
                alterou = false;
            }
            return alterou;
        }

        public void consultar(int Codigo)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = Banco.Abrir();
            comm.CommandText = "select       Tb_cli_nome, " +
                                            "Tb_cli_Endereco," +
                                            "Tb_cli_Cep, " +
                                            "Tb_cli_cpf, " +
                                            "Tb_cli_bairro, " +
                                            "Tb_cli_fone, " +
                                            "Tb_cli_cidade," +
                                            "Tb_cli_estado " +
                                            "from TB_CLIENTES where Tb_cli_codigo = " + Codigo;
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                //Codigo = dr.GetInt32(0);
                Nome = dr.GetString(0);
                Endereco = dr.GetString(1);
                CEP = dr.GetString(2);
                CPF = dr.GetString(3);
                Bairro = dr.GetString(4);
                Telefone = dr.GetString(5);
                Cidade = dr.GetString(6);
                Estado = dr.GetString(7);
            }
            comm.Connection.Close();
        }
    }
}
