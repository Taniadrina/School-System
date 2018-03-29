using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIVEX.Class
{
    class Teacher
    {
       

        /// <summary>
        /// this function creates a new teacher in teachers's table and also adds the list of skills into skill's table
        /// </summary>
        /// <param name="teacher_form_values"></param>
        /// <param name="skills_Values"></param>
        /// <returns>0-if the DB was updated successfully 1-if there was an exception</returns>
        public static int SaveTeacher(LIVEX.UserControls.AddTeacher teacher_form_values, int[] skills_Values) {
            livexEntities context = new livexEntities();
            
            teacher teacher_= new teacher();
            int t_sSaved = 0;
            int result = 0;

            //int maxTeacherID = context.teacher.Count();
            //int maxTeacher_skillID = context.teacher_skills.Count();

            //teacher_.idteacher = maxTeacherID + 1;
            
            teacher_.teacher_names = teacher_form_values.txtNewTeacherName.Text;
            teacher_.teacher_lastname = teacher_form_values.txtNewTeacherApellidos.Text;
            teacher_.RFC = teacher_form_values.txtTeacherRFC.Text;
            teacher_.CURP = teacher_form_values.txtTeacherCURP.Text;
            teacher_.phone = teacher_form_values.txtAddressPhone.Text;
            teacher_.celphone = teacher_form_values.txtCelPhone.Text;
            teacher_.email = teacher_form_values.txtEmail.Text;
            teacher_.birthday = teacher_form_values.dpBirthday.Text;
            teacher_.street_address = teacher_form_values.txtAddress.Text;
            teacher_.neighborhood = teacher_form_values.txtNeighbordhood.Text;
            teacher_.zip_code = teacher_form_values.txtZipCode.Text;
            teacher_.state = teacher_form_values.txtState.Text;
            teacher_.sub_state = teacher_form_values.txtSubState.Text;
            teacher_.emergency_contact_name = teacher_form_values.txtEmergencyName.Text;
            teacher_.emergency_contact_number = teacher_form_values.txtEmergencyPhone.Text;
            teacher_.start_date = teacher_form_values.dpStartDate.Text;
            teacher_.uid = teacher_form_values.txtUID.Text;
            if (teacher_form_values.imgTeacher.ImageSource != null)
                teacher_.picture = teacher_form_values.imgTeacher.ImageSource.ToString();
            else
                teacher_.picture = "";

            if (teacher_form_values.rbtnTeacherFemenio.IsChecked == true)//Femenino
                teacher_.teacher_gender = "F";
            else if(teacher_form_values.rbtnTeacherMasculino.IsChecked == true)//Masculino
                teacher_.teacher_gender = "M";

            teacher_.salary_base = Int32.Parse(teacher_form_values.txtSalarioBase.Text);

            if (teacher_form_values.rbtnIngles.IsChecked == true)//Ingles
                teacher_.language = "Ingles";
            else if (teacher_form_values.rbtnFrances.IsChecked == true)//Frances
                teacher_.language = "Frances";

          

            for (int i = 0; i < skills_Values.Count(); i++)
            {
                if (skills_Values[i] == 1)
                {
                    teacher_skills teacher_Skill = new teacher_skills();
                    teacher_Skill.skillID = i + 1;
                    teacher_Skill.teacherID = teacher_.idteacher;
                    teacher_Skill.teacher = teacher_;
                    teacher_.teacher_skills.Add(teacher_Skill);

                    //context.teacher_skills.Add(teacher_Skill);
                    //t_sSaved = context.SaveChanges();
                }
            }

            context.teacher.Add(teacher_);
            int teachersaved = context.SaveChanges();





            //if (teachersaved > 0)
            //{
            //    //teacher_Skill.idteacher_skills = maxTeacher_skillID + 1;
            //    teacher_Skill.teacherID = teacher_.idteacher;
            //    for(int i=0; i<skills_Values.Count();i++)
            //    {
            //        if (skills_Values[i] == 1)
            //        {
            //            teacher_Skill.skillID = i+1;
            //            context.teacher_skills.Add(teacher_Skill);
            //            t_sSaved = context.SaveChanges();
            //        }
            //    }
            //}



            //if (t_sSaved > 0 && teachersaved > 0)
            //    result = 0;
            //else
            //    result = -1;
            return result;
        }

        public static int SaveEditTeacher(LIVEX.UserControls.AddTeacher teacher_form_values, int teacherID) {
            livexEntities context = new livexEntities();
            teacher t = new teacher();
            bool[] skills = new bool[4];
            List<teacher_skills> sl = new List<teacher_skills>();
            int result = 0;
            int resultS = 0;

            t = context.teacher.FirstOrDefault(x => x.idteacher == teacherID);
            //sl = context.teacher_skills.Where(x => x.teacherID == teacherID).ToList();

            //foreach (teacher_skills s in sl)
            foreach(teacher_skills s in t.teacher_skills)
            {
                switch (s.skillID)
                {
                    case 1:
                        skills[0] =true;
                        break;
                    case 2:
                        skills[1] = true;
                        break;
                    case 3:
                        skills[2] = true;
                        break;
                    case 4:
                        skills[3] = true;
                        break;
                }
            }
               
                if (teacher_form_values.chkTOEFL.IsChecked == true )
                {
                    if (!skills[0])
                    {
                        teacher_skills ts = new teacher_skills();
                        ts.skillID = 1;
                        ts.teacher = t;
                        t.teacher_skills.Add(ts);
                    }

                }
                if (teacher_form_values.chkExp.IsChecked == true)
                {
                    if (!skills[1])
                    {
                        teacher_skills ts = new teacher_skills();
                        ts.skillID = 2;
                        ts.teacher = t;
                        t.teacher_skills.Add(ts);
                    }
                }
                if (teacher_form_values.chkTraining.IsChecked == true)
                {
                    if (!skills[2])
                    {
                        teacher_skills ts = new teacher_skills();
                        ts.skillID = 3;
                        ts.teacher = t;
                        t.teacher_skills.Add(ts);
                    }
                }
                if (teacher_form_values.chkSimilar.IsChecked == true)
                {
                    if (!skills[3])
                    {
                        teacher_skills ts = new teacher_skills();
                        ts.skillID = 4;
                        ts.teacher = t;
                        t.teacher_skills.Add(ts);
                    }
                }
            

            t.teacher_names = teacher_form_values.txtNewTeacherName.Text;
            t.teacher_lastname = teacher_form_values.txtNewTeacherApellidos.Text;
            t.RFC = teacher_form_values.txtTeacherRFC.Text;
            t.CURP = teacher_form_values.txtTeacherCURP.Text;
            t.phone = teacher_form_values.txtAddressPhone.Text;
            t.celphone = teacher_form_values.txtCelPhone.Text;
            t.email = teacher_form_values.txtEmail.Text;
            t.birthday = teacher_form_values.dpBirthday.Text;
            t.street_address = teacher_form_values.txtAddress.Text;
            t.neighborhood = teacher_form_values.txtNeighbordhood.Text;
            t.zip_code = teacher_form_values.txtZipCode.Text;
            t.state = teacher_form_values.txtState.Text;
            t.sub_state = teacher_form_values.txtSubState.Text;
            t.emergency_contact_name = teacher_form_values.txtEmergencyName.Text;
            t.emergency_contact_number = teacher_form_values.txtEmergencyPhone.Text;
            t.start_date = teacher_form_values.dpStartDate.Text;
            t.uid = teacher_form_values.txtUID.Text;
            if (teacher_form_values.imgTeacher.ImageSource != null)
                t.picture = teacher_form_values.imgTeacher.ImageSource.ToString();
            else
                t.picture = "";


            if (teacher_form_values.rbtnTeacherFemenio.IsChecked == true)
                t.teacher_gender = "F";
            else
                t.teacher_gender = "M";

            if (teacher_form_values.rbtnIngles.IsChecked == true)
                t.language = "Ingles";
            else
                t.language = "Frances";
            t.salary_base = Int32.Parse(teacher_form_values.txtSalarioBase.Text);


            int resultT=context.SaveChanges();

            //if(resultT>=0)
            //{
            //    resultS = SaveSkills(teacher_form_values,teacherID);
            //}


            

            if (resultS >= 0 && resultT >= 0)
                result = 0;
            else result = -1;

            return result;
        }

        public static int SaveSkills(LIVEX.UserControls.AddTeacher teacher_form_values,int teacherID) {

            livexEntities context = new livexEntities();
            
            //List<teacher_skills> lts = new List<teacher_skills>();
            List<int> skID = new List<int>();
            if (teacher_form_values.chkTOEFL.IsChecked == true)
                skID.Add(1);
            if (teacher_form_values.chkExp.IsChecked == true)
                skID.Add(2);
            if (teacher_form_values.chkTraining.IsChecked == true)
                skID.Add(3);
            if (teacher_form_values.chkSimilar.IsChecked == true)
                skID.Add(4);

            foreach (int s in skID)
            {
                teacher_skills ts = new teacher_skills();
                ts.teacherID = teacherID;
                ts.skillID = s;
                context.teacher_skills.Add(ts);

            }
            
            int result = context.SaveChanges();
            return result;
        }

        public static void DeleteTeacher(object dataRow)
        {
            teacher_skillsView ts = (teacher_skillsView)dataRow;
            livexEntities context = new livexEntities();
            List<teacher_skills> ls = new List<teacher_skills>();

            teacher t =context.teacher.First(x => x.idteacher == ts.ID);
            ls = context.teacher_skills.Where(x => x.teacherID == ts.ID).ToList();

            foreach(teacher_skills s in ls)
            {
                context.teacher_skills.Remove(s);
            }

            context.teacher.Remove(t);
            context.SaveChanges();
        }

        
    }
}
