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
    
    public partial class Raza
    {
        public Raza()
        {
            this.Incidentes = new HashSet<Incidente>();
            this.Animals = new HashSet<Animal>();
        }
    
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ingrese una raza")]
        [StringLength(50, ErrorMessage = "Ingrese hasta 50 caracteres")]

        [Display(Name = "Raza")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una Descripcion")]
        [StringLength(50, ErrorMessage = "Ingrese hasta 50 caracteres")]

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Seleccione una Especie")]
        
        [Display(Name = "Especie id")]
        public Nullable<int> especieID { get; set; }

        [Display(Name = "Habilitado")]
        public bool estadoHab { get; set; }

        [Display(Name = "Fecha Baja")]
        public Nullable<System.DateTime> fechaBaja { get; set; }

        [Display(Name = "Especie")]
        public virtual Especy Especy { get; set; }
        public virtual ICollection<Incidente> Incidentes { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
