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

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para TableTeacherGroup.xaml
    /// </summary>
    public partial class TableTeacherGroup : System.Windows.Controls.UserControl
    {
        public TableTeacherGroup()
        {
            InitializeComponent();
            TeacherForm.InitializeForm1(this);
            
        }

        private void btnVerNomina_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new NominaMaestros(this));
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content,new MaestrosView());
        }

        private void cmbTeacherNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherForm.ButtonSee(this);
        }

        private void cmbCiclo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherForm.ButtonSee(this);
        }
    }
}
