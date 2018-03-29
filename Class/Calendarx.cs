using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LIVEX.Class
{
    class Calendarx
    {
        public static void setMonth(int month, int year, Grid grid )
        {
            Border b1 = new Border();
            DateTime date = new DateTime(year, month, 1);
            int column = 1;

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    column = 1;
                    break;
                case DayOfWeek.Tuesday:
                    column = 2;
                    break;
                case DayOfWeek.Wednesday:
                    column = 3;
                    break;
                case DayOfWeek.Thursday:
                    column = 4;
                    break;
                case DayOfWeek.Friday:
                    column = 5;
                    break;
                case DayOfWeek.Saturday:
                    column = 6;
                    break;
                case DayOfWeek.Sunday:
                    column = 7;
                    break;
            }

        }
    }
}
