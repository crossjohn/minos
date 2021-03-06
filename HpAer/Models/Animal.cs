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
    
    public partial class Animal
    {
        public Animal()
        {
            this.Adopcions = new HashSet<Adopcion>();
            this.Apadrinamientoes = new HashSet<Apadrinamiento>();
            this.AtencionMedicas = new HashSet<AtencionMedica>();
            this.FilePaths = new HashSet<FilePath>();
            this.Files = new HashSet<File>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del Animal")]
        [StringLength(20, ErrorMessage = "Ingrese hasta 20 caracteres")]

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la Fecha aproximada de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        [Display(Name = "Nac.Aprox.")]

        public Nullable<System.DateTime> fechaNac { get; set; }


        [Display(Name = "Fec.Alta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> fechaAlta { get; set; }

        [Display(Name = "Edad")]
        public int edad { get; set; }

        [Display(Name = "Fec.Baja")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> fechaBaja { get; set; }

        [Display(Name = "Descripcion")]
        public string caracteristicas { get; set; }

        [Display(Name = "Tamaño id")]
        public Nullable<int> tamanioId { get; set; }

        [Display(Name = "Raza id")]
        public Nullable<int> razaId { get; set; }

        [Display(Name = "En Adopcion")]
        public bool enAdopcion { get; set; }
        
    
        public virtual ICollection<Adopcion> Adopcions { get; set; }

        [Display(Name = "Raza")]
        public virtual Raza Raza { get; set; }

        [Display(Name = "Tamaño")]
        public virtual Tamanio Tamanio { get; set; }

        [Display(Name = "Tratamiento")]
        public bool enTratamiento { get; set; }

        [Display(Name = "Habilitado")]
        public bool estadoHab { get; set; }

        [Display(Name = "Fec.Adopcion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> fechaAdop { get; set; }
                
        [Display(Name = "Fec.Tratamiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> fechaTratamiento { get; set; }
        public virtual ICollection<Apadrinamiento> Apadrinamientoes { get; set; }
        
        public virtual ICollection<AtencionMedica> AtencionMedicas { get; set; }
        
        public virtual ICollection<FilePath> FilePaths { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
    }
}















