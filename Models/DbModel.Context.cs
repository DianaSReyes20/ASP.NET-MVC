﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbModels : DbContext
    {
        public DbModels()
            : base("name=DbModels")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comidas> Comidas { get; set; }
        public virtual DbSet<Convenio> Convenio { get; set; }
        public virtual DbSet<Heroe> Heroe { get; set; }
        public virtual DbSet<Juego_Favorito> Juego_Favorito { get; set; }
        public virtual DbSet<Lucha> Lucha { get; set; }
        public virtual DbSet<Monstruo> Monstruo { get; set; }
        public virtual DbSet<Patrocinador> Patrocinador { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
