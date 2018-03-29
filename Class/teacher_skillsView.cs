using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIVEX.Class
{
    class teacher_skillsView
    {
        //public  teacher listTeacher;
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int salario_base { get; set; }
        public string idioma { get; set; }
        public bool TOEFL { get; set; }
        public bool Exp { get; set; }
        public bool training { get; set; }
        public bool similar { get; set; }
        public string sexo { get; set; }
        public int ID { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string AddressPhone { get; set; }
        public string CelPhone { get; set; }
        public string Email { get; set; }
        public string Birdthday { get; set; }
        public string Address { get; set; }
        public string Neighbordhood { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Substate { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyPhone { get; set; }
        public string StartDate { get; set; }
        public string Picture { get; set; }
        public string UID { get; set; }

        public teacher_skillsView()
        {
           // this.listTeacher = new teacher();
            this.TOEFL = false;
            this.Exp = false;
            this.training = false;
            this.similar = false;
            this.nombre = "";
            this.apellido = "";
            this.salario_base = 0;
            this.idioma = "";
            this.sexo = "";
            this.ID = 0;
            this.RFC = "";
            this.CURP = "";
            this.AddressPhone = "";
            this.CelPhone = "";
            this.Email = "";
            this.Birdthday = "";
            this.Address = "";
            this.Neighbordhood = "";
            this.ZipCode = "";
            this.State = "";
            this.Substate = "";
            this.EmergencyName = "";
            this.EmergencyPhone = "";
            this.StartDate = "";
            this.Picture = "";
            this.UID = "";
        }

    }
}
