using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LIVEX.Class
{
    class Student
    {
    
        public static void initForm(LIVEX.UserControls.AddStudent s)
        {
            livexEntities context = new livexEntities();
            categoria c = new categoria();
            List<string> catList = new List<string>();

            catList = context.categoria.Select(x => x.categoria_nombre).Distinct().ToList();
            s.cmbCategoria.ItemsSource = catList;
        }

        public static int saveStudent(LIVEX.UserControls.AddStudent s)
        {
            livexEntities context = new livexEntities();

            alumno a = new alumno();
            a.alumno_nombre = s.txtName.Text;
            a.alumno_apellido_p = s.txtLastName.Text;
            a.alumno_apellido_m = s.txtMotherName.Text;
            a.fecha_nac = s.dtpBirthDay.Text;
            a.telefono_casa = s.txtPhoneHome.Text;
            a.telefono_celular = s.txtCellPhone.Text;
            a.domicilio_calle = s.txtStreet.Text;
            a.domicilio_no = s.txtNumExt.Text;
            a.domicilio_col = s.txtCol.Text;
            a.domicilio_mun = s.cmbMunicipio.Text;
            a.domicilio_cp = s.txtZipCode.Text;
            a.domicilio_edo = s.cmbState.Text;

            string levelnum = "";
            string leveltype = "";
            if (s.cmbNivel12.Visibility == Visibility.Visible)
                levelnum = s.cmbNivel12.Text;
            else
                levelnum = s.cmbNivel4.Text;
            if (s.cmbTipo.Visibility == Visibility.Visible)
                leveltype = s.cmbTipo.Text;
            else
                leveltype = s.cmbTipo2.Text;

            a.curso_inicial = s.cmbCategoria.Text + " " + levelnum + " " + leveltype;

            if (s.imgStudent.ImageSource != null)
                a.picture = s.imgStudent.ImageSource.ToString();
            else
                a.picture = "";

            if (s.chkInvoicing.IsChecked == true)
            {
                alumno_factura af = new alumno_factura();
                af.nombre = s.txtNameInvo.Text;
                af.rfc = s.txtRfc.Text;
                af.estado = s.cmbStateInv.Text;
                af.ciudad = s.cmbCiudadInv.Text;
                af.direccion = s.txtAdressInv.Text;
                af.direccion_no = s.txtNumAddinv.Text;
                af.colonia = s.txtNeighInv.Text;
                af.cp = s.txtZipCode.Text;
                a.alumno_factura = af;
            }
            
            context.alumno.Add(a);
            int result =context.SaveChanges();

            return result;

        }

        public static int saveEditStudent(LIVEX.UserControls.AddStudent s)
        {
            livexEntities context = new livexEntities();
            int id = Int32.Parse(s.txtID.Text);

            alumno a = context.alumno.FirstOrDefault(x =>x.idalumno == id);
            a.alumno_nombre = s.txtName.Text;
            a.alumno_apellido_p = s.txtLastName.Text;
            a.alumno_apellido_m = s.txtMotherName.Text;
            a.fecha_nac = s.dtpBirthDay.Text;
            a.telefono_casa = s.txtPhoneHome.Text;
            a.telefono_celular = s.txtCellPhone.Text;
            a.domicilio_calle = s.txtStreet.Text;
            a.domicilio_no = s.txtNumExt.Text;
            a.domicilio_col = s.txtCol.Text;
            a.domicilio_mun = s.cmbMunicipio.Text;
            a.domicilio_cp = s.txtZipCode.Text;
            a.domicilio_edo = s.cmbState.Text;

            string levelnum = "";
            string leveltype = "";

            if (s.cmbNivel12.Visibility == Visibility.Visible)
                levelnum = s.cmbNivel12.Text;
            else
                levelnum = s.cmbNivel4.Text;
            if (s.cmbTipo.Visibility == Visibility.Visible)
                leveltype = s.cmbTipo.Text;
            else
                leveltype = s.cmbTipo2.Text;

            a.curso_inicial = s.cmbCategoria.Text + " " + levelnum + " " + leveltype;

            if (s.imgStudent.ImageSource != null)
                a.picture = s.imgStudent.ImageSource.ToString();
            else
                a.picture = "";

            if (s.chkInvoicing.IsChecked == true)
            {
                alumno_factura af = new alumno_factura();
                af.nombre = s.txtNameInvo.Text;
                af.rfc = s.txtRfc.Text;
                af.estado = s.cmbStateInv.Text;
                af.ciudad = s.cmbCiudadInv.Text;
                af.direccion = s.txtAdressInv.Text;
                af.direccion_no = s.txtNumAddinv.Text;
                af.colonia = s.txtNeighInv.Text;
                af.cp = s.txtZipCode.Text;
                a.alumno_factura = af;
            }


            int result = context.SaveChanges();

            return result;
        }

        public static void cleanControls(LIVEX.UserControls.AddStudent s)
        {
            s.txtName.Text = "";
            s.txtLastName.Text = "";
            s.txtMotherName.Text = "";
            s.dtpBirthDay.Text = "";
            s.txtPhoneHome.Text = "";
            s.txtCellPhone.Text = "";
            s.txtStreet.Text = "";
            s.txtNumExt.Text = "";
            s.txtCol.Text = "";
            s.txtZipCode.Text = "";
            s.cmbMunicipio.Text = "";
            s.cmbState.Text = "";
            s.cmbCategoria.Text = "";
            s.cmbNivel12.Text = "";
            s.cmbNivel4.Text = "";
            s.cmbTipo.Text = "";
            s.cmbTipo2.Text = "";
            s.chkInvoicing.IsChecked = false;
            s.txtNameInvo.Text = "";
            s.txtRfc.Text = "";
            s.cmbStateInv.Text = "";
            s.cmbCiudadInv.Text = "";
            s.txtAdressInv.Text = "";
            s.txtNumAddinv.Text = "";
            s.txtNeighInv.Text = "";
            s.txtZipCodeInv.Text = "";
            s.imgStudent.ImageSource= null;

        }

        public static void initFormtoEdit(LIVEX.UserControls.AddStudent s, object row)
        {
            initForm(s);
            s.btnSaveNewStudent.Visibility = Visibility.Collapsed;
            s.btnSaveEditStudent.Visibility = Visibility.Visible;

            livexEntities context = new livexEntities();
            BitmapImage b = new BitmapImage();
            alumno aToEdit = (alumno)row;

            s.txtID.Text = aToEdit.idalumno.ToString();
            s.txtLabelHeader.Text = "Editar Alumno";
            s.txtName.Text = aToEdit.alumno_nombre;
            s.txtLastName.Text = aToEdit.alumno_apellido_p;
            s.txtMotherName.Text = aToEdit.alumno_apellido_m;
            s.dtpBirthDay.Text = aToEdit.fecha_nac;
            s.txtPhoneHome.Text = aToEdit.telefono_casa;
            s.txtCellPhone.Text = aToEdit.telefono_celular;
            s.txtStreet.Text = aToEdit.domicilio_calle;
            s.txtNumExt.Text = aToEdit.domicilio_no;
            s.txtCol.Text = aToEdit.domicilio_col;
            s.cmbMunicipio.Text = aToEdit.domicilio_mun;
            s.txtZipCode.Text = aToEdit.domicilio_cp;
            s.cmbState.Text = aToEdit.domicilio_edo;

            string[] curso;
            curso=aToEdit.curso_inicial.Split(' ');
            
                s.cmbNivel12.Text = curso[1];
                s.cmbNivel4.Text = curso[1];
                s.cmbTipo.Text = curso[2];
                s.cmbTipo2.Text = curso[2];

            s.cmbCategoria.Text = curso[0];

            if (aToEdit.picture != "" && aToEdit.picture != null)
            {
                b.BeginInit();
                b.UriSource = new Uri(aToEdit.picture);
                b.EndInit();
                s.imgStudent.ImageSource = b;
            }

            if (aToEdit.alumno_factura != null)
            {
                s.chkInvoicing.IsChecked = true;
                s.txtNameInvo.Text = aToEdit.alumno_factura.nombre;
                s.txtRfc.Text = aToEdit.alumno_factura.rfc;
                s.cmbStateInv.Text = aToEdit.alumno_factura.estado;
                s.cmbCiudadInv.Text = aToEdit.alumno_factura.ciudad;
                s.txtAdressInv.Text = aToEdit.alumno_factura.direccion;
                s.txtNumAddinv.Text = aToEdit.alumno_factura.direccion_no;
                s.txtNeighInv.Text = aToEdit.alumno_factura.colonia;
                s.txtZipCodeInv.Text = aToEdit.alumno_factura.cp;
            }
        }

        public static List<alumno> DeleteTeacher(object row)
        {
            alumno a = (alumno)row;
            livexEntities context = new livexEntities();
            alumno aToDelete = context.alumno.FirstOrDefault(x => x.idalumno == a.idalumno);
            context.alumno.Remove(aToDelete);
            context.SaveChanges();
            List<alumno> lstStudents = context.alumno.ToList();
            return lstStudents;
        }

    }
}
