//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAvanzada.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Convenio
    {
        public string codigo_c { get; set; }
        public string nombre_patr { get; set; }
        public string nombre_heroe { get; set; }
    
        public virtual Patrocinador Patrocinador { get; set; }
        public virtual Heroe Heroe { get; set; }
    }
}
