using Library.Model;
using Library.Model.Enuns;
using Library.Model.Business.Exceptions;
using System;
using Library.Model.Business;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCopa
{
    public partial class CadastroJogador : System.Web.UI.Page
    {
        JogadorBLL jService = new JogadorBLL();
        PosicionamentoBLL posService = new PosicionamentoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Jogador j = new Jogador();
            if (!Page.IsPostBack)
            {
                /*ddlPosicao.DataSource = Enum.GetValues(typeof(PosicaoEnum));
                ddlPosicao.DataBind();
                ddlPosicao.Items.Insert(0, new ListItem("-----Selecione------", "0"));
                */
                //Carregamento do DropDownList com Lista
                ddlPosicao.DataSource = posService.GetAll();
                ddlPosicao.Items.Insert(0, new ListItem("-----Selecione------", "0"));
                ddlPosicao.DataValueField = "IdPosicao";// Vinculação do Id (Propriedade da classe)
                ddlPosicao.DataTextField = "DescricaoPosicao";
                ddlPosicao.DataBind();

                if (!string.IsNullOrEmpty(Request.QueryString["JogadorId"])) //Vinculaçao  do texto (Propriedade de Classe)
                {
                    int jogadorId = Convert.ToInt32(Request.QueryString["JogadorId"].ToString());
                    j = jService.GetById(jogadorId);
                    SetJogador(j);
                }
            }


        }


        protected void btnCalcularIdade_Click(object sender, EventArgs e)
        {
            Jogador j = new Jogador(Convert.ToDateTime(txtDataNascimento.Text));

            lblMensagem.Text = j.CalcularIdade(j.DtNascimento).ToString();

        }

        protected void btnCalcularIndenizacaoFifa_Click(object sender, EventArgs e)
        {
            Jogador j = new Jogador(Convert.ToDateTime(txtConvocacao.Text), Convert.ToDateTime(txtDispensa.Text));
            int diasConvocacao = DateTime.Now.Subtract(j.DtConvocacao).Days;
            int diasDispensa = DateTime.Now.Subtract(j.DtDispensa).Days;
            Decimal moeda = ((diasConvocacao - diasDispensa) * 8530) * Convert.ToDecimal(4.19);
            lblMensagem.Text = string.Format("R$ {0}", moeda);

        }

        protected void btnExibirDados_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    throw new NomeInvalidoException("O nome deve ser digitado. ");
                }
                if (ddlPosicao.SelectedValue == "0")
                {
                    throw new PosicaoInvalidaException("Selecione a posição em que o jogador atua.");
                }


                Jogador j = new Jogador();

                j.NmNome = txtNome.Text;
                j.DtNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                j.NrCamisa = Convert.ToInt32(txtNumeroCamisa.Text);


                //j.NmPosicao = txtPosicao.Text;

                j.Posicao = (PosicaoEnum)Enum.Parse(typeof(PosicaoEnum), ddlPosicao.SelectedValue);

                if (j.Posicao == PosicaoEnum.LateralDireito)
                    j.NmPosicao = "Lateral Direito";

                else if (j.Posicao == PosicaoEnum.LateralEsquerdo)
                    j.NmPosicao = "Lateral Esquerdo";

                else if (j.Posicao == PosicaoEnum.MeioCampo)
                    j.NmPosicao = "Meio Campo";

                else j.NmPosicao = j.Posicao.ToString();



                j.DtConvocacao = Convert.ToDateTime(txtConvocacao.Text);

                j.DtDispensa = Convert.ToDateTime(txtDispensa.Text);
                lblMensagem.Text = j.ObterDados();


            }
            catch (NomeInvalidoException nEx)
            {
                lblMensagem.Text = nEx.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
            catch (PosicaoInvalidaException posicaoEx)
            {
                lblMensagem.Text = posicaoEx.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    throw new NomeInvalidoException("O nome deve ser digitado. ");
                }
                if (ddlPosicao.SelectedValue == "0")
                {
                    throw new PosicaoInvalidaException("Selecione a posição em que o jogador atua.");
                }


                Jogador j = new Jogador();

                j.NmNome = txtNome.Text;
                j.DtNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                j.NrCamisa = Convert.ToInt32(txtNumeroCamisa.Text);
                j.DtConvocacao = Convert.ToDateTime(txtConvocacao.Text);
                j.DtDispensa = Convert.ToDateTime(txtDispensa.Text);
                                
                //j.NmPosicao = txtPosicao.Text;
                j.Posicao = (PosicaoEnum)Enum.Parse(typeof(PosicaoEnum), ddlPosicao.SelectedValue);

                if (j.Posicao == PosicaoEnum.LateralDireito)
                    j.NmPosicao = "Lateral Direito";

                else if (j.Posicao == PosicaoEnum.LateralEsquerdo)
                    j.NmPosicao = "Lateral Esquerdo";

                else if (j.Posicao == PosicaoEnum.MeioCampo)
                    j.NmPosicao = "Meio Campo";

                else j.NmPosicao = j.Posicao.ToString();


                string mensagem = "";

                //TODO:Salvamento no banco de dados sendo feito aqui:
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    jService.Insert(j);
                    mensagem = string.Format("Jogador ID {0} salvo com sucesso.", j.Id);

                }
                else
                {
                    j.Id = Convert.ToInt32(txtId.Text);
                    jService.Update(j);
                    mensagem = string.Format("Jogador ID {0} atualizado com sucesso.", j.Id);
                }   

                

                string scriptMensagem = string.Format("<script>ChamarExibirMensagemSucesso('{0}');</script>", mensagem);

                //j.Id = (!string.IsNullOrEmpty(txtId.Text)) ? Convert.ToInt32(txtId.Text) : 0;
                //lblMensagem.Text = j.ObterDados();

                //Faz a chamada da função Javascript via código.

                ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);

                //TODO: Salvamento no banco de dados será realizado aqui, futuramente!!

                scriptMensagem = string.Format("<script>ChamarExibirMensagem('{0}');</script>", j.ObterDados());

                lblMensagem.Text = mensagem;
            }
            /*catch (NomeInvalidoException nEx)
            {
                lblMensagem.Text = nEx.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }*/
            catch (NomeInvalidoException nEx)
            {
                //Prepara a função Javascript para ser executada.

                string scriptMensagem = string.Format("<script>ChamarExibirMensagemErro('{0}');</script>", nEx.Message);

                //Faz s chamada da função javascript via código.

                ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);


            }
            catch (PosicaoInvalidaException posicaoEx)
            {
                lblMensagem.Text = posicaoEx.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
            /*catch (NomeInvalidoException nEx)
            {
                //Prepara a função Javascript para ser executada.

                string scriptMensagem = string.Format("<script>ChamarExibirMensagemErro('{0}');</script>", nEx.Message);

                //Faz s chamada da função javascript via código.

                ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);


            }*/
            
        }

        public void SetJogador(Jogador j)
        {
            txtId.Text = j.Id.ToString();
            txtNome.Text = j.NmNome;
            txtDataNascimento.Text = string.Format("{0: dd/MM/yyyy}", j.DtNascimento);
            ddlPosicao.SelectedValue = string.Format("{0}", j.Posicao);
            txtNumeroCamisa.Text = j.NrCamisa.ToString();
            txtConvocacao.Text = string.Format("{0:dd/MM/yyyy}", j.DtConvocacao);
            txtDispensa.Text = string.Format("{0: dd/MM/yyyy}", j.DtDispensa);
        }

        protected void bntExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                bool excluiu = jService.Delete(id);

                if(excluiu)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", "<script>ChamarFecharPopUp();</script");
                    lblMensagem.Text = "Jogador excluido";
                }

            }

            catch (Exception ex)
            {
                string scriptMensagem = string.Format("<script>ChamarExibirMensagemErro('{0}');</scrip>", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "ChaveMensagem", scriptMensagem);
                lblMensagem.Text = "Erro ao excluir";
            }



        }
    }
}