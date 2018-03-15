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

namespace EntradaDatos_15_03
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBase.Focus(); //Como pongo que cuando tabule vaya a la altura?
            

        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double _base = 0;
            double _altura = 0;

            try
            {
                _base = double.Parse(txtBase.Text);
                _altura = double.Parse(txtAltura.Text); // .Text obtiene el cotenido de texto del cuadro de texto
                lblArea.Content = ((_altura * _base)/2).ToString();
            }
            catch
            {
                MessageBox.Show("Los datos de entrada no son válidos");
                txtBase.SelectAll(); //Selecciona el texto para que se borre al escribir
                txtBase.Focus(); //Toma el foco, esperando un dato

            }
        }
    }
}
