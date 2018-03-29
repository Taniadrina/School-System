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
    /// Lógica de interacción para calendar.xaml
    /// </summary>
    public partial class calendar : UserControl
    {
        public calendar()
        {
            InitializeComponent();
            Calendarx.setMonth(1,2018, ucTCalendar);
        }
    }
}
