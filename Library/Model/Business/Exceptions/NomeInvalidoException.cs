using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Business.Exceptions
{
    public class NomeInvalidoException : Exception
    {
        public NomeInvalidoException() : base()
        {
        }
        
        public NomeInvalidoException (string mensagem) : base(mensagem)
        {
        }
    }
}
