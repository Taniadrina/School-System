using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LIVEX.Class
{
    public class WeekNumber : TextBlock
    {
       static int weekNum;
        static System.Globalization.Calendar cal = new System.Globalization.GregorianCalendar();


        public static readonly DependencyProperty CalendarProperty =
            DependencyProperty.Register("Calendar",
                typeof(Calendar),
                typeof(WeekNumber),
                new FrameworkPropertyMetadata(OnCalendarChanged));

        public Calendar Calendar
        {
            set { SetValue(CalendarProperty, value); }
            get { return (Calendar)GetValue(CalendarProperty); }
        }

        static void OnCalendarChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            (obj as WeekNumber).OnCalendarChanged(args);
        }

        void OnCalendarChanged(DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != null)
            {
                (args.OldValue as Calendar).DisplayModeChanged -= OnCalendarDisplayModeChanged;
                (args.OldValue as Calendar).DisplayDateChanged -= OnCalendarDisplayDateChanged;
                Text = "";
            }
            if (args.NewValue != null)
            {
                (args.NewValue as Calendar).DisplayModeChanged += OnCalendarDisplayModeChanged;
                (args.NewValue as Calendar).DisplayDateChanged += OnCalendarDisplayDateChanged;
                SetText();
            }
        }

        void OnCalendarDisplayModeChanged(object sender, CalendarModeChangedEventArgs args)
        {
            SetText();
        }

        void OnCalendarDisplayDateChanged(object sender, CalendarDateChangedEventArgs args)
        {
            SetText();
        }

        void SetText()
        {

            //if (Calendar.DisplayMode != CalendarMode.Month)
            //{
            //    Text = "";
            //    return;
            //}
            //DateTime dtCalendar = Calendar.DisplayDate;
            //DateTime dtYearBegin = new DateTime(dtCalendar.Year, 1, 1);
            //DateTime dtMonthBegin = new DateTime(dtCalendar.Year, dtCalendar.Month, 1);
            //DateTime dtMonthEnd = new DateTime(dtCalendar.Year, dtCalendar.Month, DateTime.DaysInMonth(dtCalendar.Year,dtCalendar.Month));

            //// Basic calculation
            //int firstWeekNumber = (dtMonthBegin.DayOfYear + (int)dtYearBegin.DayOfWeek - 1) / 7;
            //int lastWeekNumber = (dtMonthEnd.DayOfYear + (int)dtYearBegin.DayOfWeek - 1) / 7;

            //// Fix for month beginning on Sunday
            //if (dtMonthBegin.DayOfWeek == DayOfWeek.Sunday)
            //    firstWeekNumber--;

            //int gridRow = (int)GetValue(Grid.RowProperty);
            //if(dtCalendar.Month == 12)
            //{
            //    int x = 0;
            //}

            //// fix for first week of the year
            //if (dtCalendar.Month == 1 && dtMonthBegin.DayOfWeek == DayOfWeek.Monday && gridRow == 1)
            //{
            //    Text = "52";
            //}

            //// Fix for first week of next year
            //else if (dtCalendar.Month == 12 && (int)dtMonthBegin.DayOfWeek <= 6 && gridRow == 6)
            //{
            //    Text = "1";
            //}
            //else
            //{
            //    if(dtCalendar.DayOfWeek==DayOfWeek.Monday)
            //    {
            //        if(gridRow==1)
            //            Text = (firstWeekNumber).ToString();
            //        if (gridRow > 1)
            //        {
            //            firstWeekNumber--;
            //            Text = (firstWeekNumber+gridRow).ToString();
            //        }
            //    }
            //    else
            //        Text = (firstWeekNumber + gridRow).ToString();
            //}

            if (Calendar.DisplayMode != CalendarMode.Month)
            {
                Text = "";
                return;
            }
            DateTime dtCalendar = Calendar.DisplayDate;
            DateTime dtYearBegin = new DateTime(dtCalendar.Year, 1, 1);
            DateTime dtMonthBegin = new DateTime(dtCalendar.Year, dtCalendar.Month, 1);
            int livexFactor = 2;
            int livexWk = 0;
            
            // Basic calculation
            int firstWeekNumber = (dtMonthBegin.DayOfYear + (int)dtYearBegin.DayOfWeek - 1) / 7;
           

            // Fix for month beginning on Sunday
            if (dtMonthBegin.DayOfWeek == DayOfWeek.Sunday)
                firstWeekNumber--;

            int gridRow = (int)GetValue(Grid.RowProperty);
            

            // fix for first week of the year
            if (dtCalendar.Month == 1 && dtMonthBegin.DayOfWeek == DayOfWeek.Monday && gridRow == 1)
            {
                Text = "2";
            }

            // Fix for first week of next year
            else if (dtCalendar.Month == 12 && (int)dtMonthBegin.DayOfWeek <= 6 && gridRow == 6)
            {
                Text = "3";
            }
            else
            {
                if (dtCalendar.DayOfWeek == DayOfWeek.Monday)
                {
                    if (gridRow == 1)
                    {
                        livexWk = ((firstWeekNumber + livexFactor) % 4);
                        if (livexWk == 0)
                            livexWk = 4;

                        Text = (livexWk).ToString();
                    }
                    if (gridRow > 1)
                    {
                        firstWeekNumber--;
                        int wkNumber = firstWeekNumber + gridRow;

                        livexWk = ((wkNumber + livexFactor) % 4);
                        if (livexWk == 0)
                            livexWk = 4;

                        Text = (livexWk).ToString();
                    }
                }
                else
                {
                    int wkNumber = firstWeekNumber + gridRow;

                    livexWk = ((wkNumber + livexFactor) % 4);
                    if (livexWk == 0)
                        livexWk = 4;

                    Text = (livexWk).ToString();
                }
            }

        }
        //private static void ShowWeekNumber(DateTime dat, System.Globalization.CalendarWeekRule rule, DayOfWeek firstDay)
        //{
        //    Console.WriteLine("{0:d} with {1:F} rule and {2:F} as first day of week: week {3}",
        //                      dat, rule, firstDay, cal.GetWeekOfYear(dat, rule, firstDay));
        //}
    }
}
