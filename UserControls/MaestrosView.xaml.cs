using LIVEX.Class;
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

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para MaestrosView.xaml
    /// </summary>
    public partial class MaestrosView : System.Windows.Controls.UserControl
    {
        public MaestrosView()
        {
            InitializeComponent();
        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new Alta_Baja_Maestros());
        }

        private void btnAsistencia_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AsistenciaMaestros());
        }

        private void btnNomina_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new TableTeacherGroup());
        }
    }
}
