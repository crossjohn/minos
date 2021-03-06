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
    
    public partial class Localidad
    {
        public Localidad()
        {
            this.Barrios = new HashSet<Barrio>();
            this.Direcciones = new HashSet<Direccion>();
            this.Calles = new HashSet<Calle>();
        }
    
        public int Id { get; set; }


        [Required(ErrorMessage = "Debe Ingresar un nombre de Localidad")]
        [StringLength(50, ErrorMessage = "Ingrese hasta 50 caracteres")]

        public string nombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Provincia")]
        [Display(Name = "Provincia")]
        public int provinciaId { get; set; }
    
        public virtual ICollection<Barrio> Barrios { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Direccion> Direcciones { get; set; }
        public virtual ICollection<Calle> Calles { get; set; }
    }
}
