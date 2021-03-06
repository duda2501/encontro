﻿using EncontroCampistas.Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class EFDbContext : DbContext
    {
        public DbSet<Campista> Campistas { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<TipoEvento> TipoEventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Campista>().ToTable("Campistas");
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            modelBuilder.Entity<TipoEvento>().ToTable("TipoEventos");
        }
    }
}
