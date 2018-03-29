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
    /// Lógica de interacción para GruposView.xaml
    /// </summary>
    public partial class GruposView : System.Windows.Controls.UserControl
    {
        public GruposView()
        {
            InitializeComponent();
        }

        private void btnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content,new TableGroupsView());
        }
    }
}
