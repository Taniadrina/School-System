using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LIVEX.Class
{
    class Cycle
    {
        public static void InitilizeCalendars(LIVEX.UserControls.CalendarView ucCalendar)
        {
            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;
            int nextYear = currentYear + 1;


            if (currentMonth >= 1 && currentMonth <= 6)
            {
                ucCalendar.txtCycleName.Text = "Ciclo " + currentYear.ToString();
                setCalendars(ucCalendar, currentYear, 0);
            }
            else if (currentMonth >= 7 && currentMonth <= 12)
            {
                ucCalendar.txtCycleName.Text = "Ciclo " + currentYear.ToString() + " - " + nextYear.ToString();
                setCalendars(ucCalendar, currentYear, nextYear);
            }

            setCalendarStyles(ucCalendar);
            setPaymentPeriod(ucCalendar);
            //SetEndCicles(ucCalendar, new DateTime(2018,01,15));
        }

        private static void setCalendarStyles(LIVEX.UserControls.CalendarView ucCalendar)
        {
            ucCalendar.cJan.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cFeb.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cMar.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cAbr.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cMay.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cJun.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cJul.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cAgo.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cSep.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cOct.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cNov.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");
            ucCalendar.cDic.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle1");

            ucCalendar.cJanSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cFebSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cMarSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cAbrSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cMaySC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cJunSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cJulSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cAgoSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cSepSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cOctSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cNovSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");
            ucCalendar.cDicSC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle2");

            ucCalendar.cJanEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cFebEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cMarEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cAbrEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cMayEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cJunEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cJulEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cAgoEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cSepEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cOctEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cNovEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");
            ucCalendar.cDicEC.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle3");

            ucCalendar.cJanP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cFebP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cMarP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cAbrP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cMayP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cJunP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cJulP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cAgoP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cSepP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cOctP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cNovP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");
            ucCalendar.cDicP.SetResourceReference(Calendar.CalendarDayButtonStyleProperty, "CalendarDayButtonStyle4");


        }

        private static void setDatesToCalendar(Calendar calendar, int currentYear, int month) {
            calendar.DisplayDate = new DateTime(currentYear, month, 01);
            calendar.DisplayDateStart = new DateTime(currentYear, month, 01);
            calendar.DisplayDateEnd = new DateTime(currentYear, month, DateTime.DaysInMonth(currentYear, month));
        }

        private static void setCalendars(LIVEX.UserControls.CalendarView ucCalendar, int currentYear, int nextYear)
        {
            if (nextYear == 0)//complete year
            {
                /*Vacations Calendars*/
                setDatesToCalendar(ucCalendar.cJan, currentYear, 01);
                setDatesToCalendar(ucCalendar.cFeb, currentYear, 02);
                setDatesToCalendar(ucCalendar.cMar, currentYear, 03);
                setDatesToCalendar(ucCalendar.cAbr, currentYear, 04);
                setDatesToCalendar(ucCalendar.cMay, currentYear, 05);
                setDatesToCalendar(ucCalendar.cJun, currentYear, 06);
                setDatesToCalendar(ucCalendar.cJul, currentYear, 07);
                setDatesToCalendar(ucCalendar.cAgo, currentYear, 08);
                setDatesToCalendar(ucCalendar.cSep, currentYear, 09);
                setDatesToCalendar(ucCalendar.cOct, currentYear, 10);
                setDatesToCalendar(ucCalendar.cNov, currentYear, 11);
                setDatesToCalendar(ucCalendar.cDic, currentYear, 12);
                /*start cycle calendars*/
                setDatesToCalendar(ucCalendar.cJanSC, currentYear, 01);
                setDatesToCalendar(ucCalendar.cFebSC, currentYear, 02);
                setDatesToCalendar(ucCalendar.cMarSC, currentYear, 03);
                setDatesToCalendar(ucCalendar.cAbrSC, currentYear, 04);
                setDatesToCalendar(ucCalendar.cMaySC, currentYear, 05);
                setDatesToCalendar(ucCalendar.cJunSC, currentYear, 06);
                setDatesToCalendar(ucCalendar.cJulSC, currentYear, 07);
                setDatesToCalendar(ucCalendar.cAgoSC, currentYear, 08);
                setDatesToCalendar(ucCalendar.cSepSC, currentYear, 09);
                setDatesToCalendar(ucCalendar.cOctSC, currentYear, 10);
                setDatesToCalendar(ucCalendar.cNovSC, currentYear, 11);
                setDatesToCalendar(ucCalendar.cDicSC, currentYear, 12);
                /*END cycle calendars*/
                setDatesToCalendar(ucCalendar.cJanEC, currentYear, 01);
                setDatesToCalendar(ucCalendar.cFebEC, currentYear, 02);
                setDatesToCalendar(ucCalendar.cMarEC, currentYear, 03);
                setDatesToCalendar(ucCalendar.cAbrEC, currentYear, 04);
                setDatesToCalendar(ucCalendar.cMayEC, currentYear, 05);
                setDatesToCalendar(ucCalendar.cJunEC, currentYear, 06);
                setDatesToCalendar(ucCalendar.cJulEC, currentYear, 07);
                setDatesToCalendar(ucCalendar.cAgoEC, currentYear, 08);
                setDatesToCalendar(ucCalendar.cSepEC, currentYear, 09);
                setDatesToCalendar(ucCalendar.cOctEC, currentYear, 10);
                setDatesToCalendar(ucCalendar.cNovEC, currentYear, 11);
                setDatesToCalendar(ucCalendar.cDicEC, currentYear, 12);
                /*Payment cycle calendars*/
                setDatesToCalendar(ucCalendar.cJanP, currentYear, 01);
                setDatesToCalendar(ucCalendar.cFebP, currentYear, 02);
                setDatesToCalendar(ucCalendar.cMarP, currentYear, 03);
                setDatesToCalendar(ucCalendar.cAbrP, currentYear, 04);
                setDatesToCalendar(ucCalendar.cMayP, currentYear, 05);
                setDatesToCalendar(ucCalendar.cJunP, currentYear, 06);
                setDatesToCalendar(ucCalendar.cJulP, currentYear, 07);
                setDatesToCalendar(ucCalendar.cAgoP, currentYear, 08);
                setDatesToCalendar(ucCalendar.cSepP, currentYear, 09);
                setDatesToCalendar(ucCalendar.cOctP, currentYear, 10);
                setDatesToCalendar(ucCalendar.cNovP, currentYear, 11);
                setDatesToCalendar(ucCalendar.cDicP, currentYear, 12);


            }
            else
            {
                /*Vacations Calendars*/
                setDatesToCalendar(ucCalendar.cJan, currentYear, 07);
                setDatesToCalendar(ucCalendar.cFeb, currentYear, 08);
                setDatesToCalendar(ucCalendar.cMar, currentYear, 09);
                setDatesToCalendar(ucCalendar.cAbr, currentYear, 10);
                setDatesToCalendar(ucCalendar.cMay, currentYear, 11);
                setDatesToCalendar(ucCalendar.cJun, currentYear, 12);
                //-------------------------------------------------NEXT HALF YEAR
                setDatesToCalendar(ucCalendar.cJul, nextYear, 01);
                setDatesToCalendar(ucCalendar.cAgo, nextYear, 02);
                setDatesToCalendar(ucCalendar.cSep, nextYear, 03);
                setDatesToCalendar(ucCalendar.cOct, nextYear, 04);
                setDatesToCalendar(ucCalendar.cNov, nextYear, 05);
                setDatesToCalendar(ucCalendar.cDic, nextYear, 06);

                /*Start Cycle Calendars*/
                setDatesToCalendar(ucCalendar.cJanSC, currentYear, 07);
                setDatesToCalendar(ucCalendar.cFebSC, currentYear, 08);
                setDatesToCalendar(ucCalendar.cMarSC, currentYear, 09);
                setDatesToCalendar(ucCalendar.cAbrSC, currentYear, 10);
                setDatesToCalendar(ucCalendar.cMaySC, currentYear, 11);
                setDatesToCalendar(ucCalendar.cJunSC, currentYear, 12);
                //-------------------------------------------------NEXT HALF YEAR
                setDatesToCalendar(ucCalendar.cJulSC, nextYear, 01);
                setDatesToCalendar(ucCalendar.cAgoSC, nextYear, 02);
                setDatesToCalendar(ucCalendar.cSepSC, nextYear, 03);
                setDatesToCalendar(ucCalendar.cOctSC, nextYear, 04);
                setDatesToCalendar(ucCalendar.cNovSC, nextYear, 05);
                setDatesToCalendar(ucCalendar.cDicSC, nextYear, 06);

                /*End Cycle Calendars*/
                setDatesToCalendar(ucCalendar.cJanEC, currentYear, 07);
                setDatesToCalendar(ucCalendar.cFebEC, currentYear, 08);
                setDatesToCalendar(ucCalendar.cMarEC, currentYear, 09);
                setDatesToCalendar(ucCalendar.cAbrEC, currentYear, 10);
                setDatesToCalendar(ucCalendar.cMayEC, currentYear, 11);
                setDatesToCalendar(ucCalendar.cJunEC, currentYear, 12);
                //-------------------------------------------------NEXT HALF YEAR
                setDatesToCalendar(ucCalendar.cJulEC, nextYear, 01);
                setDatesToCalendar(ucCalendar.cAgoEC, nextYear, 02);
                setDatesToCalendar(ucCalendar.cSepEC, nextYear, 03);
                setDatesToCalendar(ucCalendar.cOctEC, nextYear, 04);
                setDatesToCalendar(ucCalendar.cNovEC, nextYear, 05);
                setDatesToCalendar(ucCalendar.cDicEC, nextYear, 06);

                /*Payment Calendars*/
                setDatesToCalendar(ucCalendar.cJanP, currentYear, 07);
                setDatesToCalendar(ucCalendar.cFebP, currentYear, 08);
                setDatesToCalendar(ucCalendar.cMarP, currentYear, 09);
                setDatesToCalendar(ucCalendar.cAbrP, currentYear, 10);
                setDatesToCalendar(ucCalendar.cMayP, currentYear, 11);
                setDatesToCalendar(ucCalendar.cJunP, currentYear, 12);
                //-------------------------------------------------NEXT HALF YEAR
                setDatesToCalendar(ucCalendar.cJulP, nextYear, 01);
                setDatesToCalendar(ucCalendar.cAgoP, nextYear, 02);
                setDatesToCalendar(ucCalendar.cSepP, nextYear, 03);
                setDatesToCalendar(ucCalendar.cOctP, nextYear, 04);
                setDatesToCalendar(ucCalendar.cNovP, nextYear, 05);
                setDatesToCalendar(ucCalendar.cDicP, nextYear, 06);
            }
        }

        public static void EnableCalendars(LIVEX.UserControls.CalendarView ucCalendar, int type)
        {

            ucCalendar.cJan.IsEnabled = false;
            ucCalendar.cFeb.IsEnabled = false;
            ucCalendar.cMar.IsEnabled = false;
            ucCalendar.cAbr.IsEnabled = false;
            ucCalendar.cMay.IsEnabled = false;
            ucCalendar.cJun.IsEnabled = false;
            ucCalendar.cJul.IsEnabled = false;
            ucCalendar.cAgo.IsEnabled = false;
            ucCalendar.cSep.IsEnabled = false;
            ucCalendar.cOct.IsEnabled = false;
            ucCalendar.cNov.IsEnabled = false;
            ucCalendar.cDic.IsEnabled = false;
            ucCalendar.cJanSC.IsEnabled = false;
            ucCalendar.cFebSC.IsEnabled = false;
            ucCalendar.cMarSC.IsEnabled = false;
            ucCalendar.cAbrSC.IsEnabled = false;
            ucCalendar.cMaySC.IsEnabled = false;
            ucCalendar.cJunSC.IsEnabled = false;
            ucCalendar.cJulSC.IsEnabled = false;
            ucCalendar.cAgoSC.IsEnabled = false;
            ucCalendar.cSepSC.IsEnabled = false;
            ucCalendar.cOctSC.IsEnabled = false;
            ucCalendar.cNovSC.IsEnabled = false;
            ucCalendar.cDicSC.IsEnabled = false;
            ucCalendar.cJanEC.IsEnabled = false;
            ucCalendar.cFebEC.IsEnabled = false;
            ucCalendar.cMarEC.IsEnabled = false;
            ucCalendar.cAbrEC.IsEnabled = false;
            ucCalendar.cMayEC.IsEnabled = false;
            ucCalendar.cJunEC.IsEnabled = false;
            ucCalendar.cJulEC.IsEnabled = false;
            ucCalendar.cAgoEC.IsEnabled = false;
            ucCalendar.cSepEC.IsEnabled = false;
            ucCalendar.cOctEC.IsEnabled = false;
            ucCalendar.cNovEC.IsEnabled = false;
            ucCalendar.cDicEC.IsEnabled = false;
            ucCalendar.cJanP.IsEnabled = false;
            ucCalendar.cFebP.IsEnabled = false;
            ucCalendar.cMarP.IsEnabled = false;
            ucCalendar.cAbrP.IsEnabled = false;
            ucCalendar.cMayP.IsEnabled = false;
            ucCalendar.cJunP.IsEnabled = false;
            ucCalendar.cJulP.IsEnabled = false;
            ucCalendar.cAgoP.IsEnabled = false;
            ucCalendar.cSepP.IsEnabled = false;
            ucCalendar.cOctP.IsEnabled = false;
            ucCalendar.cNovP.IsEnabled = false;
            ucCalendar.cDicP.IsEnabled = false;
            switch (type)
            {
                case 0://none
                    break;
                case 1://vacations
                    ucCalendar.cJan.IsEnabled = true;
                    ucCalendar.cFeb.IsEnabled = true;
                    ucCalendar.cMar.IsEnabled = true;
                    ucCalendar.cAbr.IsEnabled = true;
                    ucCalendar.cMay.IsEnabled = true;
                    ucCalendar.cJun.IsEnabled = true;
                    ucCalendar.cJul.IsEnabled = true;
                    ucCalendar.cAgo.IsEnabled = true;
                    ucCalendar.cSep.IsEnabled = true;
                    ucCalendar.cOct.IsEnabled = true;
                    ucCalendar.cNov.IsEnabled = true;
                    ucCalendar.cDic.IsEnabled = true;
                    break;
                case 2://start cicle
                    ucCalendar.cJanSC.IsEnabled = true;
                    ucCalendar.cFebSC.IsEnabled = true;
                    ucCalendar.cMarSC.IsEnabled = true;
                    ucCalendar.cAbrSC.IsEnabled = true;
                    ucCalendar.cMaySC.IsEnabled = true;
                    ucCalendar.cJunSC.IsEnabled = true;
                    ucCalendar.cJulSC.IsEnabled = true;
                    ucCalendar.cAgoSC.IsEnabled = true;
                    ucCalendar.cSepSC.IsEnabled = true;
                    ucCalendar.cOctSC.IsEnabled = true;
                    ucCalendar.cNovSC.IsEnabled = true;
                    ucCalendar.cDicSC.IsEnabled = true;
                    break;
                case 3: //end cycle
                    ucCalendar.cJanEC.IsEnabled = true;
                    ucCalendar.cFebEC.IsEnabled = true;
                    ucCalendar.cMarEC.IsEnabled = true;
                    ucCalendar.cAbrEC.IsEnabled = true;
                    ucCalendar.cMayEC.IsEnabled = true;
                    ucCalendar.cJunEC.IsEnabled = true;
                    ucCalendar.cJulEC.IsEnabled = true;
                    ucCalendar.cAgoEC.IsEnabled = true;
                    ucCalendar.cSepEC.IsEnabled = true;
                    ucCalendar.cOctEC.IsEnabled = true;
                    ucCalendar.cNovEC.IsEnabled = true;
                    ucCalendar.cDicEC.IsEnabled = true;
                    break;
                case 4: //payment
                    ucCalendar.cJanP.IsEnabled = true;
                    ucCalendar.cFebP.IsEnabled = true;
                    ucCalendar.cMarP.IsEnabled = true;
                    ucCalendar.cAbrP.IsEnabled = true;
                    ucCalendar.cMayP.IsEnabled = true;
                    ucCalendar.cJunP.IsEnabled = true;
                    ucCalendar.cJulP.IsEnabled = true;
                    ucCalendar.cAgoP.IsEnabled = true;
                    ucCalendar.cSepP.IsEnabled = true;
                    ucCalendar.cOctP.IsEnabled = true;
                    ucCalendar.cNovP.IsEnabled = true;
                    ucCalendar.cDicP.IsEnabled = true;
                    break;





            }
            ucCalendar.btnVacaciones.IsEnabled = true;
            ucCalendar.btnCicloInicio.IsEnabled = true;
            ucCalendar.btnCicloFin.IsEnabled = true;
            ucCalendar.btnClean.IsEnabled = true;
            ucCalendar.btnSave.IsEnabled = true;
            ucCalendar.btnEdit.IsEnabled = false;


        }

        public static void DisableCalendars(LIVEX.UserControls.CalendarView ucCalendar)
        {
            ucCalendar.cJan.IsEnabled = false;
            ucCalendar.cFeb.IsEnabled = false;
            ucCalendar.cMar.IsEnabled = false;
            ucCalendar.cAbr.IsEnabled = false;
            ucCalendar.cMay.IsEnabled = false;
            ucCalendar.cJun.IsEnabled = false;
            ucCalendar.cJul.IsEnabled = false;
            ucCalendar.cAgo.IsEnabled = false;
            ucCalendar.cSep.IsEnabled = false;
            ucCalendar.cOct.IsEnabled = false;
            ucCalendar.cNov.IsEnabled = false;
            ucCalendar.cDic.IsEnabled = false;
            ucCalendar.cJanSC.IsEnabled = false;
            ucCalendar.cFebSC.IsEnabled = false;
            ucCalendar.cMarSC.IsEnabled = false;
            ucCalendar.cAbrSC.IsEnabled = false;
            ucCalendar.cMaySC.IsEnabled = false;
            ucCalendar.cJunSC.IsEnabled = false;
            ucCalendar.cJulSC.IsEnabled = false;
            ucCalendar.cAgoSC.IsEnabled = false;
            ucCalendar.cSepSC.IsEnabled = false;
            ucCalendar.cOctSC.IsEnabled = false;
            ucCalendar.cNovSC.IsEnabled = false;
            ucCalendar.cDicSC.IsEnabled = false;
            ucCalendar.cJanEC.IsEnabled = false;
            ucCalendar.cFebEC.IsEnabled = false;
            ucCalendar.cMarEC.IsEnabled = false;
            ucCalendar.cAbrEC.IsEnabled = false;
            ucCalendar.cMayEC.IsEnabled = false;
            ucCalendar.cJunEC.IsEnabled = false;
            ucCalendar.cJulEC.IsEnabled = false;
            ucCalendar.cAgoEC.IsEnabled = false;
            ucCalendar.cSepEC.IsEnabled = false;
            ucCalendar.cOctEC.IsEnabled = false;
            ucCalendar.cNovEC.IsEnabled = false;
            ucCalendar.cDicEC.IsEnabled = false;
            ucCalendar.cJanP.IsEnabled = false;
            ucCalendar.cFebP.IsEnabled = false;
            ucCalendar.cMarP.IsEnabled = false;
            ucCalendar.cAbrP.IsEnabled = false;
            ucCalendar.cMayP.IsEnabled = false;
            ucCalendar.cJunP.IsEnabled = false;
            ucCalendar.cJulP.IsEnabled = false;
            ucCalendar.cAgoP.IsEnabled = false;
            ucCalendar.cSepP.IsEnabled = false;
            ucCalendar.cOctP.IsEnabled = false;
            ucCalendar.cNovP.IsEnabled = false;
            ucCalendar.cDicP.IsEnabled = false;
            ucCalendar.btnVacaciones.IsEnabled = false;
            ucCalendar.btnCicloInicio.IsEnabled = false;
            ucCalendar.btnCicloFin.IsEnabled = false;
            ucCalendar.btnClean.IsEnabled = false;
            ucCalendar.btnSave.IsEnabled = false;
            ucCalendar.btnEdit.IsEnabled = true;
        }

        public static void SaveCycles(LIVEX.UserControls.CalendarView ucCalendar)
        {

            SaveNormalCycles(ucCalendar);
            SaveVacationCycles(ucCalendar);
            DisableCalendars(ucCalendar);

        }

        private static void SaveNormalCycles(LIVEX.UserControls.CalendarView ucCalendar) {

            livexEntities context = new livexEntities();
            List<ciclo> lstCycles = new List<ciclo>();
            lstCycles = context.ciclo.Where(x => x.ciclo_side == "A" || x.ciclo_side == "B").ToList();
            List<ciclo> lstSelectedCycles = new List<ciclo>();

            for(int x = 1; x <= 12; x++)
            {
                Calendar cStart = new Calendar();
                Calendar cEnd = new Calendar();
                switch (x)
                {
                    case 1:
                        cStart = ucCalendar.cJanSC;
                        cEnd = ucCalendar.cJanEC;
                        break;
                    case 2:
                        cStart = ucCalendar.cFebSC;
                        cEnd = ucCalendar.cFebEC;
                        break;
                    case 3:
                        cStart = ucCalendar.cMarSC;
                        cEnd = ucCalendar.cMarEC;
                        break;
                    case 4:
                        cStart = ucCalendar.cAbrSC;
                        cEnd = ucCalendar.cAbrEC;
                        break;
                    case 5:
                        cStart = ucCalendar.cMaySC;
                        cEnd = ucCalendar.cMayEC;
                        break;
                    case 6:
                        cStart = ucCalendar.cJunSC;
                        cEnd = ucCalendar.cJunEC;
                        break;
                    case 7:
                        cStart = ucCalendar.cJulSC;
                        cEnd = ucCalendar.cJulEC;
                        break;
                    case 8:
                        cStart = ucCalendar.cAgoSC;
                        cEnd = ucCalendar.cAgoEC;
                        break;
                    case 9:
                        cStart = ucCalendar.cSepSC;
                        cEnd = ucCalendar.cSepEC;
                        break;
                    case 10:
                        cStart = ucCalendar.cOctSC;
                        cEnd = ucCalendar.cOctEC;
                        break;
                    case 11:
                        cStart = ucCalendar.cNovSC;
                        cEnd = ucCalendar.cNovEC;
                        break;
                    case 12:
                        cStart = ucCalendar.cDicSC;
                        cEnd = ucCalendar.cDicEC;
                        break;
                }
                
                foreach(DateTime day in cStart.SelectedDates) {
                    int cycle = getCycleNum(day);
                    string cycleSide = getCycleSide(day);
                    ciclo ciclo = new ciclo();

                    ciclo.Fecha_inicio = day.ToShortDateString();
                    ciclo.Fecha_fin = day.AddDays(12).ToShortDateString();
                    ciclo.ciclo_num = cycle;
                    ciclo.ciclo_side = cycleSide;
                    ciclo.ciclocol = cycle + " " + cycleSide;
                    ciclo.year = day.Year;

                    lstSelectedCycles.Add(ciclo);

                }

                foreach (DateTime day in cEnd.SelectedDates) {
                    DateTime startDate = day.AddDays(-12);
                    int cycle = getCycleNum(startDate);
                    string cycleSide = getCycleSide(day);
                    ciclo ciclo = new ciclo();

                    ciclo.Fecha_inicio = startDate.ToShortDateString();
                    ciclo.Fecha_fin = day.ToShortDateString();
                    ciclo.ciclo_num = cycle;
                    ciclo.ciclo_side = cycleSide;
                    ciclo.ciclocol = cycle + " " + cycleSide;
                    ciclo.year = day.Year;

                    lstSelectedCycles.Add(ciclo);
                }
            }

           

            foreach(ciclo c in lstSelectedCycles)
            {
                //if (lstSelectedCycles.Count == 25 && c.ciclo_num == 13 && c.ciclo_side == "A")
                //{
                    
                //    ciclo lastCycle = context.ciclo.FirstOrDefault(x => x.ciclo_num==13 && x.ciclo_side == "B");

                //    DateTime startDate = Convert.ToDateTime(c.Fecha_fin);
                    
                //    lastCycle.Fecha_inicio = startDate.AddDays(2).ToShortDateString();
                //    DateTime endDate = Convert.ToDateTime(lastCycle.Fecha_inicio);
                //    lastCycle.Fecha_fin = endDate.AddDays(12).ToShortDateString();
                //    lastCycle.ciclo_num = 13;
                //    lastCycle.ciclo_side = "B";
                //    lastCycle.ciclocol = "13 B";
                //    context.ciclo.Add(lastCycle);

                //}

                ciclo cl = context.ciclo.FirstOrDefault(x => x.Fecha_inicio == c.Fecha_inicio &&
                                                             x.Fecha_fin == c.Fecha_fin &&
                                                             x.ciclo_num == c.ciclo_num &&
                                                             x.ciclo_side == c.ciclo_side &&
                                                             x.year == c.year);
                if (cl == null)
                {
                    cl = context.ciclo.FirstOrDefault(x => x.Fecha_inicio == c.Fecha_inicio ||
                                                             x.Fecha_fin == c.Fecha_fin ||
                                                             x.ciclo_num == c.ciclo_num &&
                                                             x.ciclo_side == c.ciclo_side && x.year == c.year);
                    if(cl !=null)
                    {
                        DateTime startDateSelected = Convert.ToDateTime(c.Fecha_inicio);
                        DateTime endDateSelected = Convert.ToDateTime(c.Fecha_fin);

                        DateTime startDateSaved = new DateTime();
                        DateTime endDateSaved = new DateTime();

                        if(cl.Fecha_inicio !="")
                            startDateSaved = Convert.ToDateTime(cl.Fecha_inicio);

                        if(cl.Fecha_fin != "")
                            endDateSaved = Convert.ToDateTime(cl.Fecha_fin);

                        if (cl.ciclo_side == c.ciclo_side && startDateSelected.Year == startDateSaved.Year && startDateSelected.Month == startDateSaved.Month)
                        {
                            if (startDateSelected.Day != startDateSaved.Day && cl.ciclo_side == "A")
                            {
                                cl.Fecha_inicio = startDateSelected.ToShortDateString();
                                cl.Fecha_fin = endDateSelected.ToShortDateString();
                                cl.ciclocol = c.ciclo_num + " " + c.ciclo_side;

                                context.SaveChanges();
                            }

                            if (endDateSelected.Day != endDateSaved.Day && cl.ciclo_side == "B")
                            {
                                cl.Fecha_fin = endDateSelected.ToShortDateString();
                                cl.Fecha_inicio = startDateSelected.ToShortDateString();
                                cl.ciclocol = c.ciclo_num + " " + c.ciclo_side;

                                context.SaveChanges();
                            }
                        }
                        else
                            context.ciclo.Add(cl);
                    }
                    else
                        context.ciclo.Add(c);
                }
                    
                //DateTime startDateSelected = Convert.ToDateTime(c.Fecha_inicio);
                //DateTime endDateSelected = Convert.ToDateTime(c.Fecha_fin);
                //int cycle = getCycleNum(startDateSelected);
                //List<ciclo> cycleBynum = lstCycles.Where(e => e.ciclo_num == cycle).ToList();
                //foreach(ciclo cl in cycleBynum)
                //{
                //    DateTime startDateSaved = Convert.ToDateTime(cl.Fecha_inicio);
                //    DateTime endDateSaved = Convert.ToDateTime(cl.Fecha_fin);
                //    if (cl.ciclo_side == c.ciclo_side && startDateSelected.Year == startDateSaved.Year && startDateSelected.Month == startDateSaved.Month)
                //    {
                //        if (startDateSelected.Day != startDateSaved.Day && cl.ciclo_side == "A")
                //        {
                //            cl.Fecha_inicio = startDateSelected.ToShortDateString();
                //            context.SaveChanges();
                //        }

                //        if (endDateSelected.Day != endDateSaved.Day && cl.ciclo_side == "B")
                //        {
                //            cl.Fecha_fin = endDateSelected.ToShortDateString();
                //            context.SaveChanges();
                //        }
                //    }
                //    else
                //        context.ciclo.Add(c);
                    
                //}
              
            }
            context.SaveChanges();


            //livexEntities context = new livexEntities();
            //List<ciclo> lstCycles = new List<ciclo>();
            //lstCycles = context.ciclo.Where(x => x.ciclo_side == "A" || x.ciclo_side == "B").ToList();
            //bool isEdited = false;

            //if (lstCycles.Count > 0)
            //{
            //    for (int y = 1; y <= 12; y++)
            //    {
            //        Calendar calendar = new Calendar();
            //        switch (y)
            //        {
            //            case 1:
            //                calendar = ucCalendar.cJanSC;
            //                break;
            //            case 2:
            //                calendar = ucCalendar.cFebSC;
            //                break;
            //            case 3:
            //                calendar = ucCalendar.cMarSC;
            //                break;
            //            case 4:
            //                calendar = ucCalendar.cAbrSC;
            //                break;
            //            case 5:
            //                calendar = ucCalendar.cMaySC;
            //                break;
            //            case 6:
            //                calendar = ucCalendar.cJunSC;
            //                break;
            //            case 7:
            //                calendar = ucCalendar.cJulSC;
            //                break;
            //            case 8:
            //                calendar = ucCalendar.cAgoSC;
            //                break;
            //            case 9:
            //                calendar = ucCalendar.cSepSC;
            //                break;
            //            case 10:
            //                calendar = ucCalendar.cOctSC;
            //                break;
            //            case 11:
            //                calendar = ucCalendar.cNovSC;
            //                break;
            //            case 12:
            //                calendar = ucCalendar.cDicSC;
            //                break;
            //        }
            //        foreach (DateTime d in calendar.SelectedDates)
            //        {
            //            DateTime startDateSelected = d;
            //            DateTime nextStartDate = new DateTime();
            //            int cycle = getCycleNum(startDateSelected);
            //            List<ciclo> lstCycles2 = lstCycles.Where(x => x.ciclo_num == cycle).ToList();
            //            foreach (ciclo c in lstCycles2)
            //            {
            //                DateTime startDate = Convert.ToDateTime(c.Fecha_inicio);
            //                if (startDate.Month == d.Month && startDate.Year == d.Year && c.ciclo_side == "A")
            //                {
            //                    if (d.Day != startDate.Day)
            //                    {
            //                        c.Fecha_inicio = d.ToShortDateString();
            //                        c.Fecha_fin = startDateSelected.AddDays(12).ToShortDateString();
            //                        nextStartDate = Convert.ToDateTime(c.Fecha_fin).AddDays(2);
            //                        context.SaveChanges();
            //                        isEdited = true;
            //                        break;
            //                    }
            //                }
            //                if (startDate.Month == d.Month && startDate.Year == d.Year && c.ciclo_side == "B")
            //                {
            //                    if (d.Day != startDate.Day && c.ciclo_side != "B")
            //                    {
            //                        c.Fecha_inicio = nextStartDate.ToShortDateString();
            //                        c.Fecha_fin = nextStartDate.AddDays(12).ToShortDateString();
            //                        context.SaveChanges();
            //                        isEdited = true;
            //                    }
            //                }

            //                isEdited = false;



            //            }

            //        }


            //    }
            //}
            //else if (!isEdited)
            //{
            //    string cyclename = "";
            //    DateTime startDate = new DateTime();
            //    string endDate = "";
            //    string cycleSide = "";
            //    Calendar calendar = new Calendar();
            //    DateTime nextDate = new DateTime();
            //    int cycle = 0;

            //    for (int i = 0; i < 12; i++)
            //    {
            //        switch (i + 1)
            //        {
            //            case 1:
            //                calendar = ucCalendar.cJanSC;
            //                break;
            //            case 2:
            //                calendar = ucCalendar.cFebSC;
            //                break;
            //            case 3:
            //                calendar = ucCalendar.cMarSC;
            //                break;
            //            case 4:
            //                calendar = ucCalendar.cAbrSC;
            //                break;
            //            case 5:
            //                calendar = ucCalendar.cMaySC;
            //                break;
            //            case 6:
            //                calendar = ucCalendar.cJunSC;
            //                break;
            //            case 7:
            //                calendar = ucCalendar.cJulSC;
            //                break;
            //            case 8:
            //                calendar = ucCalendar.cAgoSC;
            //                break;
            //            case 9:
            //                calendar = ucCalendar.cSepSC;
            //                break;
            //            case 10:
            //                calendar = ucCalendar.cOctSC;
            //                break;
            //            case 11:
            //                calendar = ucCalendar.cNovSC;
            //                break;
            //            case 12:
            //                calendar = ucCalendar.cDicSC;
            //                break;

            //        }

            //        foreach (DateTime d in calendar.SelectedDates)
            //        {

            //            startDate = d;

            //            for (int x = 0; x < 2; x++)
            //            {
            //                ciclo c = new ciclo();
            //                nextDate = startDate.AddDays(12);
            //                endDate = nextDate.ToShortDateString();
            //                int wkNum = GetIso8601WeekOfYear(startDate);
            //                int livexwk = ((wkNum + 2) % 4);

            //                cycle = getCycleNum(startDate);
            //                //cycle = Decimal.Divide((wkNum + 2 + livexwk), 4M);

            //                //cycle = Math.Ceiling(cycle);

            //                if (livexwk == 1 || livexwk == 2)
            //                {
            //                    cycleSide = "A";
            //                    //cycle = cycle - 1;
            //                }
            //                else
            //                {
            //                    cycleSide = "B";
            //                    //cycle = cycle - 2;
            //                }

            //                //if (cycle == 0)
            //                //    cycle = 13;

            //                c.Fecha_inicio = startDate.ToShortDateString();
            //                c.Fecha_fin = endDate;
            //                c.ciclo_num = (int)cycle;
            //                c.ciclo_side = cycleSide;
            //                c.ciclocol = cycle + " " + cycleSide;
            //                context.ciclo.Add(c);
            //                startDate = nextDate.AddDays(2);
            //            }
            //            context.SaveChanges();


            //        }

            //    }
            //}


        }

        private static string getCycleSide(DateTime day)
        {
            int wkNum = GetIso8601WeekOfYear(day);
            int livexwk = ((wkNum + 2) % 4);
            string cycleSide = "";
            if (livexwk == 1 || livexwk == 2)
                cycleSide = "A";
            else
                cycleSide = "B";

            return cycleSide;
        }

        private static void SaveVacationCycles(LIVEX.UserControls.CalendarView ucCalendar)
        {
        }

        private static DateTime getFirstDayPayment(DateTime date) {
            DateTime realStartDate = new DateTime();

            int livexweek = getLivexWeek(date);
            int addDays = 0;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    addDays = 7;
                    break;
                case DayOfWeek.Tuesday:
                    addDays = 6;
                    break;
                case DayOfWeek.Wednesday:
                    addDays = 5;
                    break;
                case DayOfWeek.Thursday:
                    addDays = 4;
                    break;
                case DayOfWeek.Friday:
                    addDays = 3;
                    break;
                case DayOfWeek.Saturday:
                    addDays = 2;
                    break;
                case DayOfWeek.Sunday:
                    addDays = 1;
                    break;
            }

            switch (livexweek)
            {
                case 1:
                    realStartDate = date.AddDays(14+addDays);
                    break;
                case 2:
                    realStartDate = date.AddDays(7 + addDays);
                    break;
                case 3:
                    realStartDate = date.AddDays(addDays);
                    break;
                case 4:
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                        realStartDate = date.AddDays(21+ addDays);
                    else
                        realStartDate = date;
                    break;
            }

            

            return realStartDate;
        }

        private static void setPaymentPeriod(LIVEX.UserControls.CalendarView ucCalendar) {

            DateTime startDate = new DateTime();

            startDate = getFirstDayPayment(ucCalendar.cJanP.DisplayDate);

            //DateTime beginnigDate = new DateTime(2018, 01, 08);
            //DateTime startDate = new DateTime();

            ////int yearsPast = ucCalendar.cDic.DisplayDate.Year - ucCalendar.cJan.DisplayDate.Year;
            //int yearsPast = 0;
            
                
            ////if (yearsPast == 0)
            ////{
            ////    yearsPast = 1;
            ////}
            ////else
            ////    yearsPast = yearsPast * 2;
            //if (ucCalendar.cJan.DisplayDate.Month != 1)
            //{
            //    yearsPast = ucCalendar.cDic.DisplayDate.Year - beginnigDate.Year+1;
            //    startDate = beginnigDate.AddDays(185 * yearsPast);
            //}
            //else
            //{
            //    yearsPast = ucCalendar.cJan.DisplayDate.Year - beginnigDate.Year;
            //    startDate = beginnigDate.AddDays(364 * yearsPast);
            //}
            ////if (yearsPast > 0)
            ////    startDate = beginnigDate.AddDays(364 * yearsPast);
            ////else
            ////    startDate = beginnigDate.AddDays(196 * yearsPast);

            
            SelectedDatesCollection theDates = ucCalendar.cJanP.SelectedDates;
            DateTime lastDate = new DateTime();
            DateTime nextPeriod = new DateTime();

            for (int x = 0; x <= 12; x++)
            {
                int calendarFactor = 0;

                if ((int)ucCalendar.cJanP.DisplayDate.Month != 1)
                {
                    if (startDate.Month >= 1 && startDate.Month < 7)
                        calendarFactor = -6;
                    else
                        calendarFactor = 6;
                }
                else
                    calendarFactor = 0;
                //if(yearsPast==0)

                for (int i = 0; i < 6; i++)
                {
                    DateTime startDatex = startDate.AddDays(i);
                    switch ((int)startDatex.Month - calendarFactor)
                    {
                        case 1:
                            ucCalendar.cJanP.SelectedDates.Add(startDatex);
                            break;
                        case 2:
                            ucCalendar.cFebP.SelectedDates.Add(startDatex);
                            break;
                        case 3:
                            ucCalendar.cMarP.SelectedDates.Add(startDatex);
                            break;
                        case 4:
                            ucCalendar.cAbrP.SelectedDates.Add(startDatex);
                            break;
                        case 5:
                            ucCalendar.cMayP.SelectedDates.Add(startDatex);
                            break;
                        case 6:
                            ucCalendar.cJunP.SelectedDates.Add(startDatex);
                            break;
                        case 7:
                            ucCalendar.cJulP.SelectedDates.Add(startDatex);
                            break;
                        case 8:
                            ucCalendar.cAgoP.SelectedDates.Add(startDatex);
                            break;
                        case 9:
                            ucCalendar.cSepP.SelectedDates.Add(startDatex);
                            break;
                        case 10:
                            ucCalendar.cOctP.SelectedDates.Add(startDatex);
                            break;
                        case 11:
                            ucCalendar.cNovP.SelectedDates.Add(startDatex);
                            break;
                        case 12:
                            ucCalendar.cDicP.SelectedDates.Add(startDatex);
                            break;
                    }
                }
               // else
                    //for (int i = 0; i < 6; i++)
                    //{
                    //    DateTime startDatex = startDate.AddDays(i);
                    //    switch (x+1)
                    //    {
                    //        case 1:
                    //            ucCalendar.cJanP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 2:
                    //            ucCalendar.cFebP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 3:
                    //            ucCalendar.cMarP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 4:
                    //            ucCalendar.cAbrP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 5:
                    //            ucCalendar.cMayP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 6:
                    //            ucCalendar.cJunP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 7:
                    //            ucCalendar.cJulP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 8:
                    //            ucCalendar.cAgoP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 9:
                    //            ucCalendar.cSepP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 10:
                    //            ucCalendar.cOctP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 11:
                    //            ucCalendar.cNovP.SelectedDates.Add(startDatex);
                    //            break;
                    //        case 12:
                    //            ucCalendar.cDicP.SelectedDates.Add(startDatex);
                    //            break;
                    //    }
                    //}
                lastDate = startDate.AddDays(5);
                nextPeriod = lastDate.AddDays(23);
                startDate = nextPeriod;
            }

        }

        public static void SetEndCicles(LIVEX.UserControls.CalendarView ucCalendar, DateTime date) {

            //SelectedDatesCollection theDates = ucCalendar.cJanEC.SelectedDates;
            DateTime sDate = date;
            DateTime eDate = new DateTime();

            DateTime endYear = (DateTime)ucCalendar.cDic.DisplayDateStart;
            for (int i = 0; i < 12; i++)
            {
                if (date.Year <= endYear.Year)
                {


                    eDate = sDate.AddDays(26);
                    int calendarFactor = 0;

                    if ((int)ucCalendar.cJanSC.DisplayDate.Month != 1)
                    { 
                        if (eDate.Month >= 1 && eDate.Month < 7)
                            calendarFactor = -6;
                        else
                            calendarFactor = 6;
                     }
                    else
                    calendarFactor = 0;

                    switch ((int)eDate.Month - calendarFactor)
                    {
                        case 1:
                            ucCalendar.cJanEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cJanEC, eDate);
                            break;
                        case 2:
                            ucCalendar.cFebEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cFebEC, eDate);
                            break;
                        case 3:
                            ucCalendar.cMarEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cMarEC, eDate);
                            break;
                        case 4:
                            ucCalendar.cAbrEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cAbrEC, eDate);
                            break;
                        case 5:
                            ucCalendar.cMayEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cMayEC, eDate);
                            break;
                        case 6:
                            ucCalendar.cJunEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cJunEC, eDate);
                            break;
                        case 7:
                            ucCalendar.cJulEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cJulEC, eDate);
                            break;
                        case 8:
                            ucCalendar.cAgoEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cAgoEC, eDate);
                            break;
                        case 9:
                            ucCalendar.cSepEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cSepEC, eDate);
                            break;
                        case 10:
                            ucCalendar.cOctEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cOctEC, eDate);
                            break;
                        case 11:
                            ucCalendar.cNovEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cNovEC, eDate);
                            break;
                        case 12:
                            ucCalendar.cDicEC.SelectedDates.Add(eDate);
                            //setCalendarLimits(ucCalendar.cDicEC, eDate);
                            break;
                    }
                    sDate = eDate.AddDays(2);
                    switch ((int)sDate.Month - calendarFactor)
                    {
                        case 1:
                            ucCalendar.cJanSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cJanSC, sDate);
                            break;
                        case 2:
                            ucCalendar.cFebSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cFebSC, sDate);
                            break;
                        case 3:
                            ucCalendar.cMarSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cMarSC, sDate);
                            break;
                        case 4:
                            ucCalendar.cAbrSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cAbrSC, sDate);
                            break;
                        case 5:
                            ucCalendar.cMaySC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cMaySC, sDate);
                            break;
                        case 6:
                            ucCalendar.cJunSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cJunSC, sDate);
                            break;
                        case 7:
                            ucCalendar.cJulSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cJulSC, sDate);
                            break;
                        case 8:
                            ucCalendar.cAgoSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cAgoSC, sDate);
                            break;
                        case 9:
                            ucCalendar.cSepSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cSepSC, sDate);
                            break;
                        case 10:
                            ucCalendar.cOctSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cOctSC, sDate);
                            break;
                        case 11:
                            ucCalendar.cNovSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cNovSC, sDate);
                            break;
                        case 12:
                            ucCalendar.cDicSC.SelectedDates.Add(sDate);
                            setCalendarLimits(ucCalendar.cDicSC, sDate);
                            break;
                    }

                }
            }
        }

        private static void setCalendarLimits(Calendar calendar, DateTime date)
        {
            calendar.DisplayDateStart = new DateTime(date.Year, date.Month, 1);
            calendar.DisplayDateEnd = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static void CleanCalendars(LIVEX.UserControls.CalendarView ucCalendar)
        {
            ucCalendar.cJan.SelectedDates.Clear();
            ucCalendar.cFeb.SelectedDates.Clear();
            ucCalendar.cMar.SelectedDates.Clear();
            ucCalendar.cAbr.SelectedDates.Clear();
            ucCalendar.cMay.SelectedDates.Clear();
            ucCalendar.cJun.SelectedDates.Clear();
            ucCalendar.cJul.SelectedDates.Clear();
            ucCalendar.cAgo.SelectedDates.Clear();
            ucCalendar.cSep.SelectedDates.Clear();
            ucCalendar.cOct.SelectedDates.Clear();
            ucCalendar.cNov.SelectedDates.Clear();
            ucCalendar.cDic.SelectedDates.Clear();
            ucCalendar.cJanSC.SelectedDates.Clear();
            ucCalendar.cFebSC.SelectedDates.Clear();
            ucCalendar.cMarSC.SelectedDates.Clear();
            ucCalendar.cAbrSC.SelectedDates.Clear();
            ucCalendar.cMaySC.SelectedDates.Clear();
            ucCalendar.cJunSC.SelectedDates.Clear();
            ucCalendar.cJulSC.SelectedDates.Clear();
            ucCalendar.cAgoSC.SelectedDates.Clear();
            ucCalendar.cSepSC.SelectedDates.Clear();
            ucCalendar.cOctSC.SelectedDates.Clear();
            ucCalendar.cNovSC.SelectedDates.Clear();
            ucCalendar.cDicSC.SelectedDates.Clear();
            ucCalendar.cJanEC.SelectedDates.Clear();
            ucCalendar.cFebEC.SelectedDates.Clear();
            ucCalendar.cMarEC.SelectedDates.Clear();
            ucCalendar.cAbrEC.SelectedDates.Clear();
            ucCalendar.cMayEC.SelectedDates.Clear();
            ucCalendar.cJunEC.SelectedDates.Clear();
            ucCalendar.cJulEC.SelectedDates.Clear();
            ucCalendar.cAgoEC.SelectedDates.Clear();
            ucCalendar.cSepEC.SelectedDates.Clear();
            ucCalendar.cOctEC.SelectedDates.Clear();
            ucCalendar.cNovEC.SelectedDates.Clear();
            ucCalendar.cDicEC.SelectedDates.Clear();

        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static void setDatesSaved(LIVEX.UserControls.CalendarView ucCalendar)
        {
            livexEntities context = new livexEntities();
            List<ciclo> lstCycles = new List<ciclo>();

            lstCycles = context.ciclo.Where(x => x.ciclo_side == "A" || x.ciclo_side == "B").ToList();
            foreach (ciclo c in lstCycles)
            {
                int calendarFactor = 0;

                if (c.ciclo_side == "A")
                {
                    DateTime startDate = new DateTime();
                    if (c.Fecha_inicio != "")
                        startDate = Convert.ToDateTime(c.Fecha_inicio);


                    if ((int)ucCalendar.cJanSC.DisplayDate.Month != 1)
                    {
                        if (startDate.Month >= 1 && startDate.Month < 7 && startDate.Year == ucCalendar.cDicSC.DisplayDate.Year)
                            calendarFactor = -6;
                        else
                            calendarFactor = 6;
                    }
                    else
                        calendarFactor = 0;


                    switch ((int)startDate.Month - calendarFactor)
                    {

                        case 1:
                            
                            if (startDate.Year == ucCalendar.cJanSC.DisplayDate.Year )
                                ucCalendar.cJanSC.SelectedDates.Add(startDate);
                            break;
                        case 2:
                            if (startDate.Year == ucCalendar.cFebSC.DisplayDate.Year)
                                ucCalendar.cFebSC.SelectedDates.Add(startDate);
                            break;
                        case 3:
                            if (startDate.Year == ucCalendar.cMarSC.DisplayDate.Year)
                                ucCalendar.cMarSC.SelectedDates.Add(startDate);
                            break;
                        case 4:
                            if (startDate.Year == ucCalendar.cAbrSC.DisplayDate.Year)
                                ucCalendar.cAbrSC.SelectedDates.Add(startDate);
                            break;
                        case 5:
                            if (startDate.Year == ucCalendar.cMaySC.DisplayDate.Year)
                                ucCalendar.cMaySC.SelectedDates.Add(startDate);
                            break;
                        case 6:
                            if (startDate.Year == ucCalendar.cJunSC.DisplayDate.Year)
                                ucCalendar.cJunSC.SelectedDates.Add(startDate);
                            break;
                        case 7:
                            if (startDate.Year == ucCalendar.cJulSC.DisplayDate.Year)
                                ucCalendar.cJulSC.SelectedDates.Add(startDate);
                            break;
                        case 8:
                            if (startDate.Year == ucCalendar.cAgoSC.DisplayDate.Year)
                                ucCalendar.cAgoSC.SelectedDates.Add(startDate);
                            break;
                        case 9:
                            if (startDate.Year == ucCalendar.cSepSC.DisplayDate.Year)
                                ucCalendar.cSepSC.SelectedDates.Add(startDate);
                            break;
                        case 10:
                            if (startDate.Year == ucCalendar.cOctSC.DisplayDate.Year)
                                ucCalendar.cOctSC.SelectedDates.Add(startDate);
                            break;
                        case 11:
                            if (startDate.Year == ucCalendar.cNovSC.DisplayDate.Year)
                                ucCalendar.cNovSC.SelectedDates.Add(startDate);
                            break;
                        case 12:
                            if (startDate.Year == ucCalendar.cDicSC.DisplayDate.Year)
                                ucCalendar.cDicSC.SelectedDates.Add(startDate);
                            break;

                    }
                }

                if (c.ciclo_side == "B")
                {
                    DateTime endDate = new DateTime();
                    if(c.Fecha_fin != "")
                        endDate = Convert.ToDateTime(c.Fecha_fin);

                    if ((int)ucCalendar.cJanSC.DisplayDate.Month != 1)
                    {
                        if (endDate.Month >= 1 && endDate.Month < 7 && endDate.Year == ucCalendar.cDicSC.DisplayDate.Year)
                            calendarFactor = -6;
                        else
                            calendarFactor = 6;
                    }
                    else
                        calendarFactor = 0;

                    DateTime currentDate = new DateTime();
                    switch ((int)endDate.Month - calendarFactor)
                    {

                        case 1:
                             currentDate = ucCalendar.cJanEC.DisplayDate;

                            if(currentDate.Year == endDate.Year)
                                ucCalendar.cJanEC.SelectedDates.Add(endDate);
                            break;
                        case 2:
                             currentDate = ucCalendar.cFebEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cFebEC.SelectedDates.Add(endDate);
                            break;
                        case 3:
                            currentDate = ucCalendar.cMarEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cMarEC.SelectedDates.Add(endDate);
                           
                            break;
                        case 4:
                            currentDate = ucCalendar.cAbrEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cAbrEC.SelectedDates.Add(endDate);
                            break;
                        case 5:
                            currentDate = ucCalendar.cMayEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cMayEC.SelectedDates.Add(endDate);
                            break;
                        case 6:
                            currentDate = ucCalendar.cJunEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cJunEC.SelectedDates.Add(endDate);
                            break;
                        case 7:
                            currentDate = ucCalendar.cJulEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cJulEC.SelectedDates.Add(endDate);
                            break;
                        case 8:
                            currentDate = ucCalendar.cAgoEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cAgoEC.SelectedDates.Add(endDate);
                            break;
                        case 9:
                            currentDate = ucCalendar.cSepEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cSepEC.SelectedDates.Add(endDate);
                            break;
                        case 10:
                            currentDate = ucCalendar.cOctEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cOctEC.SelectedDates.Add(endDate);
                            break;
                        case 11:
                            currentDate = ucCalendar.cNovEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cNovEC.SelectedDates.Add(endDate);
                            break;
                        case 12:
                            currentDate = ucCalendar.cDicEC.DisplayDate;

                            if (currentDate.Year == endDate.Year)
                                ucCalendar.cDicEC.SelectedDates.Add(endDate);
                            break;

                    }
                }
            }
        }

        private static int getLivexWeek(DateTime date)
        {
            int wkNum = GetIso8601WeekOfYear(date);
            int week = ((wkNum + 2) % 4);
            if (week == 0)
                week = 4;
            return week;
        }

        private static int getCycleNum(DateTime date) {

            Decimal cycle = 0;
            int wkNum = GetIso8601WeekOfYear(date);
            int livexwk = ((wkNum + 2) % 4);

            cycle = Decimal.Divide((wkNum + 2 + livexwk), 4M);

            cycle = Math.Ceiling(cycle);

            if (livexwk == 1 || livexwk == 2)
            {
                //cycleSide = "A";
                cycle = cycle - 1;
            }
            else
            {
                //cycleSide = "B";
                cycle = cycle - 2;
            }

            if (cycle == 0)
                cycle = 13;

            return (int)cycle;
        }

        public static void CleanCycleCalendars(LIVEX.UserControls.CalendarView ucCalendar)
        {
            
            ucCalendar.cFebSC.SelectedDates.Clear();
            ucCalendar.cMarSC.SelectedDates.Clear();
            ucCalendar.cAbrSC.SelectedDates.Clear();
            ucCalendar.cMaySC.SelectedDates.Clear();
            ucCalendar.cJunSC.SelectedDates.Clear();
            ucCalendar.cJulSC.SelectedDates.Clear();
            ucCalendar.cAgoSC.SelectedDates.Clear();
            ucCalendar.cSepSC.SelectedDates.Clear();
            ucCalendar.cOctSC.SelectedDates.Clear();
            ucCalendar.cNovSC.SelectedDates.Clear();
            ucCalendar.cDicSC.SelectedDates.Clear();
            ucCalendar.cJanEC.SelectedDates.Clear();
            ucCalendar.cFebEC.SelectedDates.Clear();
            ucCalendar.cMarEC.SelectedDates.Clear();
            ucCalendar.cAbrEC.SelectedDates.Clear();
            ucCalendar.cMayEC.SelectedDates.Clear();
            ucCalendar.cJunEC.SelectedDates.Clear();
            ucCalendar.cJulEC.SelectedDates.Clear();
            ucCalendar.cAgoEC.SelectedDates.Clear();
            ucCalendar.cSepEC.SelectedDates.Clear();
            ucCalendar.cOctEC.SelectedDates.Clear();
            ucCalendar.cNovEC.SelectedDates.Clear();
            ucCalendar.cDicEC.SelectedDates.Clear();
        }

    
    }
}
