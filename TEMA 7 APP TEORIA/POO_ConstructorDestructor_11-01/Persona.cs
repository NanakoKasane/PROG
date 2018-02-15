using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------------
using Marina.POO_ConstructorDestructor_11_01; //Estos solo haría falta si se llamaran diferente los 2 namespace

namespace Marina.POO_ConstructorDestructor_11_01
{
    //Por defecto una clase es publica al fichero donde lo contiene (INTERNAL)
    class Persona //public si vas a usarla fuera de la solución (como .dll por ejemplo). 
    {
        //CAMPOS: Todos los datos están ahí, se devuelven esos y se piden y almacenan esos
        public static string quienSoy = "La clase";
        public string _nombre; //Campo nombre
        //Los campos se ponen en minúscula pero se pueden subrayar la primera letra. 
        //Los métodos y clases empiezan por mayúscula. 
        int _edad; //Campo para la edad
        string _nif;

        //CONSTRUCTORES
        public Persona() //sustituye al constructor sin parámetros por defecto
        {
            _nombre = "Yo mismo";
            _edad = 0;
            _nif = "00000000-A";
        }
        public Persona(string n, int e, string nif)
        {
            _nombre = n;
            _edad = e;
            _nif = nif;
        }

        //DESTRUCTOR (al no recibir parámetros no puede haber más de uno)
        ~Persona()
        {
            //Codigo adecuado
        }


    }
}
