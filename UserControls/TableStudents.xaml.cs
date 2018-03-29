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
using LIVEX.UserControl;
using LIVEX.Class;

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para TableStudents.xaml
    /// </summary>
    public partial class TableStudents : System.Windows.Controls.UserControl
    {
        livexEntities context = new livexEntities();

        public TableStudents()
        {
            InitializeComponent();
            initGrid();
        }

        private void initGrid()
        {
            List<alumno> lstStudents = new List<alumno>();

            lstStudents = context.alumno.ToList();
            myDataGrid.ItemsSource = lstStudents;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AddStudent());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new Alumnos());
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            List<alumno> a = new List<alumno>();
            List<alumno> lstStudents = context.alumno.ToList();
            TextBox word = (TextBox)sender;

            a = lstStudents.Where(x => x.alumno_nombre.ToUpper().Contains(word.Text.ToUpper()) || x.alumno_apellido_p.ToUpper().Contains(word.Text.ToUpper()) || x.alumno_apellido_m.ToUpper().Contains(word.Text.ToUpper())).ToList();

            myDataGrid.ItemsSource = a;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AddStudent(myDataGrid.SelectedItem));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Seguro que desea eliminar el registro seleccionado?", "Delete", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    List<alumno> lstSudents = Student.DeleteTeacher(myDataGrid.SelectedItem);
                    myDataGrid.ItemsSource = null;

                    myDataGrid.ItemsSource = lstSudents;
                    MessageBox.Show("Registro eliminado", "Delete");

                    break;
            }
        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new StudentPayment());
        }
    }
}
