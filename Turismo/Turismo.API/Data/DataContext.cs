using Turismo.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Controllers;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Turismo.API.Data
{
    public class DataContext : DbContext

    {
        //Utilizar las propiedades y opciones de DBContext
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Celebracion> Celebraciones { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}