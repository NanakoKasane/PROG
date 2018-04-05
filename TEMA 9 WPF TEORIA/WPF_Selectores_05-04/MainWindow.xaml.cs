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

//---------------------------
using System.ComponentModel;

namespace WPF_Selectores_05_04
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

        private void btnOrdenar_Click(object sender, RoutedEventArgs e)
        {
            lbxLista.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Content", System.ComponentModel.ListSortDirection.Ascending)); 
            // Si quieres ordenar por otro criterio tendrás que borrar este de la colección de criterios de ordenación (Clear) o decirle que use el segundo criterio en la nueva

            lblTipoOrdenacion.Content = "Ordenado Ascendente";
        }

        private void cbxOrdenar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxLista.Items.SortDescriptions.Clear(); // Ya no hay ningún criterio de ordenación en la lista SortDescription

            if (cbxOrdenar.SelectedIndex == 0)
            {
                lbxLista.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Content", System.ComponentModel.ListSortDirection.Ascending));
                lblTipoOrdenacion.Content = "Ordenado Ascendente";
            }

            if (cbxOrdenar.SelectedIndex == 1)
            {
                lbxLista.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("Content", System.ComponentModel.ListSortDirection.Descending));
                lblTipoOrdenacion.Content = "Ordenado Descendente";
            }

        }
    }
}
