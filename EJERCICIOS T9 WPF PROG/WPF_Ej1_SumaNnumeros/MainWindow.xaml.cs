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

namespace WPF_Ej1_SumaNnumeros
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtN.Focus();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nNumero = int.Parse(txtN.Text);
                int resultado = 0;
                for (int i = 1; i <= nNumero; i++)
                {
                    resultado += i;
                }
                lblResultado.Content = resultado;
            }
            catch
            {
                //Controlar que sea un número lo que introduzcas (Si entra aquí es que el int.Parse ha fallado).
                MessageBox.Show("El formato no es correcto");
                txtN.Focus();
                txtN.SelectAll();
            }
  
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close(); //Cierra la ventana
        }
    }
}
