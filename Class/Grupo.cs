using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LIVEX.Class
{
    class Grupo
    {
        public static int SaveGroup(LIVEX.UserControls.NewGroup newGroup) {

            livexEntities context = new livexEntities();
            grupo g = new grupo();
            //grupo_categoria gc = new grupo_categoria();
            //ciclo c = new ciclo();

            string catname = newGroup.cmbCategoria.SelectionBoxItem.ToString();
            //int maxg = context.grupo.Count();
            //int maxc = context.ciclo.Count();
            //int maxgc = 0;
            string clasificacion = "";
            string nivel,dias="", idioma="";
            ComboBox cmb = new ComboBox();

            //maxgc = context.grupo_categoria.Count();

            if (newGroup.cmbTipo.Visibility == Visibility.Visible)
                cmb = newGroup.cmbTipo;
            else
                cmb = newGroup.cmbTipo2;

            if (cmb.Text == "A" || cmb.Text == "B")
                clasificacion = "semi-Intensivo";
            else
                clasificacion = "Intensivo";

            foreach (ListBoxItem i in newGroup.lstDias.SelectedItems)
            {
                dias = dias + " " + i.Content;
            }

            if (newGroup.chkingles.IsChecked == true)
                idioma = "Inglés";
            else
                idioma = "Francés";


            if (newGroup.cmbNivel4.Visibility == Visibility.Visible)
                nivel=newGroup.cmbNivel4.SelectionBoxItem.ToString();
            else
                nivel=newGroup.cmbNivel12.SelectionBoxItem.ToString();

            //c.Fecha_inicio = newGroup.dtpFechaInicio.Text;
            //c.Fecha_fin = newGroup.dtpFechaFin.Text;
            //c.ciclo_nombre = newGroup.cmbCiclo.SelectionBoxItem.ToString();

            //context.ciclo.Add(c);
            //context.SaveChanges();

            categoria catid = context.categoria.FirstOrDefault(x => x.categoria_nombre == catname && x.clasificacion==clasificacion);


            //gc.grupo_ID = maxg + 1;
            //gc.categoria_ID = catid.idcategoria;
            //gc.nivel = Int32.Parse(nivel);
            //gc.tipo = cmb.SelectionBoxItem.ToString();

            //context.grupo_categoria.Add(gc);
            //context.SaveChanges();
            
            g.nombre_nivel = catname + " "+nivel+" "+cmb.SelectionBoxItem.ToString();
            g.Horario_inicio = newGroup.cmbHrInicio.SelectionBoxItem.ToString();
            g.Horario_fin = newGroup.cmbHrFin.SelectionBoxItem.ToString();
            g.Dias = dias;
            g.MaestroID = Int32.Parse(newGroup.cmbTeacher.SelectedValue.ToString());
            teacher t = context.teacher.FirstOrDefault(x => x.idteacher == g.MaestroID);
            g.teacher = t;
            g.Idioma = idioma;
            if (newGroup.cmbCicloEscolar.SelectedValue != null)
            {
                g.CicloID = Int32.Parse(newGroup.cmbCicloEscolar.SelectedValue.ToString());
                if(newGroup.dtpFechaInicioEscolar.Text != "")
                      g.year = Convert.ToDateTime(newGroup.dtpFechaInicioEscolar.Text).Year;
            }
            if (newGroup.cmbCiclo.SelectedValue != null)
            {
                g.CicloID = Int32.Parse(newGroup.cmbCiclo.SelectedValue.ToString());


                if (newGroup.dtpFechaInicio.Text != "" && newGroup.dtpFechaFin.Text != "")
                {
                    ciclo c = new ciclo();
                    c.ciclo_num = (int)g.CicloID;
                    c.Fecha_inicio = newGroup.dtpFechaInicio.Text;
                    c.Fecha_fin = newGroup.dtpFechaFin.Text;
                    c.ciclo_side = "C";
                    c.ciclocol = "C" + " " + g.nombre_nivel;
                    c.year = Convert.ToDateTime(newGroup.dtpFechaInicio.Text).Year;
                    //context.ciclo.Add(c);
                    g.ciclo = c;
                    g.year = Convert.ToDateTime(newGroup.dtpFechaInicio.Text).Year;
                }
            }
            //g.CategoriaID = maxgc + 1;
            //g.CicloID = maxc + 1;
            g.numero_alumnos = Int32.Parse(newGroup.txtCantAlumnos.Text);
            g.grupo_categoria = new grupo_categoria();
            g.grupo_categoria.categoria_ID= catid.idcategoria;
            g.grupo_categoria.nivel= Int32.Parse(nivel);
            g.grupo_categoria.tipo = cmb.SelectionBoxItem.ToString();
            
            context.grupo.Add(g);
            //context.SaveChanges();



            return context.SaveChanges(); 
        }

        public static int SaveEditGroup(LIVEX.UserControls.NewGroup editGroup, int idGroupCat, grupo grupo)
        {
            livexEntities context = new livexEntities();

            grupo g = context.grupo.FirstOrDefault(x => x.idgrupo == grupo.idgrupo);
            //grupo_categoria gc = context.grupo_categoria.FirstOrDefault(x => x.idgrupo_categoria == idGroupCat);
            //grupo g = context.grupo.FirstOrDefault(x =>x.idgrupo==gc.grupo_ID);
            //ciclo c = context.ciclo.FirstOrDefault(x => x.idciclo == g.CicloID);

            string catname = editGroup.cmbCategoria.SelectionBoxItem.ToString();

            string cycle = "", cycleSide ="";
            if (editGroup.cmbCicloEscolar.Visibility == Visibility.Visible)
            {
                cycle = editGroup.cmbCicloEscolar.SelectedValue.ToString();
                cycleSide = "A";
            }
            else
            {
                cycle = editGroup.cmbCiclo.SelectedValue.ToString();
                cycleSide = "C";
            }

            int cycleNum = Int32.Parse(cycle);

            ciclo idCiclo = context.ciclo.FirstOrDefault(x => x.ciclo_num == cycleNum && x.year == DateTime.Today.Year && x.ciclo_side == cycleSide);

            string nivel, dias="",idioma="";
            ComboBox cmb = new ComboBox();

            if (editGroup.chkingles.IsChecked == true)
                idioma = "Inglés";
            else
                idioma = "Francés";

            string l = "", m = "", mi = "", j = "", v = "", s = "";
            foreach (ListBoxItem i in editGroup.lstDias.SelectedItems)
            {
                
                switch(i.Content)
                {
                    case "L":
                         l = "L ";
                        break;
                    case "M":
                         m = "M ";
                        break;
                    case "Mi":
                         mi = "Mi ";
                        break;
                    case "J":
                         j = "J ";
                        break;
                    case "V":
                         v = "V ";
                        break;
                    case "S":
                         s = "S ";
                        break;
                }

                
            }
            dias = l + m + mi + j + v + s;
            if (editGroup.cmbTipo.Visibility == Visibility.Visible)
                cmb = editGroup.cmbTipo;
            else
                cmb = editGroup.cmbTipo2;

            if (editGroup.cmbNivel4.Visibility == Visibility.Visible)
                nivel = editGroup.cmbNivel4.SelectionBoxItem.ToString();
            else
                nivel = editGroup.cmbNivel12.SelectionBoxItem.ToString();

            //c.Fecha_inicio = editGroup.dtpFechaInicio.Text;
            //c.Fecha_fin = editGroup.dtpFechaFin.Text;
            //c.ciclocol = editGroup.cmbCiclo.Text; 
            if (g != null)
            {
                //g.ciclo.Fecha_inicio = editGroup.dtpFechaInicio.Text;
                //g.ciclo.Fecha_fin = editGroup.dtpFechaFin.Text;
                //g.ciclo.ciclocol = editGroup.cmbCiclo.Text;
                g.CicloID = idCiclo.idciclo;
                if(editGroup.dtpFechaFinEscolar.Visibility == Visibility.Visible)
                {
                    //g.ciclo.Fecha_inicio = editGroup.dtpFechaInicioEscolar.Text;
                    //g.ciclo.Fecha_fin = editGroup.dtpFechaFinEscolar.Text;
                }
                else
                {
                    g.ciclo.Fecha_inicio = editGroup.dtpFechaInicio.Text;
                    g.ciclo.Fecha_fin = editGroup.dtpFechaFin.Text;
                }

                g.nombre_nivel = catname + " " + nivel + " " + cmb.SelectionBoxItem.ToString();
                g.Horario_inicio = editGroup.cmbHrInicio.SelectionBoxItem.ToString();
                g.Horario_fin = editGroup.cmbHrFin.SelectionBoxItem.ToString();
                g.Dias = dias;
                g.MaestroID = Int32.Parse(editGroup.cmbTeacher.SelectedValue.ToString());
                g.Idioma = idioma;
                g.numero_alumnos = Int32.Parse(editGroup.txtCantAlumnos.Text);

                g.grupo_categoria.nivel = Int32.Parse(nivel);
                g.grupo_categoria.tipo = cmb.SelectionBoxItem.ToString();

                g.grupo_categoria.nivel = Int32.Parse(nivel);
                g.grupo_categoria.tipo = cmb.SelectionBoxItem.ToString();
                g.grupo_categoria.grupo_ID = g.idgrupo;
                //gc.nivel = Int32.Parse(nivel);
                //gc.tipo = cmb.SelectionBoxItem.ToString();

                context.SaveChanges();
            }
            return 0;
        }

        public static void DeleteGroup(object datarow)
        {
            livexEntities context = new livexEntities();
            grupo g = (grupo)datarow;
            ciclo c = context.ciclo.FirstOrDefault(x =>x.idciclo==g.CicloID);
            grupo_categoria gc = context.grupo_categoria.FirstOrDefault(x => x.idgrupo_categoria==g.CategoriaID);
            grupo grp = context.grupo.FirstOrDefault(x => x.idgrupo == g.idgrupo);

            if(c!=null && c.ciclo_side == "C")
                context.ciclo.Remove(c);
            if (gc != null)
                context.grupo_categoria.Remove(gc);
            if (grp != null)
                context.grupo.Remove(grp);

            context.SaveChanges();

        }

        public static void LoadCycles(int cNum, LIVEX.UserControls.NewGroup nGroup)
        {
            List<ciclo> lstCycle = new List<ciclo>();
            livexEntities context = new livexEntities();

            lstCycle = context.ciclo.Where(x => x.ciclo_num == cNum && x.year == DateTime.Today.Year).ToList();

            if (lstCycle != null)
            {
                foreach (ciclo c in lstCycle)
                {
                    if (c.ciclo_side == "A")
                    {
                        nGroup.dtpFechaInicioEscolar.Text = c.Fecha_inicio;
                    }
                    else if (c.ciclo_side == "B")
                    {
                        nGroup.dtpFechaFinEscolar.Text = c.Fecha_fin;
                    }
                }
            }

        }

        public static bool ValidateFields(LIVEX.UserControls.NewGroup nG)
        {
            bool isValid = true;
            if (nG.cmbCategoria.SelectedValue == null)
            { 
                isValid = false;
                MessageBox.Show("Por favor selecciona una opcion de Nivel");
            }
            else if (nG.cmbNivel12.SelectedValue == null && nG.cmbNivel4.SelectedValue == null)
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona una opcion de Nivel");
            }
            else if (nG.cmbTipo.SelectedValue == null && nG.cmbTipo2.SelectedValue == null)
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona una opcion de Nivel completa");
            }
            else if (nG.cmbHrInicio.SelectedValue == null && nG.cmbHrFin.SelectedValue == null)
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona un Horario");
            }
            else if (nG.lstDias.SelectedItems.Count == 0)
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona un Horario completo");
            }
            else if (nG.cmbTeacher.SelectedValue == null )
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona un maestro");
            }
            else if (nG.cmbCiclo.SelectedValue == null && nG.cmbCicloEscolar.SelectedValue == null)
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona un ciclo");
            }
            else if (nG.dtpFechaInicio.Text == "" && nG.dtpFechaInicioEscolar.Text == "" && nG.dtpFechaFin.Text == "" && nG.dtpFechaFinEscolar.Text == "")
            {
                isValid = false;
                MessageBox.Show("Por favor selecciona un Fecha de inicio y fin");
            }
            else if (nG.txtCantAlumnos.Text == "" )
            {
                isValid = false;
                MessageBox.Show("Por favor llena la cantidad de alumnos");
            }
            

                return isValid;
        }
    }
}
