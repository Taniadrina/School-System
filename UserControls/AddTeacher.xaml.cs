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
using System.IO;

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : System.Windows.Controls.UserControl
    {
        livexEntities context = new livexEntities();

        public List<skills> skillsName = new List<skills>();
        public List<language> languageName = new List<language>();
        int[] skills_Values = new int[4]; //1.-TOEFL 2.-Experiencia 3.-Training 4.-Similar
        int idioma = 0;//0=Inglés 1=Francés
        int teacherID = 0;

        public AddTeacher()
        {
            InitializeComponent();
            initializeForm();
            txtMaestroHeader.Text = "Nuevo " + txtMaestroHeader.Text;
        }

        public AddTeacher(int edit, int rowindex, object row)
        {
            InitializeComponent();
            initializeFormtoEdit((teacher_skillsView)row);
        }

        //private void btnMinTeacher_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        //private void btnMaxteacher_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Normal)
        //    {
        //        this.WindowState = WindowState.Maximized;
        //        grd_AnaGridWindow.Margin = new Thickness(0, 0, 0, 0);
        //    }
        //    else
        //    {
        //        this.WindowState = WindowState.Normal;
        //        grd_AnaGridWindow.Margin = new Thickness(15);
        //    }

        //}

        //private void btnCloseTeacher_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void brd_Teacher_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (Mouse.LeftButton == MouseButtonState.Pressed)
        //        this.DragMove();
        //}

        public void initializeForm()
        {

            skillsName = context.skills.ToList();
            //lstSkills.ItemsSource = skillsName;

            //inicializacion de los checkboxes de idiomas;
            //languageName = context.language.ToList();
            //lstLanguage.ItemsSource = languageName;

        }

        private void chkSkill_Checked(object sender, RoutedEventArgs e)
        {
            string s="";
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Content.GetType() == s.GetType())
            {
                switch (checkBox.Content)
                {
                    case "550 TOEFL":
                        skills_Values[0] = 1;
                        break;
                    case "Experiencia":
                        skills_Values[1] = 1;
                        break;
                }
            }
            else
            {
                TextBlock textBox = (TextBlock)checkBox.Content;
                switch (textBox.Text)
                {
                    case "Teacher Training":
                        skills_Values[2] = 1;
                        break;
                    case "LIDILE o similar":
                        skills_Values[3] = 1;
                        break;

                }
            }
            if (rbtnIngles.IsChecked == true)
                idioma = 0;
            else
                idioma = 1;

            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, idioma).ToString();
        }

        private void chkSkill_Unchecked(object sender, RoutedEventArgs e)
        {
            string s = "";
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Content.GetType() == s.GetType())
            {
                switch (checkBox.Content)
                {
                    case "550 TOEFL":
                        skills_Values[0] = 0;
                        break;
                    case "Experiencia":
                        skills_Values[1] = 0;
                        break;
                }
            }
            else {
                TextBlock textBox = (TextBlock)checkBox.Content;
                switch (textBox.Text)
                {
                    case "Teacher Training":
                        skills_Values[2] = 0;
                        break;
                    case "LIDILE o similar":
                        skills_Values[3] = 0;
                        break;
                }

            }
            if (rbtnIngles.IsChecked == true)
                idioma = 0;
            else
                idioma = 1;

            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, idioma).ToString();
        }

        private void rbtnIngles_Checked(object sender, RoutedEventArgs e)
        {
            
            if(txtSalarioBase!=null)
                txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, 0).ToString();
        }

        private void rbtnFrances_Checked(object sender, RoutedEventArgs e)
        {
            txtSalarioBase.Text = Tabulador.CalcularSalarioBase(skills_Values, 1).ToString();
        }

        private void btnSaveNewTeacher_Click(object sender, RoutedEventArgs e)
        {

            int result = Teacher.SaveTeacher(this, skills_Values);
            if (result == 0)
            {
                MessageBox.Show("El registro se ha guardado");
                CleanControls();

            }

        }

        /// <summary>
        /// Cleans the controls after a save is set succesfully
        /// </summary>
        private void CleanControls()
        {
            this.txtNewTeacherName.Text = "";
            this.txtNewTeacherApellidos.Text = "";
            this.txtSalarioBase.Text = "";
            this.chkTOEFL.IsChecked = false;
            this.chkExp.IsChecked = false;
            this.chkTraining.IsChecked = false;
            this.chkSimilar.IsChecked = false;
            this.rbtnIngles.IsChecked = true;
            this.txtSalarioBase.Text = "0";
            this.txtIDTeacher.Text = "";
            this.txtTeacherRFC.Text = "";
            this.txtTeacherCURP.Text = "";
            this.txtAddressPhone.Text = "";
            this.txtCelPhone.Text = "";
            this.txtEmail.Text = "";
            this.dpBirthday.Text = "";
            this.txtAddress.Text = "";
            this.txtNeighbordhood.Text = "";
            this.txtZipCode.Text = "";
            this.txtState.Text = "";
            this.txtSubState.Text = "";
            this.txtEmergencyName.Text = "";
            this.txtEmergencyPhone.Text = "";
            this.dpStartDate.Text = DateTime.Now.ToString();
            this.imgTeacher.ImageSource = null;
            

        }

        private void btnCloseAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new Alta_Baja_Maestros());
        }

        private void initializeFormtoEdit(teacher_skillsView rowdata)
        {
            BitmapImage b = new BitmapImage();

            txtMaestroHeader.Text = "Editar " + txtMaestroHeader.Text;
            txtIDTeacher.Text = rowdata.ID.ToString();
            txtNewTeacherName.Text = rowdata.nombre;
            txtNewTeacherApellidos.Text = rowdata.apellido;
            txtTeacherRFC.Text = rowdata.RFC;
            txtTeacherCURP.Text = rowdata.CURP;
            txtAddressPhone.Text = rowdata.AddressPhone;
            txtCelPhone.Text = rowdata.CelPhone;
            txtEmail.Text = rowdata.Email;
            dpBirthday.Text = rowdata.Birdthday;
            txtAddress.Text = rowdata.Address;
            txtNeighbordhood.Text = rowdata.Neighbordhood;
            txtZipCode.Text = rowdata.ZipCode;
            txtState.Text = rowdata.State;
            txtSubState.Text = rowdata.Substate;
            txtEmergencyName.Text = rowdata.EmergencyName;
            txtEmergencyPhone.Text = rowdata.EmergencyPhone;
            dpStartDate.Text = rowdata.StartDate;
            txtUID.Text = rowdata.UID;
            if (rowdata.Picture != null && rowdata.Picture != "")
            {
                b.BeginInit();
                b.UriSource = new Uri(rowdata.Picture);
                b.EndInit();
                imgTeacher.ImageSource = b;
            }
            

            if (rowdata.sexo == "F")
                rbtnTeacherFemenio.IsChecked = true;
            else
                rbtnTeacherMasculino.IsChecked = true;

            if (rowdata.TOEFL)
                chkTOEFL.IsChecked = true;
            else
                chkTOEFL.IsChecked = false;

            if (rowdata.Exp)
                chkExp.IsChecked = true;
            else
                chkExp.IsChecked = false;

            if (rowdata.training)
                chkTraining.IsChecked = true;
            else
                chkTraining.IsChecked = false;

            if (rowdata.similar)
                chkSimilar.IsChecked = true;
            else
                chkSimilar.IsChecked = false;

            if (rowdata.idioma == "Ingles")
                rbtnIngles.IsChecked = true;
            else
                rbtnFrances.IsChecked = true;

            teacherID = rowdata.ID;

            txtSalarioBase.Text = rowdata.salario_base.ToString();
            btnSaveNewTeacher.Visibility = Visibility.Collapsed;
            btnSaveEditTeacher.Visibility = Visibility.Visible;

        }

        private void btnSaveEditTeacher_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            result =Teacher.SaveEditTeacher(this, teacherID);

            if (result >= 0)
            {
                MessageBox.Show("El registro se ha guardado");
                Vistas.add_View(Content, new Alta_Baja_Maestros());
            }
            else
                MessageBox.Show("WARNING!! El registro NO se ha guardado");

        }

        private void btnAddPicture_Click(object sender, RoutedEventArgs e)
        {
           
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                openFile.Title = "Seleccione la Imagen a Mostrar";
                openFile.Filter = "jpg(*.jpg)|*.jpg|png(*.png)|*.png|gif(*.gif)|*.gif|bmp(*.bmp)|*.bmp|All Files(*.*)|*.*";
                if (openFile.ShowDialog() == true)
                {
                    if (new FileInfo(openFile.FileName).Length > 131072)
                    {
                        MessageBox.Show(
                    "El tamaño máximo permitido de la imagen es de 128 KB",
                            "Mensaje de Sistema",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning,
                        MessageBoxResult.OK);
                        return;
                    }

                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgTeacher.Stretch = Stretch.Uniform;
                    imgTeacher.ImageSource = b;

                    btnAddPicture.Content = "Quitar Foto";
                }
            
           
        }
    }
}
