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
    using System.Web.Mvc; 
    
    public partial class Direccion
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Debe seleccionar un Pais")]
        public int paisId { get; set; }

        [Required (ErrorMessage = "Debe seleccionar una Provincia/Estado")]
        public int provinciaId { get; set; }

        [Required (ErrorMessage = "El valor ingresado no es Valido")]
        public int localidadId { get; set; }

        [Required (ErrorMessage = "Debe seleccionar una Localidad")]
        public int barrioId { get; set; }

        [Display(Name = "Calle")]
        [Required (ErrorMessage = "Debe seleccionar una calle")]
        public int calleId { get; set; }
        
        [Range(0, 50, ErrorMessage = "Ingrese un numero menor")]
        public string piso { get; set; }
        public string Torre { get; set; }

        [StringLength(3)]
        [RegularExpression(@"^[0-9a-zA-Z]+$", ErrorMessage = "Ingrese tres caracteres")]
        public string depto { get; set; }

        [Required]
        public Nullable<int> numero { get; set; }
        public Nullable<int> personaId { get; set; }
        public Nullable<int> veterinariaId { get; set; }
        public Nullable<int> incidenteId { get; set; }
    
        public virtual Barrio Barrio { get; set; }
        public virtual Calle Calle { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual Incidente Incidente { get; set; }
        public virtual Veterinaria Veterinaria { get; set; }
        public virtual Persona Persona { get; set; }
        public IList<SelectListItem> AvailablePaises { get; set; }
        public IList<SelectListItem> AvailableProvincias { get; set; }

        public IList<SelectListItem> AvailableLocalidades { get; set; }

        public IList<SelectListItem> AvailableBarrios { get; set; }

        public Direccion()
        {
            AvailablePaises = new List<SelectListItem>();
            AvailableProvincias = new List<SelectListItem>();
            AvailableLocalidades = new List<SelectListItem>();
            AvailableBarrios = new List<SelectListItem>();
        }
    }
}
