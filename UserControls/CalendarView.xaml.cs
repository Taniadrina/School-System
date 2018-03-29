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
    /// Lógica de interacción para CalendarView.xaml
    /// </summary>
    public partial class CalendarView : System.Windows.Controls.UserControl
    {

        public CalendarView()
        {
            InitializeComponent();
            Cycle.InitilizeCalendars(this);
            Cycle.setDatesSaved(this);
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AjustesView());
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVacaciones_Click(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(null);
            btnVacaciones.BorderBrush = Brushes.Black;
            btnVacaciones.BorderThickness = new Thickness(1,1,1,1);
            Grid.SetZIndex(grdVacations, 94);
            Grid.SetZIndex(grdStartCycle, 91);
            Grid.SetZIndex(grdEndCycle, 92);
            Cycle.EnableCalendars(this,1);
            btnCicloInicio.BorderThickness = new Thickness(0);
            btnCicloFin.BorderThickness = new Thickness(0);
            btnClean.BorderThickness = new Thickness(0);
        }

        private void btnCicloInicio_Click(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(null);
            btnCicloInicio.BorderBrush = Brushes.DarkBlue;
            btnCicloInicio.BorderThickness = new Thickness(1);
            Grid.SetZIndex(grdVacations, 90);
            Grid.SetZIndex(grdStartCycle, 94);
            Grid.SetZIndex(grdEndCycle, 92);
            Cycle.EnableCalendars(this, 2);
            btnVacaciones.BorderThickness = new Thickness(0);
            btnCicloFin.BorderThickness = new Thickness(0);
            btnClean.BorderThickness = new Thickness(0);
        }

        private void btnCicloFin_Click(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(null);
            btnCicloFin.BorderBrush = Brushes.DarkBlue;
            btnCicloFin.BorderThickness = new Thickness(1);
            Grid.SetZIndex(grdVacations, 90);
            Grid.SetZIndex(grdStartCycle, 91);
            Grid.SetZIndex(grdEndCycle, 94);
            Cycle.EnableCalendars(this, 3);
            btnVacaciones.BorderThickness = new Thickness(0);
            btnCicloInicio.BorderThickness = new Thickness(0);
            btnClean.BorderThickness = new Thickness(0);
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            Mouse.Capture(null);
            Cycle.CleanCalendars(this);
            btnClean.BorderBrush = Brushes.DarkBlue;
            btnClean.BorderThickness = new Thickness(1);
            btnVacaciones.BorderThickness = new Thickness(0);
            btnCicloInicio.BorderThickness = new Thickness(0);
            btnCicloFin.BorderThickness = new Thickness(0);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Cycle.EnableCalendars(this,0);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Cycle.SaveCycles(this);
            btnCicloInicio.BorderThickness = new Thickness(0);
            btnCicloFin.BorderThickness = new Thickness(0);
            btnVacaciones.BorderThickness = new Thickness(0);
            btnClean.BorderThickness = new Thickness(0);
        }

        private void cVac_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);
            
            
        }

        private void cSC_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);
            Calendar calendar = (Calendar)sender;
            if (calendar.SelectedDate != null && calendar.Name == "cJanSC" && btnEdit.IsEnabled == false)
            {
                Cycle.CleanCycleCalendars(this);
                Cycle.SetEndCicles(this, (DateTime)calendar.SelectedDate);
            }

        }

        private void cEC_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);


        }
    }
}
