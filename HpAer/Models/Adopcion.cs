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
    
    public partial class Adopcion
    {
        public int Id { get; set; }
        public Nullable<int> empleadoId { get; set; }
        public Nullable<int> voluntarioId { get; set; }
        public Nullable<int> animalId { get; set; }
        public Nullable<System.DateTime> fechaAlta { get; set; }
        public Nullable<System.DateTime> fechaCancelacion { get; set; }
        public Nullable<System.DateTime> fechaConfirmacion { get; set; }
        public Nullable<int> dias { get; set; }
        public Nullable<System.DateTime> fechaFin { get; set; }
        public Nullable<System.DateTime> fechaEntrega { get; set; }
        public bool esTemporal { get; set; }
        public Nullable<int> estadoAdopcionId { get; set; }
        public Nullable<int> tipoAdopcionId { get; set; }
        public Nullable<int> direccionId { get; set; }
        public string VoluntarioUsrId { get; set; }
        public string EmpleadoUsrId { get; set; }
        public string empleadoName { get; set; }
        public string voluntarioName { get; set; }
    
        public virtual EstadoAdopcion EstadoAdopcion { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Persona Persona1 { get; set; }
        public virtual TipoAdopcion TipoAdopcion { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
