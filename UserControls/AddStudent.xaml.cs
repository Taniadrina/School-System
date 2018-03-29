using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using LIVEX.Class;

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para AddStudent.xaml
    /// </summary>
    public partial class AddStudent : System.Windows.Controls.UserControl
    {
        public AddStudent()
        {
            InitializeComponent();
            Student.initForm(this);
        }

        public AddStudent(object row)
        {
            InitializeComponent();
            Student.initFormtoEdit(this,row);
        }

        private void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            BitmapImage b = new BitmapImage();
            openFile.Title = "Seleccione la Imagen a Mostrar";
            openFile.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png|gif(*.gif)|*.gif|bmp(*.bmp)|*.bmp|All Files(*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                if (new FileInfo(openFile.FileName).Length > 131072)
                {
                    MessageBox.Show(
                "El tamaño máximo permitido de la imagen es de 128 KB",
                        "Mensaje de Sistema",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning,
                    MessageBoxResult.OK);
                    return;
                }

                b.BeginInit();
                b.UriSource = new Uri(openFile.FileName);
                b.EndInit();
                imgStudent.Stretch = Stretch.Uniform;
                imgStudent.ImageSource = b;

                btnAddPicture.Content = "Quitar Foto";
            }
        }

        private void btnSaveNewStudent_Click(object sender, RoutedEventArgs e)
        {
           int result = Student.saveStudent(this);
            if (result > 0)
            {
                MessageBox.Show("Registro guardado con exito");
                Student.cleanControls(this);
            }
            else
                MessageBox.Show("WARNING!! El registro NO se ha guardado");

        }

        private void btnSaveEditStudent_Click(object sender, RoutedEventArgs e)
        {
            int result = Student.saveEditStudent(this);
            if (result > 0)
            {
                MessageBox.Show("Registro guardado con exito");
                Student.cleanControls(this);
            }
            else
                MessageBox.Show("WARNING!! El registro NO se ha guardado");
        }

        private void btnSalirNewStudent_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new TableStudents());
        }

        private void chkInvoicing_Checked(object sender, RoutedEventArgs e)
        {
            if (chkInvoicing.IsChecked == true)
                grdInvoicingData.Visibility = Visibility.Visible;
            else
                grdInvoicingData.Visibility = Visibility.Hidden;
        }

        private void cmbCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            switch (cmb.SelectedValue)
            {
                case "Regular":
                case "KIDS":
                case "1:1":
                case "Empresarial":
                    cmbNivel12.IsEnabled = true;
                    cmbNivel12.Visibility = Visibility.Visible;
                    cmbNivel4.Visibility = Visibility.Collapsed;
                    break;
                case "Avanzado":
                case "TOEFL":
                    cmbNivel4.IsEnabled = true;
                    cmbNivel4.Visibility = Visibility.Visible;
                    cmbNivel12.Visibility = Visibility.Collapsed;
                    break;
            }

            switch (cmb.SelectedValue)
            {
                case "1:1":
                case "Empresarial":
                case "KIDS":
                    cmbTipo2.IsEnabled = true;
                    cmbTipo2.Visibility = Visibility.Visible;
                    cmbTipo.Visibility = Visibility.Collapsed;
                    break;
                case "TOEFL":
                case "Avanzado":
                case "Regular":
                    cmbTipo.IsEnabled = true;
                    cmbTipo.Visibility = Visibility.Visible;
                    cmbTipo2.Visibility = Visibility.Collapsed;
                    break;
            }

        }

    }
}
