using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TI81_SIQUEIRA
{
    public static class Banco
    {
        public static SqlConnection Abrir()
        {
            //string strConexao = @"Data Source=127.0.0.1;Initial Catalog=TI81_SIQUEIRA;User ID=sa;pwd=senac@itq"; //inserir as string de conexão
            string strConexao = @"Data Source=127.0.0.1 ;Database=TI81_SIQUEIRA;Integrated Security=True";
            SqlConnection cn = new SqlConnection(strConexao);
            cn.Open();//abrir conexão
            return cn;
        }
    }
}
