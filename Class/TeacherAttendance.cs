using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LIVEX.Class
{
    class TeacherAttendance
    {
        public static List<TeacherAttendanceView> initTable() 
        {
            List<TeacherAttendanceView> lstTAttendance = new List<TeacherAttendanceView>();
            livexEntities context = new livexEntities();
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime todayIS = Convert.ToDateTime(today);           

            List<asistencia_maestros> lstAM = context.asistencia_maestros.Where(x => x.date >= todayIS).ToList();

            foreach (asistencia_maestros am in lstAM) {
                teacher t = context.teacher.FirstOrDefault(x => x.uid == am.UID);
                TeacherAttendanceView tav = new TeacherAttendanceView();
                DateTime shortdate = Convert.ToDateTime(am.date.ToString());

                tav.UID = am.UID;
                tav.Name = am.Name;
                tav.Date = shortdate.ToShortDateString();
                tav.Time = am.hour+":"+am.min+":"+am.sec;
                tav.id = am.asistencia_maestrosID;
                if (t != null)
                    tav.TeacherName = t.teacher_names + " " +t.teacher_lastname;
                else
                    tav.TeacherName = "";

                lstTAttendance.Add(tav);
            }

            return lstTAttendance;
        }

        public static int uploadTimerFile(string path, string filename)
        {
            try
            {
                livexEntities context = new livexEntities();
                int result = 0;

                using (var reader = new StreamReader(path))//(@"C:\Users\Tania\Documents\NewCo\Proyectos\LIVEX\Docs\LogData\HisGLog_0001_20171201.csv"))
                {
                    int isduplicated = context.asistencia_maestros.Count(x => x.filename == filename);

                    if (isduplicated > 0)
                    {
                        MessageBox.Show("El archivo ya ha sido cargado");
                        return 0;
                    }
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        asistencia_maestros am = new asistencia_maestros();

                        var line = reader.ReadLine();
                        var values = line.Split('\t');

                        if (i > 0)
                        {
                            am.No = Int32.Parse(values[0]);
                            am.DN = Int32.Parse(values[1]);
                            am.UID = values[2];
                            am.Name = values[3];
                            am.Status = values[4];
                            am.Action = Int32.Parse(values[5]);
                            am.APB = Int32.Parse(values[6]);
                            am.JobCode = Int32.Parse(values[7]);
                            am.date = Convert.ToDateTime(Convert.ToDateTime(values[8]).ToShortDateString());
                            am.hour = Convert.ToDateTime(values[8]).Hour;
                            am.min = Convert.ToDateTime(values[8]).Minute;
                            am.sec = Convert.ToDateTime(values[8]).Second;
                            am.filename = filename;

                            context.asistencia_maestros.Add(am);
                        }
                        i++;
                    }
                    result=context.SaveChanges();
                }
                if (result > 0)
                {
                    MessageBox.Show("Archivo cargado exitosamente");
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }
        }

        public static List<TeacherAttendanceView> FilterTable(DateTime from, DateTime until)
        {
            livexEntities context = new livexEntities();
            List<TeacherAttendanceView> lstTAttendance = new List<TeacherAttendanceView>();
            List<asistencia_maestros> lstAm = context.asistencia_maestros.Where(x => x.date >= from && x.date <= until).ToList();

            foreach (asistencia_maestros am in lstAm)
            {
                teacher t = context.teacher.FirstOrDefault(x => x.uid == am.UID);
                TeacherAttendanceView tav = new TeacherAttendanceView();
                DateTime shortdate = Convert.ToDateTime(am.date.ToString());

                tav.UID = am.UID;
                tav.Name = am.Name;
                tav.Date = shortdate.ToShortDateString();
                tav.Time = am.hour + ":" + am.min + ":" + am.sec;
                tav.id = am.asistencia_maestrosID;
                if(t != null)
                    tav.TeacherName = t.teacher_names + " " + t.teacher_lastname;
                else
                    tav.TeacherName = "";

                lstTAttendance.Add(tav);
            }

            return lstTAttendance;

        }

        public static void InitCombos(LIVEX.UserControls.AsistenciaMaestros am)
        {
            livexEntities context = new livexEntities();
            List<teacher> lstTeachers = context.teacher.ToList();
            List<asistencia_maestros> lstasm = context.asistencia_maestros.ToList();
            List<string> lstUID = new List<string>();
            List<string> lstNames = new List<string>();
            List<string> lstTeacherNames = new List<string>();
            List<string> lstHours = new List<string>();

            foreach(asistencia_maestros a in lstasm)
            {
                lstUID.Add(a.UID);
                lstNames.Add(a.Name);
            }

            foreach(teacher t in lstTeachers)
            {
                lstTeacherNames.Add(t.teacher_names + " " + t.teacher_lastname);
                
            }

            //am.cmbTeacherNames.ItemsSource = lstTeacherNames.Distinct().ToList();
            am.cmbUID.ItemsSource = lstUID.Distinct().ToList();
            am.cmbName.ItemsSource = lstNames.Distinct().ToList();
            am.cmbHour.Items.Add("01:00");
            am.cmbHour.Items.Add("02:00");
            am.cmbHour.Items.Add("03:00");
            am.cmbHour.Items.Add("04:00");
            am.cmbHour.Items.Add("05:00");
            am.cmbHour.Items.Add("06:00");
            am.cmbHour.Items.Add("07:00");
            am.cmbHour.Items.Add("08:00");
            am.cmbHour.Items.Add("09:00");
            am.cmbHour.Items.Add("10:00");
            am.cmbHour.Items.Add("11:00");
            am.cmbHour.Items.Add("12:00");
            am.cmbHour.Items.Add("13:00");
            am.cmbHour.Items.Add("14:00");
            am.cmbHour.Items.Add("15:00");
            am.cmbHour.Items.Add("16:00");
            am.cmbHour.Items.Add("17:00");
            am.cmbHour.Items.Add("18:00");
            am.cmbHour.Items.Add("19:00");
            am.cmbHour.Items.Add("20:00");
            am.cmbHour.Items.Add("21:00");
            am.cmbHour.Items.Add("22:00");
            am.cmbHour.Items.Add("23:00");
            am.cmbHour.Items.Add("00:00");
        }

        public static bool validateAddRow(LIVEX.UserControls.AsistenciaMaestros am)
        {

            bool result = false;
            if (am.cmbUID.Text == "") {
                MessageBox.Show("Favor de seleccionar un ID de asistencia");
                return false;
            }
            else
                result = true;

            if (am.cmbName.Text == "")
            {
                MessageBox.Show("Favor de seleccionar un Nombre de asistencia");
                return false;
            }
            else
                result = true;

            if (am.dpDate.Text == "")
            {
                MessageBox.Show("Favor de seleccionar una Fecha");
                return false;
            }
            else
                result = true;

            if (am.cmbHour.Text == "")
            {
                MessageBox.Show("Favor de seleccionar una Hora");
                return false;
            }
            else
                result = true;

            return result;
        }

        public static void refreshCombos(LIVEX.UserControls.AsistenciaMaestros am)
        {
            livexEntities context = new livexEntities();
            asistencia_maestros a = new asistencia_maestros();
            teacher t = new teacher();

            if (am.cmbUID.SelectedItem != null || am.cmbUID.Text != "")
            {
                string uid = am.cmbUID.SelectedItem.ToString();
                a = context.asistencia_maestros.FirstOrDefault(x => x.UID == uid);
                if(a != null)
                {
                    am.cmbName.Text = a.Name;
                    am.cmbName.SelectedValue = a.Name;

                    //teacher teacherFound = context.teacher.FirstOrDefault(x => x.uid == a.UID);

                    //if (teacherFound != null)
                    //{
                    //    am.cmbTeacherNames.Text = teacherFound.teacher_names + " " + teacherFound.teacher_lastname;
                    //    am.cmbTeacherNames.SelectedValue = teacherFound.teacher_names + " " + teacherFound.teacher_lastname;
                    //}

                }
            }
        }

        public static void AddAttendaceRow(LIVEX.UserControls.AsistenciaMaestros am)
        {
            livexEntities context = new livexEntities();
            asistencia_maestros newAtt = new asistencia_maestros();
            DateTime date = Convert.ToDateTime(am.dpDate.Text);
            string hour = am.cmbHour.Text;
            var time = hour.Split(':');

            newAtt.DN = 1;
            newAtt.UID = am.cmbUID.Text;
            newAtt.Name = am.cmbName.Text;
            newAtt.Status = "0";
            newAtt.Action = 3;
            newAtt.APB = 0;
            newAtt.JobCode = 0;
            newAtt.date = Convert.ToDateTime(date.ToShortDateString());
            newAtt.No = 0;
            newAtt.filename = "LIVEX_Sys";
            newAtt.hour = Int32.Parse(time[0]);
            newAtt.min = Int32.Parse(time[1]);
            if(time.Count() > 2)
                newAtt.sec = Int32.Parse(time[2]);
            else
                newAtt.sec = 0;

            context.asistencia_maestros.Add(newAtt);
            int result = context.SaveChanges();
            if (result > 0)
                MessageBox.Show("El registro se guardó exitosamente");
            else
                MessageBox.Show("El registro NO se guardó");

        }

        public static void ResetRowCombos(LIVEX.UserControls.AsistenciaMaestros am)
        {
            am.cmbUID.Text = "";
            am.cmbName.Text = "";
            //am.cmbTeacherNames.Text = "";
            am.dpDate.Text = "";
            am.cmbHour.Text = "";

            am.cmbUID.IsEnabled = false;
            am.cmbName.IsEnabled = false;
            //am.cmbTeacherNames.IsEnabled = false;
            am.dpDate.IsEnabled = false;
            am.cmbHour.IsEnabled = false;
            am.btnCheckBlue.IsEnabled = false;
            am.btnCheckBlueEdit.IsEnabled = false;
            am.btnCheckBlueEdit.Visibility = Visibility.Collapsed;
            am.btnCheckBlue.Visibility = Visibility.Visible;

            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri("pack://application:,,,/LIVEX;component/Images/002-checked.png");
            b.EndInit();
            am.imgCheck.Stretch = Stretch.Uniform;
            am.imgCheck.Source = b;

        }

        public static void EditRow(LIVEX.UserControls.AsistenciaMaestros am, object attRow)
        {
            TeacherAttendanceView atteToEdit = (TeacherAttendanceView)attRow;

            am.cmbUID.IsEnabled = true;
            am.cmbName.IsEnabled = true;
            //am.cmbTeacherNames.IsEnabled = true;
            am.cmbHour.IsEnabled = true;
            am.dpDate.IsEnabled = true;
            am.btnCheckBlueEdit.IsEnabled = true;

            am.cmbUID.Text = atteToEdit.UID;
            am.cmbName.Text = atteToEdit.Name;
            //am.cmbTeacherNames.Text = atteToEdit.TeacherName;
            am.dpDate.Text = atteToEdit.Date;
            am.cmbHour.Text = atteToEdit.Time;

            am.btnCheckBlue.Visibility = Visibility.Collapsed;
            am.btnCheckBlueEdit.Visibility = Visibility.Visible;
            

        }

        public static void EditSelected(LIVEX.UserControls.AsistenciaMaestros am)
        {
            string uid = am.cmbUID.Text;
            livexEntities context = new livexEntities();
            asistencia_maestros teacherAtt = context.asistencia_maestros.FirstOrDefault(x => x.UID == uid);
            string hour = am.cmbHour.Text;
            var time = hour.Split(':');
            
            teacherAtt.Name = am.cmbName.Text;
            teacherAtt.hour = Int32.Parse(time[0]);
            teacherAtt.min = Int32.Parse(time[1]);
            if (time.Count() > 2)
                teacherAtt.sec = Int32.Parse(time[2]);
            else
                teacherAtt.sec = 0;

            teacherAtt.date = Convert.ToDateTime(am.dpDate.Text);

            int result = context.SaveChanges();
            if (result >= 0)
                MessageBox.Show("El registro se guardó exitosamente");
            else
                MessageBox.Show("El registro NO se guardó");

        }

        public static void DeleteRow(LIVEX.UserControls.AsistenciaMaestros am, object attRow)
        {
            TeacherAttendanceView row = (TeacherAttendanceView)attRow;
            livexEntities context = new livexEntities();
            asistencia_maestros teacherDelete = context.asistencia_maestros.FirstOrDefault(x => x.asistencia_maestrosID == row.id);

            if (teacherDelete != null)
            {
                context.asistencia_maestros.Remove(teacherDelete);
                int result = context.SaveChanges();
                if (result > 0)
                    MessageBox.Show("El registro se borró exitosamente");
                else
                    MessageBox.Show("Error al borrar el registro");
            }

        }

    }
}
