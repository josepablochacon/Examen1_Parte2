﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examen1_Parte2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class accessEntities2 : DbContext
    {
        public accessEntities2()
            : base("name=accessEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<consolidado_contado> consolidado_contado { get; set; }
        public virtual DbSet<consolidado_credito> consolidado_credito { get; set; }
        public virtual DbSet<facturas> facturas { get; set; }
        public virtual DbSet<facturas_contado> facturas_contado { get; set; }
        public virtual DbSet<facturas_credito> facturas_credito { get; set; }
    }
}