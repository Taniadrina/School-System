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
    /// Lógica de interacción para TableGroupsView.xaml
    /// </summary>
    public partial class TableGroupsView : System.Windows.Controls.UserControl
    {
        livexEntities context = new livexEntities();
        List<grupo> lstgroups = new List<grupo>();

        public TableGroupsView()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new NewGroup());
        }

        private void InitializeForm() {
            List<grupo> lstgroups = new List<grupo>();

            lstgroups = context.grupo.ToList();
            myDataGrid.ItemsSource = lstgroups;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new NewGroup( myDataGrid.SelectedItem));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
             MessageBoxResult result = MessageBox.Show("Seguro que desea eliminar el registro seleccionado?", "Delete", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Grupo.DeleteGroup(myDataGrid.SelectedItem);
                    myDataGrid.ItemsSource = null;
                    InitializeForm();
                    MessageBox.Show("Registro eliminado", "Delete");
                    break;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            List<grupo> g = new List<grupo>();
            TextBox word = (TextBox)sender;

            g = lstgroups.Where(x => x.nombre_nivel.ToUpper().Contains(word.Text.ToUpper()) || x.teacher.teacher_names.ToUpper().Contains(word.Text.ToUpper()) || x.Idioma.ToUpper().Contains(word.Text.ToUpper())).ToList();

            myDataGrid.ItemsSource = g;
        }
    }
}
