//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PfizerKidsLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class vacuna
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vacuna()
        {
            this.citaVacuna = new HashSet<citaVacuna>();
        }
    
        public int idVacuna { get; set; }
        public string modelo { get; set; }
        public string lote { get; set; }
        public string fechaVencimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citaVacuna> citaVacuna { get; set; }
    }
}
