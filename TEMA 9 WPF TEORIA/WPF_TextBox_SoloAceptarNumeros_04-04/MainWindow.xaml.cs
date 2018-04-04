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

namespace WPF_TextBox_SoloAceptarNumeros_04_04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbxNumeros.Focus();
        }

        private void tbxNumeros_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !ValidarBinario(e.Key); // Si no introduces un número binario, e.Handled será false y cancelará la tecla 

        }
            
        
        // Devuelve true si la tecla está permitida (0 o 1)
        private bool ValidarBinario(Key tecla)
        {
            // Creo el array con los dígitos permitidos
            Key[] digitosPermitidos = { Key.D0, Key.D1, Key.NumPad0, Key.NumPad1 }; //Distingue si el número lo escribe en el teclado numérico (NumPad) o arriba

            return digitosPermitidos.Contains(tecla);
        }

    }
}
