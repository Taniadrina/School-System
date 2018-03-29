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
    /// Lógica de interacción para Alta_Baja_Maestros.xaml
    /// </summary>
    public partial class Alta_Baja_Maestros : System.Windows.Controls.UserControl
    {
        livexEntities context = new livexEntities();
        List<teacher> teacher_list = new List<teacher>();
        List<teacher_skillsView> skillsandteacher = new List<teacher_skillsView>();

        public Alta_Baja_Maestros()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            Vistas.add_View(Content, new AddTeacher());
        }

        private void LoadDataGrid()
        {
            teacher_list = context.teacher.ToList();
            foreach (teacher t in teacher_list)
            {
                teacher_skillsView ts = new teacher_skillsView();
                foreach (teacher_skills s in t.teacher_skills)
                {
                    if (s.skillID == 1)
                        ts.TOEFL = true;
                    if (s.skillID == 2)
                        ts.Exp = true;
                    if (s.skillID == 3)
                        ts.training = true;
                    if (s.skillID == 4)
                        ts.similar = true;

                }
                ts.ID = t.idteacher;
                ts.nombre = t.teacher_names;
                ts.apellido = t.teacher_lastname;
                ts.salario_base = t.salary_base;
                ts.idioma = t.language;
                ts.sexo = t.teacher_gender;
                ts.ID = t.idteacher;
                ts.RFC = t.RFC;
                ts.CURP = t.CURP;
                ts.AddressPhone = t.phone;
                ts.CelPhone = t.celphone;
                ts.Email = t.email;
                ts.Birdthday = t.birthday;
                ts.Address = t.street_address;
                ts.Neighbordhood = t.neighborhood;
                ts.ZipCode = t.zip_code;
                ts.State = t.state;
                ts.Substate = t.sub_state;
                ts.EmergencyName = t.emergency_contact_name;
                ts.EmergencyPhone = t.emergency_contact_number;
                ts.StartDate = t.start_date;
                ts.Picture = t.picture;
                ts.UID = t.uid;

                skillsandteacher.Add(ts);
            }

            myDataGrid.ItemsSource = skillsandteacher;
            //dgrdTeachers.ItemsSource = teacher_list;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new AddTeacher(1, myDataGrid.SelectedIndex, myDataGrid.SelectedItem));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result= MessageBox.Show("Seguro que desea eliminar el registro seleccionado?","Delete", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Teacher.DeleteTeacher(myDataGrid.SelectedItem);
                    myDataGrid.ItemsSource = null;
                    teacher_list = new List<teacher>();
                    skillsandteacher = new List<teacher_skillsView>(); 

                    LoadDataGrid();
                    MessageBox.Show("Registro eliminado", "Delete");

                    break;
            }

            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            List<teacher_skillsView> t = new List<teacher_skillsView>();
            TextBox word = (TextBox)sender;
            
            t = skillsandteacher.Where( x => x.nombre.ToUpper().Contains( word.Text.ToUpper() ) || x.apellido.ToUpper().Contains(word.Text.ToUpper()) || x.idioma.ToUpper().Contains(word.Text.ToUpper())).ToList();

            myDataGrid.ItemsSource = t;

        }
    }
}