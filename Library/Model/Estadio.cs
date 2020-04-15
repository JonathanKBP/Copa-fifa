using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Estadio
    {
        private int id;
        private string nome;
        private string cidade;
        private int capacidade;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public int Capacidade { get => capacidade; set => capacidade = value; }

    }
}
