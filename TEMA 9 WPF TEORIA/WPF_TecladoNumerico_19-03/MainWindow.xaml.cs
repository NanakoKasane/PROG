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

namespace WPF_TecladoNumerico_19_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LlenarGridAlea();
        }

        private void LlenarGridAlea()
        {
            //Rellena el Grid de 3x3 con textBlock con números aleatorios.
            List<int> listaNumeros = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }); //Lista con números de 1 al 9.
            Random rnd = new Random();
            int posicion = 0;

            for (int i = 0; i < grdPanel.RowDefinitions.Count; i++) //Filas del Grid
            {
                for (int j = 0; j < grdPanel.ColumnDefinitions.Count; j++) //Columnas del Grid
                {
                    //Posición por la que vas de la lista. Es random.
                    posicion = rnd.Next(listaNumeros.Count); 

                    //TextBlock, le añado algunas propiedades al texto que mostará los números:
                    TextBlock tblTmp = new TextBlock();
                    tblTmp.FontFamily = new FontFamily("Arial"); //Le añades el tipo de letra
                    tblTmp.FontSize = 75;
                    tblTmp.VerticalAlignment = VerticalAlignment.Center;
                    tblTmp.HorizontalAlignment = HorizontalAlignment.Center;
                    tblTmp.Foreground = new SolidColorBrush(Colors.Violet); //Colors tiene una lista de colores
                    tblTmp.Background = new SolidColorBrush(Colors.Snow);
                    tblTmp.Height = 80;
                    tblTmp.Width = tblTmp.Height; //Para que sea cuadrado lo que ocupa.
                    tblTmp.TextAlignment = TextAlignment.Center;

                    //Le añado el número al TextBlock:
                    tblTmp.Text = listaNumeros[posicion].ToString();
                    listaNumeros.RemoveAt(posicion);

                    //Posiciono el TextBlock en la celda
                    Grid.SetRow(tblTmp, i);
                    Grid.SetColumn(tblTmp, j);

                    //Añado el TextBlock a la colección del GRID
                    grdPanel.Children.Add(tblTmp); //Para que se pinte hay que añadirlo a la propiedad Children (se añade a la colección del panel)

                } //Colección que contiene la rejilla --> Children
            }

        } 

    }
}
