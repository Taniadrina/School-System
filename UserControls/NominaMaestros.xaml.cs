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
    /// Lógica de interacción para NominaMaestros.xaml
    /// </summary>
    public partial class NominaMaestros : System.Windows.Controls.UserControl
    {
        public NominaMaestros()
        {
            InitializeComponent();
        }

        public NominaMaestros(LIVEX.UserControls.TableTeacherGroup ttg)
        {
            InitializeComponent();
            TeacherForm.FillHeaderNom(ttg, this);
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //var ParentPanelCollection = (dcpHeader.Parent as Panel).Children as UIElementCollection;
            //ParentPanelCollection.Clear();

            PrintDialog printDlg = new PrintDialog();

            #region/*Document initialization*/

            FlowDocument doc = new FlowDocument();
            doc.Name = "Nomina";
            doc.ColumnWidth = printDlg.PrintableAreaWidth;
            doc.PageHeight = Double.NaN;
            doc.PageWidth = Double.NaN;
            doc.TextAlignment = TextAlignment.Center;


            #endregion

           
            //StackPanel stpContainer = new StackPanel();
            //stpContainer.Width = 900;
            //stpContainer.Margin = new Thickness(20,10,20,10);
            

            

            #region/*Second Child, grid teacher salary base info*/
            StackPanel stkTeacherInfo = new StackPanel();
            stkTeacherInfo.Margin = new Thickness(60,10,60,8);
            Grid grdCycle = new Grid();

            //Columns
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            col1.Width = new GridLength(332);
            col2.Width = new GridLength(95);
            col3.Width = new GridLength(80);
            col4.Width = new GridLength(81);

            grdCycle.ColumnDefinitions.Add(col1);
            grdCycle.ColumnDefinitions.Add(col2);
            grdCycle.ColumnDefinitions.Add(col3);
            grdCycle.ColumnDefinitions.Add(col4);

            //Rows
            RowDefinition row0 = new RowDefinition();
            row0.Height = new GridLength(45);
            grdCycle.RowDefinitions.Add(row0);

            //Borders
            Border b1 = new Border();
            Border b2 = new Border();
            Border b3 = new Border();
            Border b4 = new Border();

            b1.BorderThickness = new Thickness(2, 2, 1, 0);
            b1.BorderBrush = Brushes.Black;

            b4.BorderBrush = b3.BorderBrush = b2.BorderBrush = b1.BorderBrush;
            b2.BorderThickness = new Thickness(0,2,1,0);
            b3.BorderThickness = new Thickness(0, 2, 1, 0);
            b4.BorderThickness = new Thickness(0, 2, 2, 0);

            Label lblTeacherName = new Label();
            lblTeacherName.Content = txtTeacherName.Text;
            lblTeacherName.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTeacherName.VerticalContentAlignment = VerticalAlignment.Center;
            lblTeacherName.FontWeight = FontWeights.Bold;
            lblTeacherName.FontFamily = new FontFamily("Calibri");
            lblTeacherName.FontSize = 11;
            b1.Child = lblTeacherName;
            Grid.SetRow(b1, 0);
            Grid.SetColumn(b1, 0);

            Label lblCicle = new Label();
            lblCicle.Content = txtCiclo.Text;
            lblCicle.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblCicle.VerticalContentAlignment = VerticalAlignment.Center;
            lblCicle.FontWeight = FontWeights.Bold;
            lblCicle.FontFamily = new FontFamily("Calibri");
            lblCicle.FontSize = 11;
            b2.Child = lblCicle;
            Grid.SetRow(b2, 0);
            Grid.SetColumn(b2, 1);

            Label lblDate = new Label();
            lblDate.Content = txtFechas.Text;
            lblDate.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblDate.VerticalContentAlignment = VerticalAlignment.Center;
            lblDate.FontWeight = FontWeights.Bold;
            lblDate.FontFamily = new FontFamily("Calibri");
            lblDate.FontSize = 11;
            b3.Child = lblDate;
            Grid.SetRow(b3, 0);
            Grid.SetColumn(b3, 2);

            Label lblYear = new Label();
            lblYear.Content = txtYear.Text;
            lblYear.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblYear.VerticalContentAlignment = VerticalAlignment.Center;
            lblYear.FontWeight = FontWeights.Bold;
            lblYear.FontFamily = new FontFamily("Calibri");
            lblYear.FontSize = 11;
            b4.Child = lblYear;
            Grid.SetRow(b4, 0);
            Grid.SetColumn(b4, 3);

            grdCycle.Children.Add(b1);
            grdCycle.Children.Add(b2);
            grdCycle.Children.Add(b3);
            grdCycle.Children.Add(b4);

            stkTeacherInfo.Children.Add(grdCycle);

            #endregion

            #region/*Second Child, grid Cicle info*/
            
            Grid grdCycleDates = new Grid();

            //Columns
            ColumnDefinition col11 = new ColumnDefinition();
            ColumnDefinition col12 = new ColumnDefinition();
            ColumnDefinition col13 = new ColumnDefinition();
            ColumnDefinition col14 = new ColumnDefinition();
            ColumnDefinition col15 = new ColumnDefinition();
            ColumnDefinition col16 = new ColumnDefinition();
            ColumnDefinition col17 = new ColumnDefinition();
            col11.Width = new GridLength(80);
            col12.Width = new GridLength(80);
            col13.Width = new GridLength(85);
            col14.Width = new GridLength(87);
            col15.Width = new GridLength(95);
            col16.Width = new GridLength(80);
            col17.Width = new GridLength(81);

            grdCycleDates.ColumnDefinitions.Add(col11);
            grdCycleDates.ColumnDefinitions.Add(col12);
            grdCycleDates.ColumnDefinitions.Add(col13);
            grdCycleDates.ColumnDefinitions.Add(col14);
            grdCycleDates.ColumnDefinitions.Add(col15);
            grdCycleDates.ColumnDefinitions.Add(col16);
            grdCycleDates.ColumnDefinitions.Add(col17);

            //Rows
            RowDefinition row10 = new RowDefinition();
            row10.Height = new GridLength(45);
            grdCycleDates.RowDefinitions.Add(row10);

            //Borders
            Border b11 = new Border();
            Border b12 = new Border();
            Border b13 = new Border();
            Border b14 = new Border();
            Border b15 = new Border();
            Border b16 = new Border();
            Border b17 = new Border();

            b11.BorderThickness = new Thickness(2, 1, 1, 0);

            b17.BorderBrush = b16.BorderBrush = b15.BorderBrush = b14.BorderBrush = b13.BorderBrush = b12.BorderBrush = b11.BorderBrush = b1.BorderBrush;
            b12.BorderThickness = new Thickness(0, 1, 1, 0);
            b13.BorderThickness = new Thickness(0, 1, 1, 0);
            b14.BorderThickness = new Thickness(0, 1, 1, 0);
            b15.BorderThickness = new Thickness(0, 1, 1, 0);
            b16.BorderThickness = new Thickness(0, 1, 1, 0);
            b17.BorderThickness = new Thickness(0, 1, 2, 0);

            Label lblAltatxt = new Label();
            lblAltatxt.Content = "ALTA";
            lblAltatxt.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblAltatxt.VerticalContentAlignment = VerticalAlignment.Center;
            lblAltatxt.FontWeight = FontWeights.Bold;
            lblAltatxt.FontFamily = new FontFamily("Calibri");
            lblAltatxt.FontSize = 11;
            b11.Child = lblAltatxt;
            Grid.SetRow(b11, 0);
            Grid.SetColumn(b11, 0);

            Label lblNew = new Label();
            lblNew.Content = txtAlta.Text;
            lblNew.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblNew.VerticalContentAlignment = VerticalAlignment.Center;
            lblNew.FontWeight = FontWeights.Bold;
            lblNew.FontFamily = new FontFamily("Calibri");
            lblNew.FontSize = 11;
            b12.Child = lblNew;
            Grid.SetRow(b12, 0);
            Grid.SetColumn(b12, 1);

            Label lblNoWeeks = new Label();
            lblNoWeeks.Content = txtNoSemanas.Text;
            lblNoWeeks.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblNoWeeks.VerticalContentAlignment = VerticalAlignment.Center;
            lblNoWeeks.FontWeight = FontWeights.Bold;
            lblNoWeeks.FontFamily = new FontFamily("Calibri");
            lblNoWeeks.FontSize = 11;
            b13.Child = lblNoWeeks;
            Grid.SetRow(b13, 0);
            Grid.SetColumn(b13, 2);

            Label lblStartDate = new Label();
            lblStartDate.Content = txtFechaInicio.Text;
            lblStartDate.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblStartDate.VerticalContentAlignment = VerticalAlignment.Center;
            lblStartDate.FontWeight = FontWeights.Bold;
            lblStartDate.FontFamily = new FontFamily("Calibri");
            lblStartDate.FontSize = 11;
            b14.Child = lblStartDate;
            Grid.SetRow(b14, 0);
            Grid.SetColumn(b14, 3);

            Label lblEndDate = new Label();
            lblEndDate.Content = txtFechaFin.Text;
            lblEndDate.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblEndDate.VerticalContentAlignment = VerticalAlignment.Center;
            lblEndDate.FontWeight = FontWeights.Bold;
            lblEndDate.FontFamily = new FontFamily("Calibri");
            lblEndDate.FontSize = 11;
            b15.Child = lblEndDate;
            Grid.SetRow(b15, 0);
            Grid.SetColumn(b15, 4);

            Label lblTotalHrtxt = new Label();
            lblTotalHrtxt.Content = "TOTAL HORAS";
            lblTotalHrtxt.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTotalHrtxt.VerticalContentAlignment = VerticalAlignment.Center;
            lblTotalHrtxt.FontWeight = FontWeights.Bold;
            lblTotalHrtxt.FontFamily = new FontFamily("Calibri");
            lblTotalHrtxt.FontSize = 11;
            b16.Child = lblTotalHrtxt;
            Grid.SetRow(b16, 0);
            Grid.SetColumn(b16, 5);

            Label lblTotalHours = new Label();
            lblTotalHours.Content = txtTotalHoras.Text;
            lblTotalHours.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTotalHours.VerticalContentAlignment = VerticalAlignment.Center;
            lblTotalHours.FontWeight = FontWeights.Bold;
            lblTotalHours.FontFamily = new FontFamily("Calibri");
            lblTotalHours.FontSize = 11;
            b17.Child = lblTotalHours;
            Grid.SetRow(b17, 0);
            Grid.SetColumn(b17, 6);

            grdCycleDates.Children.Add(b11);
            grdCycleDates.Children.Add(b12);
            grdCycleDates.Children.Add(b13);
            grdCycleDates.Children.Add(b14);
            grdCycleDates.Children.Add(b15);
            grdCycleDates.Children.Add(b16);
            grdCycleDates.Children.Add(b17);

            stkTeacherInfo.Children.Add(grdCycleDates);

            #endregion

            #region/*Second Child, grid Cicle info*/

            Grid grdTabulator = new Grid();

            //Columns
            ColumnDefinition col21 = new ColumnDefinition();
            ColumnDefinition col22 = new ColumnDefinition();
            ColumnDefinition col23 = new ColumnDefinition();
            ColumnDefinition col24 = new ColumnDefinition();
            ColumnDefinition col25 = new ColumnDefinition();
            ColumnDefinition col26 = new ColumnDefinition();
            col21.Width = new GridLength(160);
            col22.Width = new GridLength(85);
            col23.Width = new GridLength(87);
            col24.Width = new GridLength(95);
            col25.Width = new GridLength(80);
            col26.Width = new GridLength(81);

            grdTabulator.ColumnDefinitions.Add(col21);
            grdTabulator.ColumnDefinitions.Add(col22);
            grdTabulator.ColumnDefinitions.Add(col23);
            grdTabulator.ColumnDefinitions.Add(col24);
            grdTabulator.ColumnDefinitions.Add(col25);
            grdTabulator.ColumnDefinitions.Add(col26);

            //Rows
            RowDefinition row20 = new RowDefinition();
            row20.Height = new GridLength(35);
            grdTabulator.RowDefinitions.Add(row20);

            //Borders
            Border b21 = new Border();
            Border b22 = new Border();
            Border b23 = new Border();
            Border b24 = new Border();
            Border b25 = new Border();
            Border b26 = new Border();

            b21.BorderThickness = new Thickness(2, 1, 1, 2);

            b26.BorderBrush = b25.BorderBrush = b24.BorderBrush = b23.BorderBrush = b22.BorderBrush = b21.BorderBrush = b1.BorderBrush;
            b22.BorderThickness = new Thickness(0, 1, 1, 2);
            b23.BorderThickness = new Thickness(0, 1, 1, 2);
            b24.BorderThickness = new Thickness(0, 1, 1, 2);
            b25.BorderThickness = new Thickness(0, 1, 1, 2);
            b26.BorderThickness = new Thickness(0, 1, 2, 2);

            Label lblTabulatortxt = new Label();
            lblTabulatortxt.Content = "TABULADOR";
            lblTabulatortxt.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTabulatortxt.VerticalContentAlignment = VerticalAlignment.Center;
            lblTabulatortxt.FontWeight = FontWeights.Bold;
            lblTabulatortxt.FontFamily = new FontFamily("Calibri");
            lblTabulatortxt.FontSize = 11;
            b21.Child = lblTabulatortxt;
            Grid.SetRow(b21, 0);
            Grid.SetColumn(b21, 0);

            Label lblTOEFL = new Label();
            lblTOEFL.Content = txtTOEFL.Text;
            lblTOEFL.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTOEFL.VerticalContentAlignment = VerticalAlignment.Center;
            lblTOEFL.FontWeight = FontWeights.Bold;
            lblTOEFL.FontFamily = new FontFamily("Calibri");
            lblTOEFL.FontSize = 11;
            lblTOEFL.Foreground = txtTOEFL.Foreground;
            b22.Child = lblTOEFL;
            Grid.SetRow(b22, 0);
            Grid.SetColumn(b22, 1);

            Label lblExp = new Label();
            lblExp.Content = txtExp.Text;
            lblExp.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblExp.VerticalContentAlignment = VerticalAlignment.Center;
            lblExp.FontWeight = FontWeights.Bold;
            lblExp.FontFamily = new FontFamily("Calibri");
            lblExp.FontSize = 11;
            lblExp.Foreground = txtExp.Foreground;
            b23.Child = lblExp;
            Grid.SetRow(b23, 0);
            Grid.SetColumn(b23, 2);

            Label lblTra = new Label();
            lblTra.Content = txtTra.Text;
            lblTra.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblTra.VerticalContentAlignment = VerticalAlignment.Center;
            lblTra.FontWeight = FontWeights.Bold;
            lblTra.FontFamily = new FontFamily("Calibri");
            lblTra.FontSize = 10;
            lblTra.Foreground = txtTra.Foreground;
            b24.Child = lblTra;
            Grid.SetRow(b24, 0);
            Grid.SetColumn(b24, 3);

            Label lblLic = new Label();
            lblLic.Content = txtLic.Text;
            lblLic.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblLic.VerticalContentAlignment = VerticalAlignment.Center;
            lblLic.FontWeight = FontWeights.Bold;
            lblLic.FontFamily = new FontFamily("Calibri");
            lblLic.FontSize = 11;
            lblLic.Foreground = txtLic.Foreground;
            b25.Child = lblLic;
            Grid.SetRow(b25, 0);
            Grid.SetColumn(b25, 4);

            Label lblSalary_base = new Label();
            lblSalary_base.Content = txtSalario_Base.Text;
            lblSalary_base.HorizontalContentAlignment = HorizontalAlignment.Center;
            lblSalary_base.VerticalContentAlignment = VerticalAlignment.Center;
            lblSalary_base.FontWeight = FontWeights.Bold;
            lblSalary_base.FontFamily = new FontFamily("Calibri");
            lblSalary_base.FontSize = 11;
            b26.Child = lblSalary_base;
            Grid.SetRow(b26, 0);
            Grid.SetColumn(b26, 5);

            grdTabulator.Children.Add(b21);
            grdTabulator.Children.Add(b22);
            grdTabulator.Children.Add(b23);
            grdTabulator.Children.Add(b24);
            grdTabulator.Children.Add(b25);
            grdTabulator.Children.Add(b26);
            

            stkTeacherInfo.Children.Add(grdTabulator);

            #endregion

            #region/*Third Child, Grid of Groups*/
            //StackPanel stkGroups  = new StackPanel();
            //stkGroups.Margin = new Thickness(60, 10, 60, 8);

            Decimal decPag = Decimal.Divide(stkContainer.Children.Count, 5);
            Decimal numPages = Math.Ceiling( decPag );


            int[] numGroupsByPage = new int[(int)numPages];
            int intPortion = (int)decPag;
            decimal fraction = (decPag - intPortion);

            for (int z = 0; z < intPortion; z++)
            {
                numGroupsByPage[z] = 5;
                
            }

            if(fraction > 0)
                numGroupsByPage[numGroupsByPage.Count()-1] = (int)Decimal.Multiply(fraction, 5);
            //int f = (int)Decimal.Multiply(fraction,5);


            //numGroupsByPage[0] = intPortion * 5;
            //numGroupsByPage[1] = f;

            int gr = 0;

            for (int i = 0; i < numPages; i++)
            {
                #region /*General StackPanel container*/

                StackPanel stpContainer = new StackPanel();
                stpContainer.Width = 900;
                stpContainer.Margin = new Thickness(20, 10, 20, 10);
                #endregion

                #region/*First Child of the container, Logo and invoice data*/
                DockPanel dkHeaderLogo = new DockPanel();
                dkHeaderLogo.Margin = new Thickness(5, 5, 5, 5);

                Image imLogo = new Image();
                imLogo.Source = new BitmapImage(new Uri("pack://application:,,,/LIVEX;component/Images/Icon/logo.png"));
                imLogo.Width = 140;
                imLogo.Margin = new Thickness(0, 0, 10, 0);

                StackPanel stkHeaderLogo = new StackPanel();
                StackPanel stkHeaderLogoEnd = new StackPanel();

                stkHeaderLogoEnd.Margin = new Thickness(35, 16, 0, 0);

                TextBlock txtheaderL1 = new TextBlock();
                txtheaderL1.Text = "CONNECT EDUCATION";

                TextBlock txtheaderL2 = new TextBlock();
                txtheaderL2.Text = "KARLA PATRICIA ELIAS GUTIERREZ";

                TextBlock txtheaderL3 = new TextBlock();
                txtheaderL3.Text = "FRANCISCO J. MUJICA 765 ";

                TextBlock txtheaderL4 = new TextBlock();
                txtheaderL4.Text = "JARDINES ALCALDE";

                TextBlock txtheaderL5 = new TextBlock();
                txtheaderL5.Text = "CP. 44298";
                txtheaderL5.Margin = new Thickness(20, 33, 0, 0);

                TextBlock txtheaderL6 = new TextBlock();
                txtheaderL6.Text = "EIGK870426A27";

                TextBlock txtheaderL7 = new TextBlock();
                txtheaderL7.Text = "GUADALAJARA, JALISCO.";

                txtheaderL1.FontFamily = new FontFamily("Calibri");
                txtheaderL1.FontSize = 11;

                txtheaderL7.FontFamily = txtheaderL6.FontFamily = txtheaderL5.FontFamily = txtheaderL4.FontFamily = txtheaderL3.FontFamily = txtheaderL2.FontFamily = txtheaderL1.FontFamily;
                txtheaderL7.FontSize = txtheaderL6.FontSize = txtheaderL5.FontSize = txtheaderL4.FontSize = txtheaderL3.FontSize = txtheaderL2.FontSize = txtheaderL1.FontSize;

                stkHeaderLogo.Children.Add(txtheaderL1);
                stkHeaderLogo.Children.Add(txtheaderL2);
                stkHeaderLogo.Children.Add(txtheaderL3);
                stkHeaderLogo.Children.Add(txtheaderL4);
                stkHeaderLogoEnd.Children.Add(txtheaderL6);
                stkHeaderLogoEnd.Children.Add(txtheaderL7);


                dkHeaderLogo.Children.Add(imLogo);
                dkHeaderLogo.Children.Add(stkHeaderLogo);
                dkHeaderLogo.Children.Add(txtheaderL5);
                dkHeaderLogo.Children.Add(stkHeaderLogoEnd);
                /*End of invoice header*/
                #endregion

                StackPanel stkGroups = new StackPanel();
                stkGroups.Margin = new Thickness(60, 10, 60, 8);

                
                //foreach (Grid gGroups in stkContainer.Children)
                for (int y=0; y< numGroupsByPage[i]; y++)
                {
                        Grid gGroups = new Grid();
                        gGroups = (Grid)stkContainer.Children[gr];
                        Grid grdGroup = new Grid();
                        grdGroup.Margin = gGroups.Margin;

                        #region/*Header Row*/
                        //Columns
                        ColumnDefinition gridcol1 = new ColumnDefinition();
                        ColumnDefinition gridcol2 = new ColumnDefinition();
                        ColumnDefinition gridcol3 = new ColumnDefinition();
                        ColumnDefinition gridcol4 = new ColumnDefinition();
                        ColumnDefinition gridcol5 = new ColumnDefinition();
                        ColumnDefinition gridcol6 = new ColumnDefinition();
                        ColumnDefinition gridcol7 = new ColumnDefinition();
                        gridcol1.Width = new GridLength(80);
                        gridcol2.Width = new GridLength(80);
                        gridcol3.Width = new GridLength(85);
                        gridcol4.Width = new GridLength(87);
                        gridcol5.Width = new GridLength(95);
                        gridcol6.Width = new GridLength(80);
                        gridcol7.Width = new GridLength(81);
                        grdGroup.ColumnDefinitions.Add(gridcol1);
                        grdGroup.ColumnDefinitions.Add(gridcol2);
                        grdGroup.ColumnDefinitions.Add(gridcol3);
                        grdGroup.ColumnDefinitions.Add(gridcol4);
                        grdGroup.ColumnDefinitions.Add(gridcol5);
                        grdGroup.ColumnDefinitions.Add(gridcol6);
                        grdGroup.ColumnDefinitions.Add(gridcol7);

                        //Row
                        RowDefinition gridrow1 = new RowDefinition();
                        RowDefinition gridrow2 = new RowDefinition();
                        gridrow2.Height = new GridLength(48);
                        RowDefinition gridrow3 = new RowDefinition();
                        grdGroup.RowDefinitions.Add(gridrow1);
                        grdGroup.RowDefinitions.Add(gridrow2);
                        grdGroup.RowDefinitions.Add(gridrow3);

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

                        Border brdGrupo = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 0);
                        TextBlock txtGrupo = (TextBlock)brdGrupo.Child;
                        Label lblGrupo = new Label();
                        lblGrupo.Content = txtGrupo.Text;
                        lblGrupo.VerticalAlignment = VerticalAlignment.Center;
                        lblGrupo.FontWeight = FontWeights.Bold;
                        lblGrupo.FontFamily = new FontFamily("Calibri");
                        lblGrupo.FontSize = 11;
                        myborderGrupo.Child = lblGrupo;
                        Grid.SetRow(myborderGrupo, 0);
                        Grid.SetColumn(myborderGrupo, 0);


                        Label lblHorario = new Label();
                        lblHorario.Content = "HORARIO";
                        lblHorario.FontWeight = FontWeights.Bold;
                        lblHorario.VerticalAlignment = VerticalAlignment.Center;
                        lblHorario.FontFamily = new FontFamily("Calibri");
                        lblHorario.FontSize = 11;
                        myborderHorario.Child = lblHorario;
                        Grid.SetRow(myborderHorario, 0);
                        Grid.SetColumn(myborderHorario, 1);

                        Border brdHr = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 2);
                        TextBlock txtHr = (TextBlock)brdHr.Child;
                        Label lblHr = new Label();
                        lblHr.Content = txtHr.Text;
                        lblHr.HorizontalAlignment = HorizontalAlignment.Center;
                        lblHr.FontWeight = FontWeights.Bold;
                        lblHr.FontFamily = new FontFamily("Calibri");
                        lblHr.FontSize = 11;
                        myborderHr.Child = lblHr;
                        Grid.SetRow(myborderHr, 0);
                        Grid.SetColumn(myborderHr, 2);

                        Label lblLevel = new Label();
                        lblLevel.Content = "NIVEL";
                        lblLevel.HorizontalAlignment = HorizontalAlignment.Center;
                        lblLevel.FontWeight = FontWeights.Bold;
                        lblLevel.FontFamily = new FontFamily("Calibri");
                        lblLevel.FontSize = 11;
                        myborderLevel.Child = lblLevel;
                        Grid.SetRow(myborderLevel, 0);
                        Grid.SetColumn(myborderLevel, 3);

                        Border brdNivel = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 4);
                        TextBlock txtNivel = (TextBlock)brdNivel.Child;
                        Label lblNivel = new Label();
                        lblNivel.Content = txtNivel.Text;
                        lblNivel.HorizontalAlignment = HorizontalAlignment.Center;
                        lblNivel.FontWeight = FontWeights.Bold;
                        lblNivel.FontFamily = new FontFamily("Calibri");
                        lblNivel.FontSize = 11;
                        myborderNivel.Child = lblNivel;
                        Grid.SetRow(myborderNivel, 0);
                        Grid.SetColumn(myborderNivel, 4);

                        Label lblHoras = new Label();
                        lblHoras.Content = "HORAS";
                        lblHoras.FontWeight = FontWeights.Bold;
                        lblHoras.HorizontalAlignment = HorizontalAlignment.Center;
                        lblHoras.FontFamily = new FontFamily("Calibri");
                        lblHoras.FontSize = 11;
                        myborderHoras.Child = lblHoras;
                        Grid.SetRow(myborderHoras, 0);
                        Grid.SetColumn(myborderHoras, 5);

                        Border brdHrs = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 6);
                        TextBox txtHrs = (TextBox)brdHrs.Child;
                        Label lblHrs = new Label();
                        lblHrs.Content = txtHrs.Text;
                        lblHrs.HorizontalAlignment = HorizontalAlignment.Center;
                        lblHrs.FontWeight = FontWeights.Bold;
                        lblHrs.FontFamily = new FontFamily("Calibri");
                        lblHrs.FontSize = 11;
                        myborderHrs.Child = lblHrs;
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

                        #endregion//
                        #region               /*Middle Row*/

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
                        txtAlumnos.FontFamily = new FontFamily("Calibri");
                        txtAlumnos.FontSize = 11;
                        myborderAlumnos.Child = txtAlumnos;
                        Grid.SetRow(myborderAlumnos, 1);
                        Grid.SetColumn(myborderAlumnos, 0);

                        TextBlock txtSalBase = new TextBlock();
                        txtSalBase.Text = "Salario base";
                        txtSalBase.TextAlignment = TextAlignment.Center;
                        txtSalBase.FontFamily = new FontFamily("Calibri");
                        txtSalBase.FontSize = 11;
                        myborder_SalBase.Child = txtSalBase;
                        Grid.SetRow(myborder_SalBase, 1);
                        Grid.SetColumn(myborder_SalBase, 1);

                        TextBlock txtComAl = new TextBlock();
                        txtComAl.Text = "Comision por\nAlumno";
                        txtComAl.TextAlignment = TextAlignment.Center;
                        txtComAl.FontFamily = new FontFamily("Calibri");
                        txtComAl.FontSize = 11;
                        myborderComAl.Child = txtComAl;
                        Grid.SetRow(myborderComAl, 1);
                        Grid.SetColumn(myborderComAl, 2);

                        TextBlock txtBAsiP = new TextBlock();
                        txtBAsiP.Text = "Bono\nAsistencia y\npuntualidad";
                        txtBAsiP.TextAlignment = TextAlignment.Center;
                        txtBAsiP.FontFamily = new FontFamily("Calibri");
                        txtBAsiP.FontSize = 11;
                        myborderBAsiP.Child = txtBAsiP;
                        Grid.SetRow(myborderBAsiP, 1);
                        Grid.SetColumn(myborderBAsiP, 3);

                        TextBlock txtBExe = new TextBlock();
                        txtBExe.Text = "Bono  de\nExcelencia ";
                        txtBExe.TextAlignment = TextAlignment.Center;
                        txtBExe.FontFamily = new FontFamily("Calibri");
                        txtBExe.FontSize = 11;
                        myborderBExe.Child = txtBExe;
                        Grid.SetRow(myborderBExe, 1);
                        Grid.SetColumn(myborderBExe, 4);

                        TextBlock txtTotByHr = new TextBlock();
                        txtTotByHr.Text = "TOTAL POR\nHORA";
                        txtTotByHr.TextAlignment = TextAlignment.Center;
                        txtTotByHr.FontFamily = new FontFamily("Calibri");
                        txtTotByHr.FontSize = 11;
                        myborderTotByHr.Child = txtTotByHr;
                        Grid.SetRow(myborderTotByHr, 1);
                        Grid.SetColumn(myborderTotByHr, 5);

                        TextBlock txtTot = new TextBlock();
                        txtTot.Text = "TOTAL";
                        txtTot.TextAlignment = TextAlignment.Center;
                        txtTot.FontFamily = new FontFamily("Calibri");
                        txtTot.FontSize = 11;
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
                        #endregion
                        #region/*Last Row*/
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

                        Border brdNoAlumnos = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 0);
                        TextBlock txtNoAlumnos = (TextBlock)brdNoAlumnos.Child;
                        Label lblNoAlumnos = new Label();
                        lblNoAlumnos.Content = txtNoAlumnos.Text;
                        lblNoAlumnos.VerticalContentAlignment = VerticalAlignment.Center;
                        lblNoAlumnos.FontFamily = new FontFamily("Calibri");
                        lblNoAlumnos.FontSize = 11;
                        myborderNoAlumnos.Child = lblNoAlumnos;
                        Grid.SetRow(myborderNoAlumnos, 2);
                        Grid.SetColumn(myborderNoAlumnos, 0);

                        Border brdCSalBase = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 1);
                        TextBlock txtCSalBase = (TextBlock)brdCSalBase.Child;
                        Label lblCSalBase = new Label();
                        lblCSalBase.Content = txtCSalBase.Text;
                        lblCSalBase.VerticalContentAlignment = VerticalAlignment.Center;
                        lblCSalBase.FontFamily = new FontFamily("Calibri");
                        lblCSalBase.FontSize = 11;
                        myborderSalBase.Child = lblCSalBase;
                        Grid.SetRow(myborderSalBase, 2);
                        Grid.SetColumn(myborderSalBase, 1);

                        Border brdCComAl = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 2);
                        TextBlock txtCComAl = (TextBlock)brdCComAl.Child;
                        Label lblCComAl = new Label();
                        lblCComAl.Content = txtCComAl.Text;
                        lblCComAl.VerticalContentAlignment = VerticalAlignment.Center;
                        lblCComAl.FontFamily = new FontFamily("Calibri");
                        lblCComAl.FontSize = 11;
                        myborderCComAl.Child = lblCComAl;
                        Grid.SetRow(myborderCComAl, 2);
                        Grid.SetColumn(myborderCComAl, 2);

                        Border brdCBAsiP = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 3);
                        TextBlock txtCBAsiP = (TextBlock)brdCBAsiP.Child;
                        Label lblCBAsiP = new Label();
                        lblCBAsiP.VerticalContentAlignment = VerticalAlignment.Center;
                        lblCBAsiP.Content = txtCBAsiP.Text;
                        lblCBAsiP.FontFamily = new FontFamily("Calibri");
                        lblCBAsiP.FontSize = 11;
                        myborderCBAsiP.Child = lblCBAsiP;
                        Grid.SetRow(myborderCBAsiP, 2);
                        Grid.SetColumn(myborderCBAsiP, 3);

                        Border brdCBExe = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 4);
                        TextBlock txtCBExe = (TextBlock)brdCBExe.Child;
                        Label lblCBExe = new Label();
                        lblCBExe.Content = txtCBExe.Text;
                        lblCBExe.VerticalContentAlignment = VerticalAlignment.Center;
                        lblCBExe.FontFamily = new FontFamily("Calibri");
                        lblCBExe.FontSize = 11;
                        myborderCBExe.Child = lblCBExe;
                        Grid.SetRow(myborderCBExe, 2);
                        Grid.SetColumn(myborderCBExe, 4);

                        Border brdCTotByHr = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 5);
                        TextBlock txtCTotByHr = (TextBlock)brdCTotByHr.Child;
                        Label lblCTotByHr = new Label();
                        lblCTotByHr.Content = txtCTotByHr.Text;
                        lblCTotByHr.VerticalContentAlignment = VerticalAlignment.Center;
                        lblCTotByHr.FontFamily = new FontFamily("Calibri");
                        lblCTotByHr.FontSize = 11;
                        myborderCTotByHr.Child = lblCTotByHr;
                        Grid.SetRow(myborderCTotByHr, 2);
                        Grid.SetColumn(myborderCTotByHr, 5);

                        Border brdcTot = (Border)gGroups.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == 2 && Grid.GetColumn(x) == 6);
                        TextBlock txtcTot = (TextBlock)brdcTot.Child;
                        Label lblcTot = new Label();
                        lblcTot.Content = txtcTot.Text;
                        lblcTot.VerticalContentAlignment = VerticalAlignment.Center;
                        lblcTot.FontWeight = FontWeights.Bold;
                        lblcTot.FontFamily = new FontFamily("Calibri");
                        lblcTot.FontSize = 11;
                        mybordercTot.Child = lblcTot;
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
                        #endregion

                        stkGroups.Children.Add(grdGroup);
                    gr++;
                }
                
                stpContainer.Children.Add(dkHeaderLogo); //Prints header in each page
                if (i==0)
                {
                    stpContainer.Children.Add(stkTeacherInfo);
                }
                
                stpContainer.Children.Add(stkGroups);

                Section sec = new Section();
                BlockUIContainer blockCont = new BlockUIContainer();

                blockCont.Child = stpContainer;

                sec.Blocks.Add(blockCont);

                doc.Blocks.Add(sec);
            }
            #endregion

            //stpContainer.Children.Add(dkHeaderLogo);
            //stpContainer.Children.Add(stkTeacherInfo);
            //stpContainer.Children.Add(stkGroups);

            //Section sec = new Section();
            //BlockUIContainer blockCont = new BlockUIContainer();

            //blockCont.Child = stpContainer;

            //sec.Blocks.Add(blockCont);

            //doc.Blocks.Add(sec);

            #region/*Footer section*/
            Section footerSec = new Section();
            BlockUIContainer blcFooter = new BlockUIContainer();
            StackPanel stpFooterContainer = new StackPanel();
            StackPanel stpQltyHeader = new StackPanel();

            stpFooterContainer.Margin = new Thickness(80, 10, 60, 8);

            #region /*Quality Grid Header*/
                        Grid grdQltyTitle = new Grid();

                        ColumnDefinition colTitle1 = new ColumnDefinition();
                        ColumnDefinition colTitle2 = new ColumnDefinition();
                        ColumnDefinition colTitle3 = new ColumnDefinition();

                        colTitle1.Width = new GridLength(120);
                        colTitle2.Width = new GridLength(100);
                        colTitle3.Width = new GridLength(100);
                        grdQltyTitle.ColumnDefinitions.Add(colTitle1);
                        grdQltyTitle.ColumnDefinitions.Add(colTitle2);
                        grdQltyTitle.ColumnDefinitions.Add(colTitle3);

                        RowDefinition rowTitle = new RowDefinition();
                        grdQltyTitle.RowDefinitions.Add(rowTitle);

                        Border brdTitle1 = new Border();
                        Border brdTitle2 = new Border();
                        Border brdTitle3 = new Border();

                        brdTitle1.BorderBrush = Brushes.Black;
                        brdTitle3.BorderBrush = brdTitle2.BorderBrush = brdTitle1.BorderBrush;

                        brdTitle1.BorderThickness = new Thickness(2, 2, 1, 0);
                        brdTitle2.BorderThickness = new Thickness(0, 2, 1, 0);
                        brdTitle3.BorderThickness = new Thickness(0, 2, 2, 0);

                        Label lblQtyCtrl = new Label();
                        lblQtyCtrl.Content = "QUALITY CONTROL";
                        lblQtyCtrl.FontWeight = FontWeights.Bold;
                        lblQtyCtrl.HorizontalAlignment = HorizontalAlignment.Center;
                        lblQtyCtrl.FontFamily = new FontFamily("Calibri");
                        lblQtyCtrl.FontSize = 11;
                        brdTitle1.Child = lblQtyCtrl;
                        Grid.SetRow(brdTitle1, 0);
                        Grid.SetColumn(brdTitle1, 0);

                        Label lblVoBo = new Label();
                        lblVoBo.Content = "VoBo";
                        lblVoBo.FontWeight = FontWeights.Bold;
                        lblVoBo.HorizontalAlignment = HorizontalAlignment.Center;
                        lblVoBo.FontFamily = new FontFamily("Calibri");
                        lblVoBo.FontSize = 11;
                        brdTitle2.Child = lblVoBo;
                        Grid.SetRow(brdTitle2, 0);
                        Grid.SetColumn(brdTitle2, 1);

                        Label lblStdVoBo = new Label();
                        lblStdVoBo.Content = "STUDENT VoBo";
                        lblStdVoBo.FontWeight = FontWeights.Bold;
                        lblStdVoBo.HorizontalAlignment = HorizontalAlignment.Center;
                        lblStdVoBo.FontFamily = new FontFamily("Calibri");
                        lblStdVoBo.FontSize = 11;
                        brdTitle3.Child = lblStdVoBo;
                        Grid.SetRow(brdTitle3, 0);
                        Grid.SetColumn(brdTitle3, 2);

                        grdQltyTitle.Children.Add(brdTitle1);
                        grdQltyTitle.Children.Add(brdTitle2);
                        grdQltyTitle.Children.Add(brdTitle3);
            #endregion

            #region /*Quality Grid - values*/
            Grid grdQltyValues = new Grid();

            ColumnDefinition colVal1 = new ColumnDefinition();
            ColumnDefinition colVal2 = new ColumnDefinition();
            ColumnDefinition colVal3 = new ColumnDefinition();
            ColumnDefinition colVal4 = new ColumnDefinition();

            colVal1.Width = new GridLength(60);
            colVal2.Width = new GridLength(60);
            colVal3.Width = new GridLength(100);
            colVal4.Width = new GridLength(100);
            grdQltyValues.ColumnDefinitions.Add(colVal1);
            grdQltyValues.ColumnDefinitions.Add(colVal2);
            grdQltyValues.ColumnDefinitions.Add(colVal3);
            grdQltyValues.ColumnDefinitions.Add(colVal4);

            RowDefinition rowVal = new RowDefinition();
            grdQltyValues.RowDefinitions.Add(rowVal);

            Border brdVal1 = new Border();
            Border brdVal2 = new Border();
            Border brdVal3 = new Border();
            Border brdVal4 = new Border();

            brdVal1.BorderBrush = Brushes.Black;
            brdVal4.BorderBrush = brdVal3.BorderBrush = brdVal2.BorderBrush = brdVal1.BorderBrush;

            brdVal1.BorderThickness = new Thickness(2, 1, 1, 2);
            brdVal2.BorderThickness = new Thickness(0, 1, 1, 2);
            brdVal3.BorderThickness = new Thickness(0, 1, 1, 2);
            brdVal4.BorderThickness = new Thickness(0, 1, 2, 2);

            Label lblVQtyCtrl = new Label();
            lblVQtyCtrl.Content = txtQACtrl1.Text;
            lblVQtyCtrl.FontWeight = FontWeights.Bold;
            lblVQtyCtrl.HorizontalAlignment = HorizontalAlignment.Center;
            lblVQtyCtrl.FontFamily = new FontFamily("Calibri");
            lblVQtyCtrl.FontSize = 11;
            brdVal1.Child = lblVQtyCtrl;
            Grid.SetRow(brdVal1, 0);
            Grid.SetColumn(brdVal1, 0);

            Label lblQtyCtrl2 = new Label();
            lblQtyCtrl2.Content = txtQACtrl2.Text;
            lblQtyCtrl2.FontWeight = FontWeights.Bold;
            lblQtyCtrl2.HorizontalAlignment = HorizontalAlignment.Center;
            lblQtyCtrl2.FontFamily = new FontFamily("Calibri");
            lblQtyCtrl2.FontSize = 11;
            brdVal2.Child = lblQtyCtrl2;
            Grid.SetRow(brdVal2, 0);
            Grid.SetColumn(brdVal2, 1);

            Label lblVVoBo = new Label();
            lblVVoBo.Content = txtVoBo.Text;
            lblVVoBo.FontWeight = FontWeights.Bold;
            lblVVoBo.HorizontalAlignment = HorizontalAlignment.Center;
            lblVVoBo.FontFamily = new FontFamily("Calibri");
            lblVVoBo.FontSize = 11;
            brdVal3.Child = lblVVoBo;
            Grid.SetRow(brdVal3, 0);
            Grid.SetColumn(brdVal3, 2);

            Label lblVVoBoStd = new Label();
            lblVVoBoStd.Content = txtVoBoStd.Text;
            lblVVoBoStd.FontWeight = FontWeights.Bold;
            lblVVoBoStd.HorizontalAlignment = HorizontalAlignment.Center;
            lblVVoBoStd.FontFamily = new FontFamily("Calibri");
            lblVVoBoStd.FontSize = 11;
            brdVal4.Child = lblVVoBoStd;
            Grid.SetRow(brdVal4, 0);
            Grid.SetColumn(brdVal4, 3);


            grdQltyValues.Children.Add(brdVal1);
            grdQltyValues.Children.Add(brdVal2);
            grdQltyValues.Children.Add(brdVal3);
            grdQltyValues.Children.Add(brdVal4);

            stpQltyHeader.Children.Add(grdQltyTitle);
            stpQltyHeader.Children.Add(grdQltyValues);
            #endregion

            #region/*Total grid*/
            DockPanel dcpTotalContainer = new DockPanel();
            Border brdTeacherName = new Border();
            StackPanel stpTeacherTotal = new StackPanel();

            dcpTotalContainer.Margin = new Thickness(0, 10, 0, 0);

            Label lblTotalTName = new Label();
            lblTotalTName.Content = txtTName.Text;
            lblTotalTName.FontWeight = FontWeights.Bold;
            lblTotalTName.HorizontalAlignment = HorizontalAlignment.Center;
            lblTotalTName.FontFamily = new FontFamily("Calibri");
            lblTotalTName.FontSize = 11;
            brdTeacherName.Child = lblTotalTName;
            brdTeacherName.BorderBrush = Brushes.Black;
            brdTeacherName.BorderThickness = new Thickness(2,2,1,2);
           
            
            Grid grdTotalHeader = new Grid();
            Grid grdTotalValues = new Grid();

           // #region/*Total Header Grid*/
            ColumnDefinition colH1 = new ColumnDefinition();
            ColumnDefinition colH2 = new ColumnDefinition();
            ColumnDefinition colH3 = new ColumnDefinition();
            ColumnDefinition colH4 = new ColumnDefinition();
            colH1.Width = new GridLength(80);
            colH2.Width = new GridLength(80);
            colH3.Width = new GridLength(280);
            colH4.Width = new GridLength(77);
            grdTotalHeader.ColumnDefinitions.Add(colH1);
            grdTotalHeader.ColumnDefinitions.Add(colH2);
            grdTotalHeader.ColumnDefinitions.Add(colH3);
            grdTotalHeader.ColumnDefinitions.Add(colH4);

            RowDefinition rowH0 = new RowDefinition();
            rowH0.Height = new GridLength(40);
            grdTotalHeader.RowDefinitions.Add(rowH0);

            Border brdcol1 = new Border();
            Border brdcol2 = new Border();
            Border brdcol3 = new Border();
            Border brdcol4 = new Border();

            brdcol1.BorderBrush = Brushes.Black;
            brdcol4.BorderBrush = brdcol3.BorderBrush = brdcol2.BorderBrush = brdcol1.BorderBrush;

            brdcol1.BorderThickness = new Thickness(0, 2, 1, 0);
            brdcol2.BorderThickness = new Thickness(0, 2, 1, 0);
            brdcol3.BorderThickness = new Thickness(0, 2, 1, 0);
            brdcol4.BorderThickness = new Thickness(0, 2, 2, 0);

            Label lblPer = new Label();
            lblPer.Content = "PERCEPCIONES";
            lblPer.FontWeight = FontWeights.Bold;
            lblPer.HorizontalAlignment = HorizontalAlignment.Center;
            lblPer.FontFamily = new FontFamily("Calibri");
            lblPer.FontSize = 11;
            brdcol1.Child = lblPer;
            Grid.SetRow(brdcol1, 0);
            Grid.SetColumn(brdcol1, 0);

            Label lblValPer = new Label();
            lblValPer.Content = txtPercepciones.Text;
            lblValPer.FontWeight = FontWeights.Bold;
            lblValPer.HorizontalAlignment = HorizontalAlignment.Center;
            lblValPer.FontFamily = new FontFamily("Calibri");
            lblValPer.FontSize = 11;
            brdcol2.Child = lblValPer;
            Grid.SetRow(brdcol2, 0);
            Grid.SetColumn(brdcol2, 1);

            TextBlock lblPerNet = new TextBlock();
            lblPerNet.Text = txtCantWord.Text;//"PERCEPCION NETA:";
            lblPerNet.FontWeight = FontWeights.Bold;
            lblPerNet.HorizontalAlignment = HorizontalAlignment.Center;
            lblPerNet.FontFamily = new FontFamily("Calibri");
            lblPerNet.FontSize = 11;
            lblPerNet.TextWrapping = TextWrapping.Wrap;
            brdcol3.Child = lblPerNet;
            Grid.SetRow(brdcol3, 0);
            Grid.SetColumn(brdcol3, 2);

            Label lblTotNom = new Label();
            lblTotNom.Content = txtTotalNomina.Text;
            lblTotNom.FontWeight = FontWeights.Bold;
            lblTotNom.HorizontalAlignment = HorizontalAlignment.Center;
            lblTotNom.FontFamily = new FontFamily("Calibri");
            lblTotNom.FontSize = 11;
            brdcol4.Child = lblTotNom;
            Grid.SetRow(brdcol4, 0);
            Grid.SetColumn(brdcol4, 3);

            grdTotalHeader.Children.Add(brdcol1);
            grdTotalHeader.Children.Add(brdcol2);
            grdTotalHeader.Children.Add(brdcol3);
            grdTotalHeader.Children.Add(brdcol4);
            #endregion

            #region/*Total Values Grid*/
            ColumnDefinition colV1 = new ColumnDefinition();
            ColumnDefinition colV2 = new ColumnDefinition();
            ColumnDefinition colV3 = new ColumnDefinition();
            colV1.Width = new GridLength(80);
            colV2.Width = new GridLength(80);
            colV3.Width = new GridLength(357);
            grdTotalValues.ColumnDefinitions.Add(colV1);
            grdTotalValues.ColumnDefinitions.Add(colV2);
            grdTotalValues.ColumnDefinitions.Add(colV3);

            RowDefinition rowV0 = new RowDefinition();
            grdTotalValues.RowDefinitions.Add(rowV0);

            Border brdcolV1 = new Border();
            Border brdcolV2 = new Border();
            Border brdcolV3 = new Border();

            brdcolV1.BorderBrush = Brushes.Black;
            brdcolV3.BorderBrush = brdcolV2.BorderBrush = brdcolV1.BorderBrush;

            brdcolV1.BorderThickness = new Thickness(0, 1, 1, 2);
            brdcolV2.BorderThickness = new Thickness(0, 1, 1, 2);
            brdcolV3.BorderThickness = new Thickness(0, 1, 2, 2);

            Label lblDeductions = new Label();
            lblDeductions.Content = "DEDUCCIONES";
            lblDeductions.FontWeight = FontWeights.Bold;
            lblDeductions.HorizontalAlignment = HorizontalAlignment.Center;
            lblDeductions.FontFamily = new FontFamily("Calibri");
            lblDeductions.FontSize = 11;
            brdcolV1.Child = lblDeductions;
            Grid.SetRow(brdcolV1, 0);
            Grid.SetColumn(brdcolV1, 0);

            Label lblValDed = new Label();
            lblValDed.Content = txtDeducciones.Text;
            lblValDed.FontWeight = FontWeights.Bold;
            lblValDed.HorizontalAlignment = HorizontalAlignment.Center;
            lblValDed.FontFamily = new FontFamily("Calibri");
            lblValDed.FontSize = 11;
            brdcolV2.Child = lblValDed;
            Grid.SetRow(brdcolV2, 0);
            Grid.SetColumn(brdcolV2, 1);

            Label lblDateDep = new Label();
            lblDateDep.Content = txtFechaDep.Text;
            lblDateDep.FontWeight = FontWeights.Bold;
            lblDateDep.HorizontalAlignment = HorizontalAlignment.Center;
            lblDateDep.FontFamily = new FontFamily("Calibri");
            lblDateDep.FontSize = 11;
            brdcolV3.Child = lblDateDep;
            Grid.SetRow(brdcolV3, 0);
            Grid.SetColumn(brdcolV3, 2);

            grdTotalValues.Children.Add(brdcolV1);
            grdTotalValues.Children.Add(brdcolV2);
            grdTotalValues.Children.Add(brdcolV3);
            //#endregion      
            stpTeacherTotal.Children.Add(grdTotalHeader);
            stpTeacherTotal.Children.Add(grdTotalValues);
            dcpTotalContainer.Children.Add(brdTeacherName);
            dcpTotalContainer.Children.Add(stpTeacherTotal);



            #endregion

            #region/*Sign section*/
            StackPanel stpSign = new StackPanel();
            Border brdSignLine = new Border();
            Label lblSignName = new Label();
            StackPanel stpLegend = new StackPanel();
            TextBlock txtLegend = new TextBlock();

            stpSign.Margin = new Thickness(0, 50, 0, 0);
            stpSign.HorizontalAlignment = HorizontalAlignment.Center;
            stpSign.Width = 400;

            brdSignLine.BorderBrush = Brushes.Black;
            brdSignLine.BorderThickness = new Thickness(0,0,0,2);

            lblSignName.Content = txtSignName.Text;
            lblSignName.FontFamily = new FontFamily("Calibri");
            lblSignName.FontSize = 14;
            lblSignName.HorizontalAlignment = HorizontalAlignment.Center; 

            stpSign.Children.Add(brdSignLine);
            stpSign.Children.Add(lblSignName);

            stpLegend.Margin = new Thickness(0, 20, 0, 0);
            txtLegend.Text = "RECIBI DE KARLA PATRICIA ELIAS GUTIERREZ LA CANTIDAD IMPRESA POR CONCEPTO DE LA PRESTACION DE MIS SERVICIOS ASI COMO LAS COMISIONES Y BONOS CORRESPONDIENTES AL PERIODO QUE TERMINA HOY, INCLUYENDO EL TIEMPO EXTRA TRABAJADO SIN QUE A LA FECHA SE ME ADEUDE CANTIDAD ALGUNA POR OTRO CONCEPTO, HABIENDOSE HECHO LOS DESCUENTOS QUE ESTIPULA EL REGLAMENTO CORRESPONDIENTE. ";
            txtLegend.FontFamily = new FontFamily("Calibri");
            txtLegend.FontSize = 9;
            txtLegend.TextAlignment = TextAlignment.Justify;
            txtLegend.TextWrapping = TextWrapping.Wrap;

            stpLegend.Children.Add(txtLegend);

            #endregion


            stpFooterContainer.Children.Add(stpQltyHeader);
            stpFooterContainer.Children.Add(dcpTotalContainer);
            stpFooterContainer.Children.Add(stpSign);
            stpFooterContainer.Children.Add(stpLegend);


            blcFooter.Child = stpFooterContainer;
            footerSec.Blocks.Add(blcFooter);
            doc.Blocks.Add(footerSec);


            #endregion

            IDocumentPaginatorSource idpSource = doc;

            printDlg.PrintDocument(idpSource.DocumentPaginator, "Hello");

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Vistas.add_View(Contentx, new TableTeacherGroup());
        }

    }
}
