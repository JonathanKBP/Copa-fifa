using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library.DAL
{

    public class ConnectionFactory
    {

        public static string nomeConexao = "ConexaoHoracio";
        public bool TestarConexao()
        {
            bool conectado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    conectado = (con.State == System.Data.ConnectionState.Open);
                    con.Close();
                    return conectado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao estabelecer conexão: " + ex.Message);
            }

        }
        public static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings[nomeConexao].ConnectionString;
        }
    }
}
