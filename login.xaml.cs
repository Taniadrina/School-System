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

namespace LIVEX
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void on_click_button(object sender, RoutedEventArgs e)
        {
            //Obtenemos los datos introducidos
            string nb_introducido = TextBox_Usuario.Text;
            string password_introducido = TextBox_Contraseña.Text;

            //Utilizamos el modelo de entidades
            livexEntities modeloEntities = new livexEntities();
            //livexDataSet modeloEntities = new livexDataSet();

            //VERIFICAMOS SI EL USUARIO EXISTE EN LA db

            user usuario = modeloEntities.user.SingleOrDefault(us => us.user_name.Equals(nb_introducido));

            if (usuario != null)
            {
                //Verificamos las contraseñas
                if (usuario.user_password.Equals(password_introducido))
                {
                    //MainWindow mainWindow = new MainWindow();
                    //mainWindow.Show();//Abre la nueva ventana
                    MainWindow v = new MainWindow(usuario.user_name);
                    v.Show();
                    this.Close();//Cierra la ventana actual

                }
                else
                {
                    //Las contraseñas no coinciden
                    if (usuario.user_name.Equals(nb_introducido))
                    {
                        TextBox_Usuario.Background = Brushes.White; //Cambiamos el color del textbox
                    }

                    TextBox_Contraseña.Background = Brushes.Red; //Cambiamos el color del textbox
                    TextBlock_MensajeError.Text = "La contraseña no es correcta"; //Establecemos el mensaje de error
                    TextBox_Contraseña.Clear(); //Borramos la contraseña introducida

                }
            }
            //El usuario no existe
            else
            {
                TextBox_Usuario.Background = Brushes.Red; //Cambiamos el color del Textbox
                TextBox_Usuario.Clear(); //Limiamos el valor introducido
                TextBox_Contraseña.Clear();
                TextBlock_MensajeError.Text = "El usuario introducido no es correcto";//establecemos el mensaje de error

            }
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show(); //muestra la nueva ventana
            //this.Close(); //cierra la ventana actual
        }

        private void cancel_click_button(object sender, RoutedEventArgs e)
        {
            this.Close(); //Cierra la ventana actual
        }
    }
}
