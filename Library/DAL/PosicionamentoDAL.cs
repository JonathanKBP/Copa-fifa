using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace Library.DAL
{
    public class PosicionamentoDAL
    {
        public List<Posicionamento> GetAll()
        {
            List<Posicionamento> lista = new List<Posicionamento>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();
                string sql = "SELECT ID_POSICAO, DS_POSICAO FROM TB_POSICIONAMENTO";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Posicionamento p = new Posicionamento();
                                p.IdPosicao = Convert.ToInt32(dr["ID_POSICAO"]);
                                p.DescricaoPosicao = Convert.ToString(dr["DS_POSICAO"]);

                                lista.Add(p);
                            }
                        }

                        return lista;

                    }


                }


            }

        }
    }
}
