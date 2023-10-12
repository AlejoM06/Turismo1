using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Turismos.Shared.Entities;

namespace Turismos.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TipoPago> TipoPagos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    } 
}
