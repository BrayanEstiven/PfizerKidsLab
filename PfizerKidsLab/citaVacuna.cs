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
    
    public partial class citaVacuna
    {
        public int idCitaVacuna { get; set; }
        public string fecha { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int idInfante { get; set; }
        public int idAuxiliar { get; set; }
        public int idVacuna { get; set; }
    
        public virtual auxiliar auxiliar { get; set; }
        public virtual infante infante { get; set; }
        public virtual vacuna vacuna { get; set; }
    }
}
