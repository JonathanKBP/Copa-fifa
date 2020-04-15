using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.Enuns;
namespace Library.Model
{
   public class Jogador

    {
        
//Criar Construtor
    public Jogador()
    {
        //Construtor sem parametros
    }

    public Jogador(DateTime _DataConvocacao, DateTime _DataDispensa)
        {
            this.dtConvocacao = _DataConvocacao;
            this.dtDispensa = _DataDispensa;
        }

    public Jogador(DateTime _dataNascimento)
    {
        this.dtNascimento = _dataNascimento;
    }

     private int id;
     private string nmNome;
     private DateTime dtNascimento;
     private int nrCamisa;
     private string nmPosicao;
     private DateTime dtConvocacao;
     private DateTime dtDispensa;
     private PosicaoEnum posicao;


        public int Id { get => id; set => id = value; }
        public string NmNome { get => nmNome; set => nmNome = value; }
        public DateTime DtNascimento { get => dtNascimento; set => dtNascimento = value; }
        public int NrCamisa { get => nrCamisa; set => nrCamisa = value; }
        public string NmPosicao { get => nmPosicao; set => nmPosicao = value; }
        public DateTime DtConvocacao { get => dtConvocacao; set => dtConvocacao = value; }
        public DateTime DtDispensa { get => dtDispensa; set => dtDispensa = value; }
        public PosicaoEnum Posicao { get => posicao; set => posicao = value; }

  

        public string ObterDados()
        {
            string menssagemFormatada =
                string.Format("Nome: {0}  Nº: {1}  Posição: {2}", nmNome, nrCamisa, nmPosicao);
            return menssagemFormatada;
        }

        public int CalcularIdade(DateTime dtNascimento)
        {
            int dia, ano;

            dia = DateTime.Now.Subtract(dtNascimento).Days;
           
            ano = dia / 365;

            return  ano; 
        }
        
     }
}
