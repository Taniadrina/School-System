//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LIVEX
{
    using System;
    using System.Collections.Generic;
    
    public partial class grupo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupo()
        {
            this.alumno = new HashSet<alumno>();
        }
    
        public int idgrupo { get; set; }
        public string nombre_nivel { get; set; }
        public string Horario_inicio { get; set; }
        public string Horario_fin { get; set; }
        public string Dias { get; set; }
        public int MaestroID { get; set; }
        public string Idioma { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<int> CicloID { get; set; }
        public int numero_alumnos { get; set; }
        public int year { get; set; }
    
        public virtual ciclo ciclo { get; set; }
        public virtual grupo_categoria grupo_categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alumno> alumno { get; set; }
        public virtual teacher teacher { get; set; }
    }
}