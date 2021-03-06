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
        public string nombre { get; set; }
        public Nullable<System.DateTime> fechaNac { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public int edad { get; set; }
        public Nullable<System.DateTime> fechaBaja { get; set; }
        public string caracteristicas { get; set; }
        public Nullable<int> tamanioId { get; set; }
        public Nullable<int> razaId { get; set; }
        public Nullable<bool> enAdopcion { get; set; }
        public Nullable<bool> enTratamiento { get; set; }
        public Nullable<bool> estadoHab { get; set; }
        public Nullable<System.DateTime> fechaAdop { get; set; }
        public Nullable<System.DateTime> fechaTratamiento { get; set; }
    
        public virtual ICollection<Adopcion> Adopcions { get; set; }
        public virtual Raza Raza { get; set; }
        public virtual Tamanio Tamanio { get; set; }
        public virtual ICollection<Apadrinamiento> Apadrinamientoes { get; set; }
        public virtual ICollection<AtencionMedica> AtencionMedicas { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
