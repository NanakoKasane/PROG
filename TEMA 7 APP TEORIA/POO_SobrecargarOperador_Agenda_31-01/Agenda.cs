using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_SobrecargarOperador_Agenda_31_01
{
    class Agenda
    {
        const int NUMMAXENTRADAS = 100; //Número máximo de anotaciones que podrás hacer en la agenda.
        string[] anotaciones = new string[NUMMAXENTRADAS];
        int ultimaAnotacion = 0; //Como nDatos, contador de anotaciones

        //Definición del operador + para añadir anotaciones
        public static bool operator +(Agenda unaAgenda, string anotacion)
        {
            //Si tienes un método estático, no puedes acceder a variables que no sean estáticas. Accedes con nombreObejo.variableNoEstática
            if (unaAgenda.ultimaAnotacion == NUMMAXENTRADAS) //Preguntar si cabe
                return false;
            else
            {
                unaAgenda.anotaciones[unaAgenda.ultimaAnotacion++] = anotacion;
                return true;
            }
        }

        public void ListarAnotaciones()
        {
            for (int i = 0; i < ultimaAnotacion; i++)
            {
                Console.WriteLine(anotaciones[i]);
            }

            Console.Write(" No hay más anotaciones ... ");
            Console.ReadLine();
        }


    }
}
