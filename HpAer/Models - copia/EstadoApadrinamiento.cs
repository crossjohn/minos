//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HpAer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EstadoApadrinamiento
    {
        public EstadoApadrinamiento()
        {
            this.Apadrinamientoes = new HashSet<Apadrinamiento>();
        }
    
        public int Id { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<Apadrinamiento> Apadrinamientoes { get; set; }
    }
}
