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
using Microsoft.Win32;

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para AsistenciaMaestros.xaml
    /// </summary>
    public partial class AsistenciaMaestros : System.Windows.Controls.UserControl
    {
        List<TeacherAttendanceView> lstTeacherAtt = new List<TeacherAttendanceView>();

        public AsistenciaMaestros()
        {
            InitializeComponent();
            TeacherAttendance.InitCombos(this);
            lstTeacherAtt = TeacherAttendance.initTable();
            myDataGrid.ItemsSource = lstTeacherAtt;
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            
            openFile.Title = "Seleccione el archivo";
            openFile.Filter = "csv(*.csv)|*.csv";
            if (openFile.ShowDialog() == true)
            {
               int result= TeacherAttendance.uploadTimerFile(openFile.FileName, openFile.SafeFileName);
               if(result == 1)
               {
                    lstTeacherAtt = TeacherAttendance.initTable();
                    myDataGrid.ItemsSource = lstTeacherAtt;
               }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            cmbUID.IsEnabled = true;
            cmbName.IsEnabled = true;
            //cmbTeacherNames.IsEnabled = true;
            cmbHour.IsEnabled = true;
            dpDate.IsEnabled = true;
            btnCheckBlue.IsEnabled = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button am = (Button)sender;
            TeacherAttendance.EditRow(this, am.DataContext);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button am = (Button)sender;
            MessageBoxResult result = MessageBox.Show("¿Esta seguro de borrar el registro?", "Delete", MessageBoxButton.YesNo);

            if (MessageBoxResult.Yes == result)
            {
                TeacherAttendance.DeleteRow(this, am.DataContext);

                if (dpFrom.Text == "" || dpUntil.Text == "")
                    myDataGrid.ItemsSource = TeacherAttendance.initTable();
                else if (dpFrom.Text != "" || dpUntil.Text != "")
                    myDataGrid.ItemsSource = TeacherAttendance.FilterTable(Convert.ToDateTime(dpFrom.Text), Convert.ToDateTime(dpUntil.Text));
            }
        }

        private void dpFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpUntil.SelectedDate < dpFrom.SelectedDate)
                MessageBox.Show("La Fecha de inicio debe ser menor a la fecha final");
            else
            {
                if (dpUntil.SelectedDate == null)
                    dpUntil.SelectedDate = DateTime.Today;
                lstTeacherAtt = TeacherAttendance.FilterTable((DateTime)dpFrom.SelectedDate, (DateTime)dpUntil.SelectedDate);
                myDataGrid.ItemsSource = lstTeacherAtt;
            }
        }

        private void dpUntil_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpUntil.SelectedDate < dpFrom.SelectedDate)
                MessageBox.Show("La Fecha de inicio debe ser menor a la fecha final");
            else
            {
                if (dpFrom.Text != "" && dpUntil.Text != "")
                {
                    lstTeacherAtt = TeacherAttendance.FilterTable((DateTime)dpFrom.SelectedDate, (DateTime)dpUntil.SelectedDate);
                    myDataGrid.ItemsSource = lstTeacherAtt;
                }
               
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox word = (TextBox)sender;
            
            List<TeacherAttendanceView> lstResult = new List<TeacherAttendanceView>();

           

            lstResult = lstTeacherAtt.Where(x => x.UID.ToUpper().Contains(word.Text.ToUpper()) || x.Name.ToUpper().Contains(word.Text.ToUpper()) ||
                                                 x.TeacherName.ToUpper().Contains(word.Text.ToUpper()) || x.Date.ToUpper().Contains(word.Text.ToUpper())
            ).ToList();

            myDataGrid.ItemsSource = lstResult;

        }

        private void btnCheckBlue_Click(object sender, RoutedEventArgs e)
        {
            bool isValid= TeacherAttendance.validateAddRow(this);

            if (isValid)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri("pack://application:,,,/LIVEX;component/Images/001-checked-1.png");
                b.EndInit();
                imgCheck.Stretch = Stretch.Uniform;
                imgCheck.Source = b;

                TeacherAttendance.AddAttendaceRow(this);

                if(dpFrom.Text == "" || dpUntil.Text == "")
                    myDataGrid.ItemsSource = TeacherAttendance.initTable();
                else if (dpFrom.Text != "" || dpUntil.Text != "")
                    myDataGrid.ItemsSource = TeacherAttendance.FilterTable(Convert.ToDateTime(dpFrom.Text), Convert.ToDateTime(dpUntil.Text));

                TeacherAttendance.ResetRowCombos(this);
            }
        }

        private void cmbUID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeacherAttendance.refreshCombos(this);
        }

        private void btnCheckBlueEdit_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = TeacherAttendance.validateAddRow(this);

            if (isValid)
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri("pack://application:,,,/LIVEX;component/Images/001-checked-1.png");
                b.EndInit();
                imgCheck.Stretch = Stretch.Uniform;
                imgCheck.Source = b;

                TeacherAttendance.EditSelected(this);

                if (dpFrom.Text == "" || dpUntil.Text == "")
                    myDataGrid.ItemsSource = TeacherAttendance.initTable();
                else if (dpFrom.Text != "" || dpUntil.Text != "")
                    myDataGrid.ItemsSource = TeacherAttendance.FilterTable(Convert.ToDateTime(dpFrom.Text), Convert.ToDateTime(dpUntil.Text));

                TeacherAttendance.ResetRowCombos(this);
            }
        }
    }
}
