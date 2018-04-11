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

namespace WPF_Ejercicio10_Calculadora
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

			tbxExpresion.Focus();
			tbxExpresion.SelectAll();
        }

		private void btn7_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 7.ToString();
		}

		private void btn8_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 8.ToString();
		}

		private void btn9_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 9.ToString();
		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 4.ToString();

		}

		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 5.ToString();

		}

		private void btn6_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 6.ToString();

		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 1.ToString();

		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 2.ToString();

		}

		private void btn3_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 3.ToString();

		}

		private void btn0_Click(object sender, RoutedEventArgs e)
		{
			tbxExpresion.Text += 0.ToString();

		}


    }
}
