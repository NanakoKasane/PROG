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

namespace WPF_Ej2_CalculaExpresionMatematica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtExpresion.Focus();
        }
    }

    public class Calcular 
    {
        //No tendrá en cuenta las prioridades de los operadores. Así que se harán de 2 en 2 las operaciones
        //Texto solo admite --> , para decimales. Números y las operaciones +, -, *, /


    }


}
