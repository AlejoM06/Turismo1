using Turismo.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Controllers;
using Turismo.SHARED.Entities;

namespace  Turismo.API.Data
{
    public class DataContext : DbContext

    {
        //Utilizar las propiedades y opciones de DBContext
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<People> Peoples { get; set; }
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