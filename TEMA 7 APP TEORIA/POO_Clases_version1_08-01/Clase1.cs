using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina.POO_Clases_version1_08_01 //Tiene que llamarse igual que el principal para que puedas acceder 
{
    class Clase1
    {
        private int x = 10;
        protected float edad = 2.2F;
    }

    public class Clase2 : Clase1 //Podrá ver la edad pero no x.
    {

    }
}
