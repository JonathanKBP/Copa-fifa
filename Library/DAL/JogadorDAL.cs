using Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class JogadorDAL
    {
        public int Insert(Jogador j)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_JOGADOR ");
                sql.AppendLine("(ID_POSICIONAMENTO, DE_NOME, DT_NASCIMENTO, NR_CAMISA, DT_CONVOCACAO, DT_DISPENSA) ");
                sql.AppendLine("VALUES (@ID_POSICIONAMENTO, @DE_NOME, @DT_NASCIMENTO, @NR_CAMISA, @DT_CONVOCACAO, @DT_DISPENSA) ");
                sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_POSICIONAMENTO", (int)j.Posicao);
                    cmd.Parameters.AddWithValue("@DE_NOME", j.NmNome);
                    cmd.Parameters.AddWithValue("@DT_NASCIMENTO", j.DtNascimento);
                    cmd.Parameters.AddWithValue("@NR_CAMISA", j.NrCamisa);
                    cmd.Parameters.AddWithValue("@DT_CONVOCACAO", j.DtConvocacao);
                    cmd.Parameters.AddWithValue("@DT_DISPENSA", j.DtDispensa);

                    con.Open();
                    j.Id = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();
                }
                return reg;
            }
        }

        public List<Jogador> GetAll()
        {
            List<Jogador> listaJogadores = new List<Jogador>();
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID_JOGADOR, a.ID_POSICIONAMENTO, a.DE_NOME, a.DT_NASCIMENTO, ");
                sql.AppendLine("a.NR_CAMISA, a.DT_CONVOCACAO, a.DT_DISPENSA, b.DS_POSICAO ");
                sql.AppendLine("FROM TB_JOGADOR a ");
                sql.AppendLine("INNER JOIN TB_POSICIONAMENTO b ON a.ID_POSICIONAMENTO = b.ID_POSICAO ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Jogador j = new Jogador();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                j.Id = Convert.ToInt32(dr["ID_JOGADOR"]);
                                j.Posicao = (Model.Enuns.PosicaoEnum)Convert.ToInt32(dr["ID_POSICIONAMENTO"]);
                                j.NmNome = dr["DE_NOME"].ToString();
                                j.DtNascimento = Convert.ToDateTime(dr["DT_NASCIMENTO"]);
                                j.NrCamisa = Convert.ToInt32(dr["NR_CAMISA"]);
                                j.DtConvocacao = Convert.ToDateTime(dr["DT_CONVOCACAO"]);
                                j.DtDispensa = Convert.ToDateTime(dr["DT_DISPENSA"]);
                                j.NmPosicao = dr["DS_POSICAO"].ToString();

                                listaJogadores.Add(j);//Adicionando o objeto para a lista
                            }
                        }
                        return listaJogadores;
                    }
                }
            }
        }

        public Jogador GetById(int id)
        {
            Jogador j = null;

            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                con.Open();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID_JOGADOR, a.ID_POSICIONAMENTO, a.DE_NOME, a.DT_NASCIMENTO, ");
                sql.AppendLine("a.NR_CAMISA, a.DT_CONVOCACAO, a.DT_DISPENSA, b.DS_POSICAO ");
                sql.AppendLine("FROM TB_JOGADOR a ");
                sql.AppendLine("INNER JOIN TB_POSICIONAMENTO b ON a.ID_POSICIONAMENTO = b.ID_POSICAO ");
                sql.AppendLine("WHERE a.ID_JOGADOR = @ID_JOGADOR ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@ID_JOGADOR", id); //Passagem de parametro

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                j = new Jogador();//Instanciando o objeto da iteração
                                //Preenchimento das propriedades a partir do que retornou no banco.
                                j.Id = Convert.ToInt32(dr["ID_JOGADOR"]);
                                j.Posicao = (Model.Enuns.PosicaoEnum)Convert.ToInt32(dr["ID_POSICIONAMENTO"]);
                                j.NmNome = dr["DE_NOME"].ToString();
                                j.DtNascimento = Convert.ToDateTime(dr["DT_NASCIMENTO"]);
                                j.NrCamisa = Convert.ToInt32(dr["NR_CAMISA"]);
                                j.DtConvocacao = Convert.ToDateTime(dr["DT_CONVOCACAO"]);
                                j.DtDispensa = Convert.ToDateTime(dr["DT_DISPENSA"]);
                                j.NmPosicao = dr["DS_POSICAO"].ToString();


                            }
                        }
                        return j;
                    }
                }
            }
        }

        public int Update(Jogador j)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("UPDATE TB_JOGADOR SET ");
                sql.AppendLine("ID_POSICIONAMENTO = @ID_POSICIONAMENTO, ");
                sql.AppendLine("DE_NOME = @DE_NOME, ");
                sql.AppendLine("DT_NASCIMENTO = @DT_NASCIMENTO, ");
                sql.AppendLine("NR_CAMISA = @NR_CAMISA, ");
                sql.AppendLine("DT_CONVOCACAO = @DT_CONVOCACAO, ");
                sql.AppendLine("DT_DISPENSA = @DT_DISPENSA ");
                sql.AppendLine("WHERE ID_JOGADOR = @ID_JOGADOR");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_POSICIONAMENTO", j.Posicao);
                    cmd.Parameters.AddWithValue("@DE_NOME", j.NmNome);
                    cmd.Parameters.AddWithValue("@DT_NASCIMENTO", j.DtNascimento);
                    cmd.Parameters.AddWithValue("@NR_CAMISA", j.NrCamisa);
                    cmd.Parameters.AddWithValue("@DT_CONVOCACAO", j.DtConvocacao);
                    cmd.Parameters.AddWithValue("@DT_DISPENSA", j.DtDispensa);
                    cmd.Parameters.AddWithValue("@ID_JOGADOR", j.Id);//Necessário ID para saber qual registro será atualizado

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }

        public int Delete(int id)
        {
            int linhasAfetadas = 0;
            using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FROM TB_JOGADOR ");
                sql.AppendLine("WHERE ID_JOGADOR = @ID_JOGADOR ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_JOGADOR", id);

                    con.Open();
                    linhasAfetadas = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return linhasAfetadas;
            }
        }
    }
}
