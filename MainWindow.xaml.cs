using LIVEX.Class;
using LIVEX.UserControl;
using LIVEX.UserControls;
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

namespace LIVEX
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string user_name;

        public MainWindow()
        {
            InitializeComponent();
           
            lblFechaHeader.Content = lblFechaHeader.Content + DateTime.Today.ToLongDateString();

        }

        public MainWindow(string user_name)
        {
            InitializeComponent();
            this.user_name = user_name;
            lblBienvenida.Content = lblBienvenida.Content +" "+ user_name;
            lblFechaHeader.Content = lblFechaHeader.Content + DateTime.Today.ToLongDateString();

        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brd_S_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximizae_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grd_AnaGridWindow.Margin = new Thickness(0,0,0,0);
            }
            else {
                this.WindowState = WindowState.Normal;
                grd_AnaGridWindow.Margin = new Thickness(15);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new MainView());
        }

        private void btnLogo_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new MainView());
        }

        private void menuBtn_Alumnos_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new Alumnos());
        }

        private void menuBtn_Maestros_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new MaestrosView());
        }

        private void menuBtn_Grupos_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new GruposView());
        }

        private void menuBtn_Ganancias_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new GananciasView());
        }

        private void menuBtn_Ajustes_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AjustesView());
        }
    }
}
