using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public  class NotFoundException : Exception
    {
        public NotFoundException(string param, string value) : base($"Não existe registro para {param}: {value}")
        {

        }
    }
}
