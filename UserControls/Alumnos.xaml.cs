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
using LIVEX.Class;
using LIVEX.UserControls;

namespace LIVEX.UserControl
{
    /// <summary>
    /// Lógica de interacción para AlumnosNuevo.xaml
    /// </summary>
    public partial class Alumnos : System.Windows.Controls.UserControl
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new TableStudents());
        }

        private void btnStudentAttendance_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void btnStudentsPayment_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new StudentPayment());
        }

        private void btnProspectClients_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
