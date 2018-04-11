using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Imagen_YExaminar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCargarImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog(); // Cuadro de dialogo para examinar archivo/imagen.      
            string ruta = string.Empty; // Ruta de la imagen
            BitmapImage imagen = new BitmapImage(); // Para guardar la imagen.
            Nullable<bool> resultado = ofd.ShowDialog(this); // Nullable --> Cualquier tipo de variable que admite null. Estás convirtiendo un bool en otra variable que admite null --> bool? .
            ofd.InitialDirectory = @"C:\Users\Alumno1718\Desktop\imagenes"; // Se irá ahí al principio para buscar la imagen.

            // Si ha examinado un fichero que supuestamente es válido:
            if (resultado == true) // Al poder ser null, hay 3 opciones y no vale con if (resultado). Hay que especificar si es null, true o false.
            {
                ruta = ofd.FileName;
                this.Title = ruta;
                imagen.BeginInit(); // Inicio del BitmapImage (Inicializa el objeto en el que a partir de ahora puedes echarle una imagen).
                imagen.UriSource = new Uri(ruta.Trim(), UriKind.RelativeOrAbsolute); // Si no le indicas el tipo sería absoluta.
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.EndInit();

                imgImagen.Source = imagen;
            }

            // Para cargar muchas imágenes --> Crear array de string con las rutas y cada vez para verla le cambias la ruta al Uri (O crear array de BitmapImage)

        }

        private void btnCargarImgLocal_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage imagen = new BitmapImage(new Uri("./marcelinexchicle.png", UriKind.Relative)); // Se puede cargar imagen de memoria en vez de poniendo la ruta, poner --> ofd.FileName
            imgLocal.Source = imagen;
        }
    }
}
