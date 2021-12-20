using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AlredyExistsException : Exception
    {
        public AlredyExistsException(string param, string value ):base ($"Já existe o registro {param}: {value}")
        {

        }
        
    }
}
