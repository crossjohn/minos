﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HpAerDbEntities : DbContext
    {
        public HpAerDbEntities()
            : base("name=HpAerDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Accione> Acciones { get; set; }
        public virtual DbSet<Adopcion> Adopcions { get; set; }
        public virtual DbSet<Apadrinamiento> Apadrinamientoes { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AtencionMedica> AtencionMedicas { get; set; }
        public virtual DbSet<Barrio> Barrios { get; set; }
        public virtual DbSet<Especy> Especies { get; set; }
        public virtual DbSet<EstadoAdopcion> EstadoAdopcions { get; set; }
        public virtual DbSet<EstadoApadrinamiento> EstadoApadrinamientoes { get; set; }
        public virtual DbSet<EstadoIncidente> EstadoIncidentes { get; set; }
        public virtual DbSet<FecParam> FecParams { get; set; }
        public virtual DbSet<FileIncidente> FileIncidentes { get; set; }
        public virtual DbSet<FilePath> FilePaths { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Incidente> Incidentes { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<ProductoVeterinaria> ProductoVeterinarias { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<RegistroAccione> RegistroAcciones { get; set; }
        public virtual DbSet<Tamanio> Tamanios { get; set; }
        public virtual DbSet<TipoAdopcion> TipoAdopcions { get; set; }
        public virtual DbSet<TipoIncidente> TipoIncidentes { get; set; }
        public virtual DbSet<Veterinaria> Veterinarias { get; set; }
        public virtual DbSet<Calle> Calles { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Localidad> Localidads { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
    }
}
