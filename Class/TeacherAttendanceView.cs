using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIVEX.Class
{
    class TeacherAttendanceView
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string TeacherName { get; set; }
        public int id { get; set; }

        public TeacherAttendanceView(){
            this.UID = "";
            this.Name = "";
            this.Date = "";
            this.Time = "";
            this.TeacherName = "";
            this.id = 0;
        }
    }
}
