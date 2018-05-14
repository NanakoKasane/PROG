using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.IO;

namespace WPF_Personas_Template_Lista_10_05
{
    class ListaPersonas : ObservableCollection<Persona>
    {
        Random rnd = new Random();
        List<BitmapImage> listaImagenes = new List<BitmapImage>();

        public List<BitmapImage> ListaImagenes
        {
            get { return listaImagenes; }
            set { listaImagenes = value; }
        }
        
        // Crear lista de personas:
        public ListaPersonas()
            : base()
        {
            LlenarListaImagenes();
            this.Add(new Persona("1. Pepe", "Castano", CrearFechaNacimiento(), CrearEstatura(), listaImagenes[rnd.Next(listaImagenes.Count)]));
            this.Add(new Persona("2. Antonio", "Nocasta", CrearFechaNacimiento(), CrearEstatura(), listaImagenes[rnd.Next(listaImagenes.Count)]));
            this.Add(new Persona("3. Alberto", "Cadiscos", CrearFechaNacimiento(), CrearEstatura(), listaImagenes[rnd.Next(listaImagenes.Count)]));
            this.Add(new Persona("4. Serafin", "Demes", CrearFechaNacimiento(), CrearEstatura(), listaImagenes[rnd.Next(listaImagenes.Count)]));
            this.Add(new Persona("5. Javi", "Sama Amado", CrearFechaNacimiento(), CrearEstatura(), listaImagenes[rnd.Next(listaImagenes.Count)]));

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

        // Las rutas están en un fichero, en cada línea una ruta de la imagen. Lo guardo en la lista de imagenes
        private void LlenarListaImagenes()
        {
            using (FileStream flujo = new FileStream("../../imgCaricaturas/caricaturas.txt", FileMode.Open))
            {
                using (StreamReader lector = new StreamReader(flujo))
                {
                    string rutaTmp;
                    string rutaInicial = "./imgCaricaturas/";
                    Uri rutaUriTmp;
                    BitmapImage imagenTmp;
                    

                    while (!lector.EndOfStream)
                    {
                        rutaTmp = lector.ReadLine();

                        if (rutaTmp == "caricaturas.txt") // La primera línea del fichero no es una imagen válida, las demás ya sí
                            continue;

                        rutaUriTmp = new Uri(rutaInicial + rutaTmp, UriKind.Relative);
                        imagenTmp = new BitmapImage(rutaUriTmp);
                        listaImagenes.Add(imagenTmp);
                    }

                }
            }

        }

    }
}
