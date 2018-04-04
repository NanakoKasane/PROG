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

namespace WPF_TextBlock_04_04
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock tblTmp = new TextBlock();
            tblTmp.Inlines.Add("Texto sin formato");
            tblTmp.Inlines.Add(new LineBreak());

            // Personalizo un Run
            Run runTmp = new Run();
            runTmp.Foreground = new SolidColorBrush(Colors.Red);
            runTmp.Text = "Texto Run 1";
            runTmp.FontSize = 60;
            runTmp.FontFamily = new FontFamily("Arial");

            tblTmp.Inlines.Add(runTmp);

            // Lo añado al Grid para que ya se muestre 
            grdPanel.Children.Add(tblTmp);

        }

    }
}
