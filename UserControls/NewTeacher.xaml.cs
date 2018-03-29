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
using System.Windows.Shapes;
using LIVEX.Class;
using LIVEX.UserControls;


namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para NewTeacher.xaml
    /// </summary>
    public partial class NewTeacher : Window
    {
        livexEntities context = new livexEntities();
        Alta_Baja_Maestros t_uc = new Alta_Baja_Maestros();
        public List<skills> skillsName = new List<skills>();
        public List<language> languageName = new List<language>();
        int[] skills_Values = new int[4]; //1.-TOEFL 2.-Experiencia 3.-Training 4.-Similar
        int idioma = 0;//0=Inglés 1=Francés

        public NewTeacher()
        {
            InitializeComponent();
            initializeForm();
        }

        private void btnMinTeacher_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaxteacher_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                grd_AnaGridWindow.Margin = new Thickness(0, 0, 0, 0);
            }
            else
            {
                this.WindowState = WindowState.Normal;
                grd_AnaGridWindow.Margin = new Thickness(15);
            }

        }

        private void btnCloseTeacher_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void brd_Teacher_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        public void initializeForm() {

            skillsName = context.skills.ToList();
            lstSkills.ItemsSource= skillsName;

            //inicializacion de los checkboxes de idiomas;
            languageName = context.language.ToList();
            //lstLanguage.ItemsSource = languageName;

        }

        private void chkSkill_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
          
                switch (checkBox.Content)
                {
                    case "550 TOEFL":
                        skills_Values[0] = 1;
                        break;
                    case "Experiencia":
                        skills_Values[1] = 1;
                        break;
                    case "Teacher Training":
                        skills_Values[2] = 1;
                        break;
                    case "LIDILE o similar":
                        skills_Values[3] = 1;
                        break;

                }
            if (rbtnIngles.IsChecked == true)
                idioma = 0;
            else
                idioma = 1;
            
            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values,idioma).ToString();
        }

        private void chkSkill_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            switch (checkBox.Content)
            {
                case "550 TOEFL":
                    skills_Values[0] = 0;
                    break;
                case "Experiencia":
                    skills_Values[1] = 0;
                    break;
                case "Teacher Training":
                    skills_Values[2] = 0;
                    break;
                case "LIDILE o similar":
                    skills_Values[3] = 0;
                    break;

            }
            if (rbtnIngles.IsChecked == true)
                idioma = 0;
            else
                idioma = 1;

            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values,idioma).ToString();
        }

        private void rbtnIngles_Checked(object sender, RoutedEventArgs e)
        {
            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, 0).ToString();
        }

        private void rbtnFrances_Checked(object sender, RoutedEventArgs e)
        {
            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, 1).ToString();
        }

        private void btnSaveNewTeacher_Click(object sender, RoutedEventArgs e)
        {

            //int result = Teacher.SaveTeacher(this, skills_Values);
            //if (result == 0)
            //{
            //    MessageBox.Show("El registro se ha guardado");
            //    CleanControls();    
               
            //}
                
        }

        /// <summary>
        /// Cleans the controls after a save is set succesfully
        /// </summary>
        private void CleanControls()
        {
            this.txtNewTeacherName.Text = "";
            this.txtNewTeacherApellidos.Text = "";
            this.txtSalarioBase.Text = "";
            initializeForm();
        }
    }

}
