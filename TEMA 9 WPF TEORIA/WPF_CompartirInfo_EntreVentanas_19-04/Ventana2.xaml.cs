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
using System.Windows.Shapes;

namespace WPF_CompartirInfo_EntreVentanas_19_04
{
    // Creo un delegado
    public delegate void dlgEnviar(string[] datos);


    /// <summary>
    /// Lógica de interacción para Ventana2.xaml
    /// </summary>
    public partial class Ventana2 : Window
    {
        // Creo un evento basado en el delegado
        public event dlgEnviar OnEnviar;

        public Ventana2()
        {
            InitializeComponent();
            tbxDato1.Focus();
        }

        private void btnEnviarDatos_Click(object sender, RoutedEventArgs e)
        {
            string[] datos = { tbxDato1.Text, tbxDato2.Text };

            if (OnEnviar != null)
            {
                OnEnviar(datos);
            }
        }
    }
}
