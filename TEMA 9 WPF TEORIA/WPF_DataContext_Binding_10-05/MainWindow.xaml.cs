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

namespace WPF_Personas_Binding_10_05
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

        private void btn_cambiar_Click(object sender, RoutedEventArgs e)
        {
            // grdPrincipal.DataContext = "Broadway";

            lbl_Texto.Content = "Broadway"; // Tiene prioridad al contexto de datos. Ahora el contexto de datos es Content
            // Se aplica por prioridad -> Tiene más prioridad el más cercano al elemento. Si no lo encuentra ahí ya va buscando en sus padres (en este caso, buscaría en el DataContext)
       
        }
    }
}
