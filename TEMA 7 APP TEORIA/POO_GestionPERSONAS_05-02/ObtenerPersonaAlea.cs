using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_GestionPERSONAS_17_01
{
    public class ObtenerPersonaAlea
    {
        //Van a ser estáticos ya que no crearemos campos y se usará solo con el nombre de la clase. Sin crear objetos
        static string[] nombres = { "Pepe", "Hector", "Juan", "Manuel", "Alejandro", "Sandra", "Maria", "Marina",
                                  "Raul", "Rodrigo", "Alfonso", "Alfred", "Amaia"};
        static string[] apellidos = { "Gil", "Muñoz", "Rodriguez", "Sanchez", "García", "Moreno", "Bilal", "Espinosa",
                                    "Gálvez", "Mudarra", "López", "Expósito"};
        static Random rnd = new Random();

        public static Persona CrearPersona()
        {
            Persona p = new Persona(CrearNombre(), CrearApellidos(), CrearFechaNacimiento(), CrearEstatura());
            return p;
        }

        //Métodos Privados
        static string CrearNombre()
        {
            return nombres[rnd.Next(nombres.Length)];
        }
        static string CrearApellidos()
        {
            return apellidos[rnd.Next(apellidos.Length)] + " " + apellidos[rnd.Next(apellidos.Length)];;
        }
        static DateTime CrearFechaNacimiento()
        {
            //Fecha aleatoria de los últimos 20 años (aproximadamente)
            DateTime fecha = new DateTime();
            fecha = DateTime.Now - TimeSpan.FromDays(rnd.Next(1, 366 * 20));
            //La clase TimeSpan gestiona fechas y hace operaciones con fechas
            return fecha;
        }
        static double CrearEstatura()
        {
            //Crea una estatura entre 1.50 y 2.10
            double estatura = rnd.Next(150, 211);
            estatura /= 100; //Para que sea con 2 decimales, en metros -> 1.50m en vez de poner 150cm
            return estatura;
        }

    }
}
