using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ExcepcionDefinidaUsuario_15_02
{
    //Excepción propia que se lanza si el contador vale 0
    class ContadorCeroException : Exception
    {
        public ContadorCeroException() : base() //Llama al constructor de la clase de la que hereda (Exception)
        {
        }

        public ContadorCeroException(string mensaje) : base(mensaje) { } //Le manda el string mensaje al constructor de la clase Exception y ejecuta su constructor con ese mensaje
    

    }
}
