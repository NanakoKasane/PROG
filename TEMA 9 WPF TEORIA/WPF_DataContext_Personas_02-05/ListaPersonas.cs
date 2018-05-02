using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Collections.ObjectModel;

namespace Marina.WPF_DataContext_Personas_02_05
{
    class ListaPersonas : ObservableCollection<Persona>
    {
        Random rnd = new Random();
        
        // Crear lista de personas:
        public ListaPersonas()
            : base()
        {
            this.Add(new Persona("1. Pepe", "Castano", CrearFechaNacimiento(), CrearEstatura()));
            this.Add(new Persona("2. Antonio", "Nocasta", CrearFechaNacimiento(), CrearEstatura()));
            this.Add(new Persona("3. Alberto", "Cadiscos", CrearFechaNacimiento(), CrearEstatura()));
            this.Add(new Persona("4. Serafin", "Demes", CrearFechaNacimiento(), CrearEstatura()));
            this.Add(new Persona("5. Javi", "Sama Amado", CrearFechaNacimiento(), CrearEstatura()));

        }

        private DateTime CrearFechaNacimiento()
        {
            // Fecha de Nacimiento de los últimos 20 años:
            DateTime fecha = DateTime.Now - TimeSpan.FromDays(rnd.Next(1, 365 * 20));
            return fecha;
        }

        private double CrearEstatura()
        {
            // Estatura desde 1.50 a 2.10:
            double estatura = rnd.Next(150, 211);
            return estatura / 100;
        }
    }
}
