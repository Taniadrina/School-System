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
    
    public partial class grupo_categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public grupo_categoria()
        {
            this.grupo = new HashSet<grupo>();
        }
    
        public int idgrupo_categoria { get; set; }
        public int grupo_ID { get; set; }
        public int categoria_ID { get; set; }
        public int nivel { get; set; }
        public string tipo { get; set; }
    
        public virtual categoria categoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<grupo> grupo { get; set; }
    }
}
