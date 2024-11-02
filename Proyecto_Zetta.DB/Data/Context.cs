using Microsoft.EntityFrameworkCore;
using Proyecto_Zetta.DB.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Zetta.DB.Data
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Instalador> Instaladores { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<ItemTipo> ItemsTipo { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<ItemTipoMaterial> ItemsTipoMateriales { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<FormadePago> FormasDePago { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                          && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configuración de clave primaria compuesta para la tabla intermedia
            modelBuilder.Entity<ItemTipoMaterial>()
                .HasKey(itm => new { itm.ItemTipoId, itm.MaterialId });

            // Configuración de las relaciones
            modelBuilder.Entity<ItemTipoMaterial>()
                .HasOne(itm => itm.ItemTipo)
                .WithMany(it => it.ItemTipoMateriales)
                .HasForeignKey(itm => itm.ItemTipoId);

            modelBuilder.Entity<ItemTipoMaterial>()
                .HasOne(itm => itm.Material)
                .WithMany(m => m.ItemTipoMateriales)
                .HasForeignKey(itm => itm.MaterialId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
