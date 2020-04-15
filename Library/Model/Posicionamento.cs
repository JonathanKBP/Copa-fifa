using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
   public class Posicionamento
    {
        private int idPosicao;
        private string descricaoPosicao;

        public int IdPosicao { get => idPosicao; set => idPosicao = value; }
        public string DescricaoPosicao { get => descricaoPosicao; set => descricaoPosicao = value; }
    }

}
