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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Accione
    {
        public Accione()
        {
            this.RegistroAcciones = new HashSet<RegistroAccione>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la accion")]
        [StringLength(50, ErrorMessage = "Ingrese hasta 50 caracteres")]

        [Display(Name = "Accion")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una descripcion")]
        [StringLength(50, ErrorMessage = "Ingrese hasta 50 caracteres")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
        public bool isSelected { get; set; }
    
        public virtual ICollection<RegistroAccione> RegistroAcciones { get; set; }
    }
}
