using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------------------
using System.Collections;

namespace POO_Iterar_Foreach_Interfaz_05_02
{
    class MiLista : IEnumerator, IEnumerable 
    {
        int[] numeros = { 1, 3, 5, 99, 110, 4, 7 };
        int posicion = -1;

        public object Current
        {
            //Devuelve el elemento de la posición actual
            get { return numeros[posicion]; }
        }

        public bool MoveNext()
        {
            //Desplaza el índice/posición al siguiente valor
            //Devuelve true si se ha podido avanzar con éxito. Y false si no ha podido avanzar por haber alcanzado el final de la colección. 
            
            if (posicion < numeros.Length - 1 ) //avanza uno más (posicion++), llega hasta numeros.Length -1 (Que es la última posición)
            {
                posicion++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            posicion = -1;
        }

        public IEnumerator GetEnumerator()
        {
            //Pide que devuelva una Interfaz que sea IEnumerator
            return this; //Y es esta misma clase ya que acabas de implementar IEnumerator y la clase se comporta como ese interfaz
        }
    }
}
