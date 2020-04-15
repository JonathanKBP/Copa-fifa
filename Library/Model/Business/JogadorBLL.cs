using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Business
{
     public class JogadorBLL
    {
        public bool Insert(Jogador j)
        {
            bool salvou = false;
            new JogadorDAL().Insert(j);

            //Se o ID for maior que zero, indica que o dado foi salvo
            if (j.Id > 0)
            {
                salvou = true;
            }
            return salvou;
        }

        public List<Jogador> GetAll()
        {
            JogadorDAL jogadorDAL = new JogadorDAL();
            return jogadorDAL.GetAll();
        }

        public Jogador GetById(int id)
        {
            JogadorDAL jogadorDAL = new JogadorDAL();
            return jogadorDAL.GetById(id);
        }

        public bool Update(Jogador j)
        {
            bool atualizou = false;
            JogadorDAL dDAL = new JogadorDAL();

            if (j.Id == 0)
            {
                throw new Exception("Selecione uma Jogador para atualizar.");
            }

            if (dDAL.Update(j) > 0)
            {
                //Este IF verificará se o retorno do método será maior que 0,
                //ou seja, se a atualização foi feita pela classe que acessa o Banco
                //se sim vai mudar para TRUE a variável e retornar para quem chamou este método.
                atualizou = true;
            }
            return atualizou;
        }

        public bool Delete(int id)
        {
            bool deletou = false;
            JogadorDAL jDAL = new JogadorDAL();
            if (jDAL.Delete(id) > 0)
            {
                deletou = true;
            }
            return deletou;
        }
    }

}
