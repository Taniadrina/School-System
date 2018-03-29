using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Input;

namespace LIVEX.Class
{
    class TeacherForm
    {
        static Decimal tH = 0;
        public static void InitializeForm1(UserControls.TableTeacherGroup ttg)
        {
            livexEntities context = new livexEntities();

            List<ciclo> lstCiclo = new List<ciclo>();
            ttg.cmbTeacherNames.ItemsSource = context.teacher.Select(x => new { x.idteacher, x.teacher_names }).ToList();
            ttg.cmbTeacherNames.DisplayMemberPath = "teacher_names";
            ttg.cmbTeacherNames.SelectedValuePath = "idteacher";

            lstCiclo = context.ciclo.Where(x => x.year==DateTime.Today.Year && x.ciclo_side == "A" || x.ciclo_side == "B").OrderBy(x => x.ciclo_num).ToList();
            List<string> ciclostring = new List<string>();

            foreach (ciclo c in lstCiclo)
            {
                string ciclo = "Ciclo " + c.ciclocol + " del " + c.Fecha_inicio + " al " + c.Fecha_fin;
                ciclostring.Add(ciclo);
            }

            ttg.cmbCiclo.ItemsSource = ciclostring;
        }

        public static void InitializeCiclo(UserControls.TableTeacherGroup ttg, int teacherID) {
            livexEntities context = new livexEntities();
            List<grupo> lstg = new List<grupo>();
            List<ciclo> lstc = new List<ciclo>();

            lstg = context.grupo.Where(x => x.MaestroID == teacherID).ToList();
            foreach (grupo g in lstg)
            {
                lstc.Add(context.ciclo.FirstOrDefault(x => x.idciclo == g.CicloID));
            }
            //c= context.ciclo.Where(x=>x.idciclo==g.)
            ttg.cmbCiclo.IsEnabled = true;
            ttg.cmbCiclo.ItemsSource = lstc;
        }

        public static void ButtonSee(UserControls.TableTeacherGroup ttg)
        {
            if (ttg.cmbTeacherNames.SelectedIndex > -1 && ttg.cmbCiclo.SelectedIndex > -1)
                ttg.btnVerNomina.IsEnabled = true;
        }

        public static void CollapseControls(LIVEX.UserControls.NominaMaestros nom)
        {
            //nom.btnPrint.Visibility = Visibility.Collapsed;
            //nom.btnSalir.Visibility = Visibility.Hidden;
        }

        public static void FillHeaderNom(LIVEX.UserControls.TableTeacherGroup ttg, LIVEX.UserControls.NominaMaestros nom)
        {
            livexEntities context = new livexEntities();
            List<teacher_skills> lstTs = new List<teacher_skills>();
            teacher t = new teacher();

            string[] ciclo = ttg.cmbCiclo.Text.Split(' ');
            string middleDay;

            int idTeacher = Int32.Parse(ttg.cmbTeacherNames.SelectedValue.ToString());
            lstTs = context.teacher_skills.Where(x => x.teacherID == idTeacher).ToList();
            t = context.teacher.FirstOrDefault(x => x.idteacher == idTeacher);

            DateTime firstDay = DateTime.Parse(ciclo[4]);
            DateTime lastDay = DateTime.Parse(ciclo[6]);
            middleDay = firstDay.AddDays(12).ToShortDateString();
            nom.txtTName.Text = ttg.cmbTeacherNames.Text;
            nom.txtCiclo.Text = ciclo[0]+" "+ciclo[1]+ " " +ciclo[2];
            nom.txtFechas.Text = ciclo[4] + " AL\n " + middleDay;
            nom.txtYear.Text = DateTime.Parse(ciclo[4]).Year.ToString();
            nom.txtAlta.Text = t.start_date;
            if (ciclo[2] == "A")
                nom.txtNoSemanas.Text = "SEMANA 1 y 2";
            else
                nom.txtNoSemanas.Text = "SEMANA 3 y 4";
            nom.txtFechaInicio.Text = "INICIA \n"+firstDay.ToShortDateString();
            nom.txtFechaFin.Text = "TERMINA \n"+lastDay.ToShortDateString();
            nom.txtFechaDep.Text = "PARA DEPOSITO " + lastDay.AddDays(2).ToLongDateString().ToUpper();

            
            foreach(teacher_skills ts in lstTs)
            {
                switch (ts.skillID)
                {
                    case 1:
                        nom.txtTOEFL.Foreground = Brushes.Green;
                        break;
                    case 2:
                        nom.txtExp.Foreground = Brushes.Green;
                        break;
                    case 3:
                        nom.txtTra.Foreground = Brushes.Green;
                        break;
                    case 4:
                        nom.txtLic.Foreground = Brushes.Green;
                        break;
                }
            }

            nom.txtSalario_Base.Text = t.salary_base.ToString();
            nom.txtSignName.Text = ttg.cmbTeacherNames.Text.ToUpper() +" " +t.teacher_lastname.ToUpper();
            nom.txtTeacherName.Text = "TEACHER: " + ttg.cmbTeacherNames.Text.ToUpper() + " " + t.teacher_lastname.ToUpper();

            AddGroups(idTeacher, nom, ciclo);
        }

        private static void AddGroups(int idTeacher, LIVEX.UserControls.NominaMaestros nom, string[] ciclo)
        {
            livexEntities context = new livexEntities();
            List<grupo> lstg = new List<grupo>();
            int numCycle = Int32.Parse(ciclo[1]);
            string cycleside = ciclo[2];
            string startDate = ciclo[4];
            string endDate = ciclo[6];
            DateTime date1 = Convert.ToDateTime(startDate);
            DateTime date2 = Convert.ToDateTime(endDate);

            ciclo c = context.ciclo.FirstOrDefault(x => x.ciclo_num == numCycle && x.ciclo_side == cycleside && x.Fecha_inicio == startDate && x.Fecha_fin == endDate);
            List<ciclo> lstCyclesC = context.ciclo.Where(x => x.ciclo_side == "C" && x.year == date1.Year).ToList();// all the 1:1 and enterprise cycles of the year
            List<ciclo> lstCs = new List<LIVEX.ciclo>();

            if (c != null)
            {
                lstg = context.grupo.Where(x => x.teacher.idteacher == idTeacher && x.CicloID == c.idciclo).ToList();
                foreach (ciclo iC in lstCyclesC)
                {
                    bool addCycle = false;
                    DateTime d1 = Convert.ToDateTime(iC.Fecha_inicio);
                    DateTime d2 = Convert.ToDateTime(iC.Fecha_fin);
                    if (date1 >= d1 && date1 <= d2)
                    {
                        addCycle = true;
                    }

                    if (addCycle)
                    {
                        //lstCs.Add(iC);
                        grupo g = context.grupo.FirstOrDefault(x => x.teacher.idteacher == idTeacher && x.CicloID == iC.idciclo);
                        if (g != null)
                            lstg.Add(g);
                    }
                }
            }

            if (lstg != null)
            {
                for (int x = 0; x < lstg.Count; x++)
                {
                    Grid grdGroup = new Grid();
                    Thickness margin = grdGroup.Margin;
                    margin.Top = 20;
                    grdGroup.Margin = margin;



                    //Columns
                    ColumnDefinition col1 = new ColumnDefinition();
                    ColumnDefinition col2 = new ColumnDefinition();
                    ColumnDefinition col3 = new ColumnDefinition();
                    ColumnDefinition col4 = new ColumnDefinition();
                    ColumnDefinition col5 = new ColumnDefinition();
                    ColumnDefinition col6 = new ColumnDefinition();
                    ColumnDefinition col7 = new ColumnDefinition();
                    grdGroup.ColumnDefinitions.Add(col1);
                    grdGroup.ColumnDefinitions.Add(col2);
                    grdGroup.ColumnDefinitions.Add(col3);
                    grdGroup.ColumnDefinitions.Add(col4);
                    grdGroup.ColumnDefinitions.Add(col5);
                    grdGroup.ColumnDefinitions.Add(col6);
                    grdGroup.ColumnDefinitions.Add(col7);

                    //Row
                    RowDefinition row1 = new RowDefinition();
                    RowDefinition row2 = new RowDefinition();
                    row2.Height = new GridLength(48);
                    RowDefinition row3 = new RowDefinition();
                    grdGroup.RowDefinitions.Add(row1);
                    grdGroup.RowDefinitions.Add(row2);
                    grdGroup.RowDefinitions.Add(row3);

                    //Column Header

                    Border myborderGrupo = new Border();
                    Border myborderHorario = new Border();
                    Border myborderHr = new Border();
                    Border myborderLevel = new Border();
                    Border myborderNivel = new Border();
                    Border myborderHoras = new Border();
                    Border myborderHrs = new Border();

                    myborderGrupo.Background = Brushes.White;
                    myborderGrupo.BorderBrush = Brushes.Black;
                    myborderGrupo.BorderThickness = new Thickness(2, 2, 1, 0);
                    myborderHrs.BorderThickness = new Thickness(0, 2, 2, 0);
                    myborderHorario.BorderThickness = new Thickness(0, 2, 1, 0);
                    myborderHoras.BorderThickness = myborderNivel.BorderThickness = myborderLevel.BorderThickness = myborderHr.BorderThickness = myborderHorario.BorderThickness;
                    myborderHrs.BorderBrush = myborderHoras.BorderBrush = myborderNivel.BorderBrush = myborderLevel.BorderBrush = myborderHr.BorderBrush = myborderHorario.BorderBrush = myborderGrupo.BorderBrush;
                    myborderHrs.Background = myborderHoras.Background = myborderNivel.Background = myborderLevel.Background = myborderHr.Background = myborderHorario.Background = myborderGrupo.Background;

                    TextBlock txtGrupo = new TextBlock();
                    txtGrupo.Text = "GRUPO " + (x + 1);
                    txtGrupo.TextAlignment = TextAlignment.Center;
                    txtGrupo.FontWeight = FontWeights.Bold;
                    myborderGrupo.Child = txtGrupo;
                    Grid.SetRow(myborderGrupo, 0);
                    Grid.SetColumn(myborderGrupo, 0);


                    TextBlock txtHorario = new TextBlock();
                    txtHorario.Text = "HORARIO";
                    txtHorario.FontWeight = FontWeights.Bold;
                    txtHorario.TextAlignment = TextAlignment.Center;
                    myborderHorario.Child = txtHorario;
                    Grid.SetRow(myborderHorario, 0);
                    Grid.SetColumn(myborderHorario, 1);

                    TextBlock txtHr = new TextBlock();
                    txtHr.Text = lstg[x].Horario_inicio;
                    txtHr.TextAlignment = TextAlignment.Center;
                    txtHr.FontWeight = FontWeights.Bold;
                    myborderHr.Child = txtHr;
                    Grid.SetRow(myborderHr, 0);
                    Grid.SetColumn(myborderHr, 2);

                    TextBlock txtLevel = new TextBlock();
                    txtLevel.Text = "NIVEL";
                    txtLevel.TextAlignment = TextAlignment.Center;
                    txtLevel.FontWeight = FontWeights.Bold;
                    myborderLevel.Child = txtLevel;
                    Grid.SetRow(myborderLevel, 0);
                    Grid.SetColumn(myborderLevel, 3);

                    TextBlock txtNivel = new TextBlock();
                    txtNivel.Text = lstg[x].nombre_nivel;
                    txtNivel.TextAlignment = TextAlignment.Center;
                    txtNivel.FontWeight = FontWeights.Bold;
                    myborderNivel.Child = txtNivel;
                    Grid.SetRow(myborderNivel, 0);
                    Grid.SetColumn(myborderNivel, 4);

                    TextBlock txtHoras = new TextBlock();
                    txtHoras.Text = "HORAS";
                    txtHoras.FontWeight = FontWeights.Bold;
                    txtHoras.TextAlignment = TextAlignment.Center;
                    myborderHoras.Child = txtHoras;
                    Grid.SetRow(myborderHoras, 0);
                    Grid.SetColumn(myborderHoras, 5);

                    TextBox txtHrs = new TextBox();
                    txtHrs.Text = "0";
                    txtHrs.TextAlignment = TextAlignment.Center;
                    txtHrs.FontWeight = FontWeights.Bold;
                    myborderHrs.Child = txtHrs;
                    txtHrs.KeyUp += new KeyEventHandler(txtHrs_KeyUp);
                    Grid.SetRow(myborderHrs, 0);
                    Grid.SetColumn(myborderHrs, 6);


                    //Add columns header
                    grdGroup.Children.Add(myborderGrupo);
                    grdGroup.Children.Add(myborderHorario);
                    grdGroup.Children.Add(myborderHr);
                    grdGroup.Children.Add(myborderLevel);
                    grdGroup.Children.Add(myborderNivel);
                    grdGroup.Children.Add(myborderHoras);
                    grdGroup.Children.Add(myborderHrs);

                    //Middle Row

                    Border myborderAlumnos = new Border();
                    Border myborder_SalBase = new Border();
                    Border myborderComAl = new Border();
                    Border myborderBAsiP = new Border();
                    Border myborderBExe = new Border();
                    Border myborderTotByHr = new Border();
                    Border myborderTot = new Border();

                    myborderAlumnos.Background = new SolidColorBrush(Color.FromRgb(25, 156, 174));
                    myborderAlumnos.BorderBrush = Brushes.Black;
                    myborderAlumnos.BorderThickness = new Thickness(2, 1, 1, 0);
                    myborderTot.BorderThickness = new Thickness(0, 1, 2, 0);
                    myborder_SalBase.BorderThickness = new Thickness(0, 1, 1, 0);

                    myborderTotByHr.BorderThickness = myborderBExe.BorderThickness = myborderBAsiP.BorderThickness = myborderComAl.BorderThickness = myborder_SalBase.BorderThickness;
                    myborderTot.BorderBrush = myborderTotByHr.BorderBrush = myborderBExe.BorderBrush = myborderBAsiP.BorderBrush = myborderComAl.BorderBrush = myborder_SalBase.BorderBrush = myborderAlumnos.BorderBrush;
                    myborderTot.Background = myborderTotByHr.Background = myborderBExe.Background = myborderBAsiP.Background = myborderComAl.Background = myborder_SalBase.Background = myborderAlumnos.Background;

                    TextBlock txtAlumnos = new TextBlock();
                    txtAlumnos.Text = "# Alumnos ";
                    txtAlumnos.TextAlignment = TextAlignment.Center;
                    myborderAlumnos.Child = txtAlumnos;
                    Grid.SetRow(myborderAlumnos, 1);
                    Grid.SetColumn(myborderAlumnos, 0);

                    TextBlock txtSalBase = new TextBlock();
                    txtSalBase.Text = "Salario base";
                    txtSalBase.TextAlignment = TextAlignment.Center;
                    myborder_SalBase.Child = txtSalBase;
                    Grid.SetRow(myborder_SalBase, 1);
                    Grid.SetColumn(myborder_SalBase, 1);

                    TextBlock txtComAl = new TextBlock();
                    txtComAl.Text = "Comision por\nAlumno";
                    txtComAl.TextAlignment = TextAlignment.Center;
                    myborderComAl.Child = txtComAl;
                    Grid.SetRow(myborderComAl, 1);
                    Grid.SetColumn(myborderComAl, 2);

                    TextBlock txtBAsiP = new TextBlock();
                    txtBAsiP.Text = "Bono\nAsistencia y\npuntualidad";
                    txtBAsiP.TextAlignment = TextAlignment.Center;
                    myborderBAsiP.Child = txtBAsiP;
                    Grid.SetRow(myborderBAsiP, 1);
                    Grid.SetColumn(myborderBAsiP, 3);

                    TextBlock txtBExe = new TextBlock();
                    txtBExe.Text = "Bono  de\nExcelencia ";
                    txtBExe.TextAlignment = TextAlignment.Center;
                    myborderBExe.Child = txtBExe;
                    Grid.SetRow(myborderBExe, 1);
                    Grid.SetColumn(myborderBExe, 4);

                    TextBlock txtTotByHr = new TextBlock();
                    txtTotByHr.Text = "TOTAL POR\nHORA";
                    txtTotByHr.TextAlignment = TextAlignment.Center;
                    myborderTotByHr.Child = txtTotByHr;
                    Grid.SetRow(myborderTotByHr, 1);
                    Grid.SetColumn(myborderTotByHr, 5);

                    TextBlock txtTot = new TextBlock();
                    txtTot.Text = "TOTAL";
                    txtTot.TextAlignment = TextAlignment.Center;
                    myborderTot.Child = txtTot;
                    Grid.SetRow(myborderTot, 1);
                    Grid.SetColumn(myborderTot, 6);

                    //Add Middle row
                    grdGroup.Children.Add(myborderAlumnos);
                    grdGroup.Children.Add(myborder_SalBase);
                    grdGroup.Children.Add(myborderComAl);
                    grdGroup.Children.Add(myborderBAsiP);
                    grdGroup.Children.Add(myborderBExe);
                    grdGroup.Children.Add(myborderTotByHr);
                    grdGroup.Children.Add(myborderTot);

                    //Last Row
                    Border myborderNoAlumnos = new Border();
                    Border myborderSalBase = new Border();
                    Border myborderCComAl = new Border();
                    Border myborderCBAsiP = new Border();
                    Border myborderCBExe = new Border();
                    Border myborderCTotByHr = new Border();
                    Border mybordercTot = new Border();

                    myborderNoAlumnos.Background = Brushes.White;
                    myborderCTotByHr.Background = mybordercTot.Background = Brushes.LightBlue;
                    myborderNoAlumnos.BorderBrush = Brushes.Black;
                    myborderNoAlumnos.BorderThickness = new Thickness(2, 1, 1, 2);
                    mybordercTot.BorderThickness = new Thickness(0, 1, 2, 2);
                    myborderCComAl.BorderThickness = new Thickness(0, 1, 1, 2);
                    mybordercTot.BorderBrush = myborderCTotByHr.BorderBrush = myborderCBExe.BorderBrush = myborderCBAsiP.BorderBrush = myborderCComAl.BorderBrush = myborderSalBase.BorderBrush = myborderNoAlumnos.BorderBrush;
                    myborderCBExe.BorderThickness = myborderCBAsiP.BorderThickness = myborderCTotByHr.BorderThickness = myborderSalBase.BorderThickness = myborderCComAl.BorderThickness;
                    myborderCBExe.Background = myborderCBAsiP.Background = myborderCComAl.Background = myborderSalBase.Background = myborderNoAlumnos.Background;

                    TextBlock txtNoAlumnos = new TextBlock();
                    txtNoAlumnos.Text = lstg[x].numero_alumnos.ToString();
                    txtNoAlumnos.TextAlignment = TextAlignment.Center;
                    myborderNoAlumnos.Child = txtNoAlumnos;
                    Grid.SetRow(myborderNoAlumnos, 2);
                    Grid.SetColumn(myborderNoAlumnos, 0);

                    TextBlock txtCSalBase = new TextBlock();
                    txtCSalBase.Text = lstg[x].teacher.salary_base.ToString();
                    txtCSalBase.TextAlignment = TextAlignment.Center;
                    myborderSalBase.Child = txtCSalBase;
                    Grid.SetRow(myborderSalBase, 2);
                    Grid.SetColumn(myborderSalBase, 1);

                    TextBlock txtCComAl = new TextBlock();
                    txtCComAl.Text = ((lstg[x].numero_alumnos) * (lstg[x].teacher.salary_base) * (0.15)).ToString();
                    txtCComAl.TextAlignment = TextAlignment.Center;
                    myborderCComAl.Child = txtCComAl;
                    Grid.SetRow(myborderCComAl, 2);
                    Grid.SetColumn(myborderCComAl, 2);

                    TextBlock txtCBAsiP = new TextBlock();
                    Decimal bono_asis = (lstg[x].teacher.salary_base + Decimal.Parse(txtCComAl.Text));
                    txtCBAsiP.TextAlignment = TextAlignment.Center;
                    Decimal Prop_bonoAsis = Decimal.Multiply(bono_asis, 0.2M);
                    txtCBAsiP.Text = Prop_bonoAsis.ToString();
                    myborderCBAsiP.Child = txtCBAsiP;
                    Grid.SetRow(myborderCBAsiP, 2);
                    Grid.SetColumn(myborderCBAsiP, 3);

                    TextBlock txtCBExe = new TextBlock();
                    txtCBExe.Text = Prop_bonoAsis.ToString();
                    txtCBExe.TextAlignment = TextAlignment.Center;
                    myborderCBExe.Child = txtCBExe;
                    Grid.SetRow(myborderCBExe, 2);
                    Grid.SetColumn(myborderCBExe, 4);

                    TextBlock txtCTotByHr = new TextBlock();
                    txtCTotByHr.Text = (lstg[x].teacher.salary_base + Decimal.Parse(txtCComAl.Text) + Decimal.Parse(txtCBAsiP.Text) + Decimal.Parse(txtCBExe.Text)).ToString();
                    txtCTotByHr.TextAlignment = TextAlignment.Center;
                    myborderCTotByHr.Child = txtCTotByHr;
                    Grid.SetRow(myborderCTotByHr, 2);
                    Grid.SetColumn(myborderCTotByHr, 5);

                    TextBlock txtcTot = new TextBlock();
                    txtcTot.Text = Decimal.Multiply(Decimal.Parse(txtCTotByHr.Text), Decimal.Parse(txtHrs.Text)).ToString();
                    txtcTot.TextAlignment = TextAlignment.Center;
                    txtcTot.FontWeight = FontWeights.Bold;
                    mybordercTot.Child = txtcTot;
                    Grid.SetRow(mybordercTot, 2);
                    Grid.SetColumn(mybordercTot, 6);


                    //Add Last row
                    grdGroup.Children.Add(myborderNoAlumnos);
                    grdGroup.Children.Add(myborderSalBase);
                    grdGroup.Children.Add(myborderCComAl);
                    grdGroup.Children.Add(myborderCBAsiP);
                    grdGroup.Children.Add(myborderCBExe);
                    grdGroup.Children.Add(myborderCTotByHr);
                    grdGroup.Children.Add(mybordercTot);

                    nom.stkContainer.Children.Add(grdGroup);
                }
            }
        }

        public static void txtHrs_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            Border b = (Border)t.Parent;
            Grid g = (Grid)b.Parent;
            Decimal Total=0;

            Border brdTotal = (Border)g.Children.Cast<UIElement>()
              .FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 5);

            Border brdCTotal = (Border)g.Children.Cast<UIElement>()
                .FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 6);

            TextBlock txtTotal= (TextBlock)VisualTreeHelper.GetChild(brdTotal, 0);
            TextBlock txtCTotal = (TextBlock)VisualTreeHelper.GetChild(brdCTotal, 0);

            if (t.Text == "")
                txtCTotal.Text = "0";
            else
            {
                Total = Decimal.Multiply(Decimal.Parse(t.Text), Decimal.Parse(txtTotal.Text));
                txtCTotal.Text = Total.ToString();
            }

            UpdateTotalPercepciones(g);
            
        }

        private static void UpdateTotalHours(Grid g, Decimal tH)
        {
            var stpGroups= (StackPanel)g.Parent;
            var stpContainer = (StackPanel)stpGroups.Parent;
            var stpHeader = VisualTreeHelper.GetChild(stpContainer, 1);
            var grdMiddle = VisualTreeHelper.GetChild(stpHeader, 1);
            var brdContainer = VisualTreeHelper.GetChild(grdMiddle, 6);
            var txt = VisualTreeHelper.GetChild(brdContainer, 0);

            TextBlock txtCantHr = (TextBlock)txt;
            txtCantHr.Text = tH.ToString();

        }

        private static void UpdateTotalPercepciones(Grid g)
        {
            Decimal TotalPer = 0;
            StackPanel stp = (StackPanel)g.Parent;
            List<Grid> lgrd = new List<Grid>();
            lgrd = stp.Children.Cast<Grid>().ToList();
            tH = 0;

            foreach (Grid grd in lgrd)
            {
                Border brdCTotal = (Border)grd.Children.Cast<UIElement>()
               .FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 6);

                Border brdCTH = (Border)grd.Children.Cast<UIElement>()
                .FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 6);

                TextBlock txtCTotal = (TextBlock)VisualTreeHelper.GetChild(brdCTotal, 0);
                TextBox txtCTH = (TextBox)VisualTreeHelper.GetChild(brdCTH, 0);

                //TextBlock txtCTotal = (TextBlock)grd.Children.Cast<UIElement>()
                //.FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 6);

                //TextBox txtCTH = (TextBox)grd.Children.Cast<UIElement>()
                //.FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 6);


                TotalPer += Decimal.Parse(txtCTotal.Text);
                if (txtCTH.Text == "")
                    txtCTH.Text = "";
                else
                    tH += Decimal.Parse(txtCTH.Text);
            }
            UpdateTotalHours(g, tH);
            //TextBox foundTextBox =  UIHelper.FindChild<TextBox>(Application.Current.MainWindow, "myTextBoxName");
            StackPanel MainPanel = (StackPanel)stp.Parent;
            var child = VisualTreeHelper.GetChild(MainPanel, 3);
            StackPanel subchild = (StackPanel)child;
            var dockpanel =VisualTreeHelper.GetChild(subchild, 1);
            DockPanel parentText = (DockPanel)dockpanel;
            var parentText2 = VisualTreeHelper.GetChild(parentText, 1);//stackPanel
            var border = VisualTreeHelper.GetChild(parentText2, 0);//first grid
            var grid = VisualTreeHelper.GetChild(border, 1);
            Border brd = (Border)grid;
            TextBlock txt = (TextBlock)brd.Child;
            txt.Text = TotalPer.ToString();
    
            //trae el texto de las deducciones para restarlo de las percepciones y obtener el total neto
            var secGrig = VisualTreeHelper.GetChild(parentText2, 1);//obtiene el segundo grid del stckpanel-Dockpanel
            var brdTxt = VisualTreeHelper.GetChild(secGrig, 1); //obtiene el borde donde esta el txt border>Grid2>stackpanel>Dockpanel
            TextBlock txtDeduc = (TextBlock) VisualTreeHelper.GetChild(brdTxt, 0); // obtiene el txt de las deducciones txt>border>Grid2>stackpanel>Dockpanel

            var brdTxtTotal = VisualTreeHelper.GetChild(border, 3);//obtiene el borde del text Total  border>Grid1>stackpanel>Dockpanel
            TextBlock txtTotalNeto = (TextBlock) VisualTreeHelper.GetChild(brdTxtTotal, 0);//obtiene el txt del Total Neto txt>border>Grid1>stackpanel>Dockpanel
            txtTotalNeto.Text = (Decimal.Parse(txt.Text)- Decimal.Parse(txtDeduc.Text)).ToString();

            var brdTxtCantW = VisualTreeHelper.GetChild(border, 2);//obtiene el borde del text Total  border>Grid1>stackpanel>Dockpanel
            TextBlock txtCantWord = (TextBlock)VisualTreeHelper.GetChild(brdTxtCantW, 0);//obtiene el txt del Total Neto txt>border>Grid1>stackpanel>Dockpanel
            txtCantWord.Text = "PERCEPCION NETA: " + DecimalToWords(Decimal.Parse(txtTotalNeto.Text));
           

        }

        public static string NumericToWords(int number)
       {
            if (number == 0)
                return "CERO";

            if (number < 0)
                return "MENOS " + NumericToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumericToWords(number / 1000000) + " MILLÓN ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += (number / 1000) == 1 ? "MIL " : NumericToWords(number / 1000) + " MIL ";
                number %= 1000;
            }
            if ((number / 100) == 1)
            {
                if (number == 100)
                    words += "CIEN";
                else words += (number / 100) > 1 ? NumericToWords(number / 100) + " CIENTO " : "CIENTO ";
                number %= 100;
            }
            if ((number / 100) > 1)
            {
                var hundredMap = new[] { "", "", "DOSC", "TRESC", "CUATROC", "QUIN", "SEISC", "SETEC", "OCHOC", "NOVEC" };
                if (number > 199)
                    words += hundredMap[number / 100] + "IENTOS ";
                else
                {
                    words += NumericToWords(number / 100) + " IENTOS ";
                }
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "CERO", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE", "VEINTE" };
                var tensMap = new[] { "CERO", "DIEZ", "VEINTI", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };

                if (number < 21)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if (number > 21 && number < 30)
                        words +=  unitsMap[number % 10];
                    else
                        if ((number % 10) > 0)
                        words += ((number / 10) > 2 ? " Y " : "") + unitsMap[number % 10];
                }
            }

            return words;
        }

        public static string DecimalToWords(decimal number)
        {
           if (number == 0)
                return "cero";

            if (number < 0)
                return "menos " + DecimalToWords(Math.Abs(number));

            string words = "";

            int intPortion = (int)number;
            decimal fraction = (number - intPortion) * 100;
            int decPortion = (int)fraction;

            words = NumericToWords(intPortion) + " PESOS";
            if (decPortion > 0)
            {
                words +=" "+ decPortion+ "/100 M.N.";
               
            }
            return words;
        }

    }
}
