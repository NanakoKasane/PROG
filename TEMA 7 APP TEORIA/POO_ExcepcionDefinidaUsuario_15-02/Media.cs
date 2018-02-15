using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_ExcepcionDefinidaUsuario_15_02
{
    //Clase que hace la media de un array de float
    class Media
    {
        float suma = 0;
        int contador = 0; //Número de datos que tendrá el array de float

        public float HacerMedia(float[] array)
        {
            contador = array.Length;
            if (contador == 0)
                throw new ContadorCeroException("El contador no puede ser CERO"); //Si no hay datos en el array (está vacío), no se podrá hacer la media
            else
            {
                foreach (float tmp in array)
                {
                     suma += tmp;
                }
                return suma / contador;
            }
        }
    }
}
