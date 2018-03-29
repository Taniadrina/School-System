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
using System.Globalization;

namespace LIVEX.UserControls
{
    /// <summary>
    /// Lógica de interacción para NewGroup.xaml
    /// </summary>
    public partial class NewGroup : System.Windows.Controls.UserControl
    {
        livexEntities context = new livexEntities();
        grupo gGlobal = new grupo();
        int datagroupID;

        public NewGroup()
        {
            InitializeComponent();
            initializeForm();
            txtTitleGrupo.Text = "Nuevo " + txtTitleGrupo.Text; 
        }

        public NewGroup(object row)
        {
            InitializeComponent();
            initializeForm();
            initializeFormToEdit((grupo)row);

        }

        private void initializeForm()
        {
            categoria c = new categoria();
            List<string> catList = new List<string>();
            
            catList = context.categoria.Select(x =>  x.categoria_nombre ).Distinct().ToList();
            cmbCategoria.ItemsSource = catList;

           
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           bool isValid = Grupo.ValidateFields(this);
            if (isValid)
            {
                int result = Grupo.SaveGroup(this);
                if (result > 0)
                {
                    MessageBox.Show("El registro se ha guardado");
                    CleanControls();

                }
            }
        }

        private void CleanControls()
        {
            cmbCategoria.Text = "";
            cmbNivel12.Text = "";
            cmbNivel4.Text = "";
            cmbTipo.Text = "";
            cmbTipo2.Text = "";
            cmbHrInicio.Text = "";
            cmbHrFin.Text = "";
            lstDias.UnselectAll();
            chkingles.IsChecked = true;
            cmbTeacher.Text = "";
            cmbCiclo.Text = "";
            dtpFechaFin.Text = "";
            dtpFechaInicio.Text = "";
            txtCantAlumnos.Text = "";


        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Content, new TableGroupsView());
        }

        private void cmbCategoria_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;

            switch (cmb.SelectedValue)
            {
                case "Regular":
                case "KIDS":
                case "1:1":
                case "Empresarial":
                    cmbNivel12.IsEnabled = true;
                    cmbNivel12.Visibility = Visibility.Visible;
                    cmbNivel4.Visibility = Visibility.Collapsed;
                    break;
                case "Avanzado":
                case "TOEFL":
                    cmbNivel4.IsEnabled = true;
                    cmbNivel4.Visibility = Visibility.Visible;
                    cmbNivel12.Visibility = Visibility.Collapsed;
                    break;
            }

            switch (cmb.SelectedValue)
            {
                case "1:1":
                case "Empresarial":
                case "KIDS":
                    cmbTipo2.IsEnabled = true;
                    cmbTipo2.Visibility = Visibility.Visible;
                    cmbTipo.Visibility = Visibility.Collapsed;
                    break;
                case "TOEFL":
                case "Avanzado":
                case "Regular":
                    cmbTipo.IsEnabled = true;
                    cmbTipo.Visibility = Visibility.Visible;
                    cmbTipo2.Visibility = Visibility.Collapsed;
                    break;
            }

            switch (cmb.SelectedValue)
            {
                case "1:1":
                case "Empresarial":
                    cmbCiclo.Visibility = Visibility.Visible;
                    dtpFechaInicio.Visibility = Visibility.Visible;
                    dtpFechaFin.Visibility = Visibility.Visible;

                    cmbCicloEscolar.Visibility = Visibility.Collapsed;
                    dtpFechaInicioEscolar.Visibility = Visibility.Collapsed;
                    dtpFechaFinEscolar.Visibility = Visibility.Collapsed;
                    break;

                case "Regular":
                case "KIDS":
                case "Avanzado":
                case "TOEFL":
                    cmbCicloEscolar.Visibility = Visibility.Visible;
                    dtpFechaInicioEscolar.Visibility = Visibility.Visible;
                    dtpFechaFinEscolar.Visibility = Visibility.Visible;

                    cmbCiclo.Visibility = Visibility.Collapsed;
                    dtpFechaInicio.Visibility = Visibility.Collapsed;
                    dtpFechaFin.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void cmbHrInicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            int index = c.SelectedIndex+1;
            cmbHrFin.IsEnabled = true;
            if (index == 24)
                index = 0;
            cmbHrFin.SelectedIndex = index;

            comboTeacherCheck();
        }

        private void lstDias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboTeacherCheck();
        }

        private void cmbHrFin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboTeacherCheck();
        }

        private void comboTeacherCheck() {
            
            if (lstDias.SelectedItems.Count > 0 && cmbHrInicio.SelectedIndex > -1)
            {
                cmbTeacher.IsEnabled = true;
                LoadComboTeacher();
            }
            else
                cmbTeacher.IsEnabled = false;
        }

        private void LoadComboTeacher()
        {
            teacher t = new teacher();
            List<grupo> lstTeacher = new List<grupo>();

            lstTeacher = context.grupo.ToList();
            List<teacher> teacher = context.teacher.ToList();
            List<teacher> teacherno = new List<teacher>();
            DateTime Hora_inicio;
            DateTime Hrinicio = new DateTime();
            DateTime HrFin = new DateTime();
            DateTime Hora_fin;

            foreach (grupo s in lstTeacher)
            {
                Hora_inicio = DateTime.ParseExact(s.Horario_inicio, "HH:mm", CultureInfo.InvariantCulture);
                Hrinicio = DateTime.ParseExact(this.cmbHrInicio.SelectedValue.ToString(), "HH:mm", CultureInfo.InvariantCulture);
                Hora_fin = DateTime.ParseExact(s.Horario_fin, "HH:mm", CultureInfo.InvariantCulture);
                HrFin = DateTime.ParseExact(this.cmbHrFin.SelectedValue.ToString(), "HH:mm", CultureInfo.InvariantCulture);
            
                string[] day;
                day = s.Dias.Split(' ');

                if ((Hora_inicio >= Hrinicio && Hora_inicio <= HrFin && Hora_fin >= Hrinicio && Hora_fin <= HrFin )||
                    (Hora_inicio < Hrinicio && Hora_fin > Hrinicio) ||
                    (Hora_inicio < HrFin && Hora_fin > HrFin))
                {
                    foreach (ListBoxItem i in this.lstDias.SelectedItems)
                    {
                        if(day.Contains(i.Content.ToString()))
                            teacherno.Add(s.teacher);
                        else
                            teacher.Add(s.teacher);
                    }
                }      
                
                else
                    teacher.Add(s.teacher);
            }

            foreach(teacher tn in teacherno)
            {
                if (teacher.Contains(tn))
                    teacher.RemoveAll(x =>x==tn);
            }

            if(this.chkingles.IsChecked == true)
                cmbTeacher.ItemsSource = teacher.Where(x => x.language == "Ingles").Distinct();//context.teacher.Select(x => new { x.idteacher, x.teacher_names, x.language }).ToList();
            else
                cmbTeacher.ItemsSource = teacher.Where(x => x.language == "Frances").Distinct();
            cmbTeacher.DisplayMemberPath = "teacher_names";
            cmbTeacher.SelectedValuePath = "idteacher";

         
        }

        private void initializeFormToEdit(grupo datarow)
        {
            gGlobal = datarow;
            datagroupID = (int)datarow.CategoriaID;
            txtTitleGrupo.Text = "Editar " + txtTitleGrupo.Text;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnGuardarEdit.Visibility = Visibility.Visible;

            grupo_categoria gc = new grupo_categoria();
            categoria c = new categoria();
            grupo g = new grupo();
            string startDate = "", endDate = "";

            gc = context.grupo_categoria.FirstOrDefault(x => x.idgrupo_categoria == datarow.CategoriaID);
            c = context.categoria.FirstOrDefault(x => x.idcategoria == gc.categoria_ID);
            g = context.grupo.FirstOrDefault(x => x.idgrupo == datarow.idgrupo);
            List<ciclo> lstCycles = context.ciclo.Where(x => x.ciclo_num == datarow.ciclo.ciclo_num && x.year == datarow.ciclo.year).ToList();
            
            foreach(ciclo cl in lstCycles)
            {
                if (cl.ciclo_side == "A")
                    startDate = cl.Fecha_inicio;
                else if (cl.ciclo_side == "B")
                    endDate = cl.Fecha_fin;
            }

            //cmbCategoria.SetValue(c.categoria_nombre);
            cmbCategoria.SelectedValue = c.categoria_nombre;
           
            switch (c.categoria_nombre)
            {
                case "Regular":
                case "KIDS":
                case "1:1":
                case "Empresarial":
                    cmbNivel12.IsEnabled = true;
                    cmbNivel12.Visibility = Visibility.Visible;
                    cmbNivel4.Visibility = Visibility.Collapsed;
                    cmbNivel12.SelectedValue = gc.nivel.ToString();
                    break;
                case "Avanzado":
                case "TOEFL":
                    cmbNivel4.IsEnabled = true;
                    cmbNivel4.Visibility = Visibility.Visible;
                    cmbNivel12.Visibility = Visibility.Collapsed;
                    cmbNivel4.SelectedValue = gc.nivel;
                    break;
            }
            switch (c.categoria_nombre)
            {
                case "1:1":
                case "Empresarial":
                case "KIDS":
                    cmbTipo2.IsEnabled = true;
                    cmbTipo2.SelectedValue = g.grupo_categoria.tipo;
                    cmbTipo2.Visibility = Visibility.Visible;
                    cmbTipo.Visibility = Visibility.Collapsed;
                    break;
                case "TOEFL":
                case "Avanzado":
                case "Regular":
                    cmbTipo.IsEnabled = true;
                    cmbTipo.SelectedValue = g.grupo_categoria.tipo;
                    cmbTipo.Visibility = Visibility.Visible;
                    cmbTipo2.Visibility = Visibility.Collapsed;
                    break;
            }

            cmbHrInicio.SelectedValue = datarow.Horario_inicio;
            cmbHrFin.SelectedValue = datarow.Horario_fin;

            string[] day;
            day=datarow.Dias.Split(' ');
            foreach(string d in day)
            {
                switch (d)
                {
                    case "L":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(0));
                        break;
                    case "M":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(1));
                        break;
                    case "Mi":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(2));
                        break;
                    case "J":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(3));
                        break;
                    case "V":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(4));
                        break;
                    case "S":
                        lstDias.SelectedItems.Add(lstDias.Items.GetItemAt(5));
                        break;
                }
            }
            
            
            if (datarow.Idioma == "Inglés")
                chkingles.IsChecked = true;
            else
                chkFrances.IsChecked = true;

            cmbTeacher.IsEnabled = true;
            cmbTeacher.Text = datarow.teacher.teacher_names;

            if (cmbCategoria.SelectedValue.ToString() == "1:1")
            {
                cmbCicloEscolar.Visibility = Visibility.Collapsed;
                dtpFechaInicioEscolar.Visibility = Visibility.Collapsed;
                dtpFechaFinEscolar.Visibility = Visibility.Collapsed;
                dtpFechaInicio.Visibility = Visibility.Visible;
                dtpFechaFin.Visibility = Visibility.Visible;
                cmbCiclo.Visibility = Visibility.Visible;
            }

            if(cmbCicloEscolar.Visibility == Visibility) {
                cmbCicloEscolar.SelectedValue = datarow.ciclo.ciclo_num;
                dtpFechaInicioEscolar.Text = startDate;
                dtpFechaFinEscolar.Text = endDate;

            }
            else if(cmbCiclo.Visibility == Visibility)
            {
                cmbCiclo.SelectedValue = datarow.ciclo.ciclo_num;
                dtpFechaInicio.Text = datarow.ciclo.Fecha_inicio;
                dtpFechaFin.Text = datarow.ciclo.Fecha_fin;
            }
            //dtpFechaInicio.SelectedDate = System.DateTime.Parse(datarow.ciclo.Fecha_inicio);
            //dtpFechaFin.SelectedDate = System.DateTime.Parse(datarow.ciclo.Fecha_fin);
            txtCantAlumnos.Text = datarow.numero_alumnos.ToString();
        }

        private void btnGuardarEdit_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = Grupo.ValidateFields(this);
            if (isValid)
            {
                int result = 0;
                result = Grupo.SaveEditGroup(this, datagroupID, gGlobal);

                if (result >= 0)
                {
                    MessageBox.Show("El registro se ha guardado");
                    CleanControls();
                }
                else
                    MessageBox.Show("WARNING!! El registro NO se ha guardado");
            }
        }

        
        private void chkingles_Click(object sender, RoutedEventArgs e)
        {
            comboTeacherCheck();
        }

        private void chkFrances_Click(object sender, RoutedEventArgs e)
        {
            comboTeacherCheck();
        }

        private void cmbCicloEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue != null)
            {
                int valueSelected = Int32.Parse(cmb.SelectedValue.ToString());
                Grupo.LoadCycles(valueSelected, this);
            }
        }
    }
}
