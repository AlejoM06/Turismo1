using Turismos.Shared.Entities;

namespace Turismos.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckClientesAsync();
        }

        private async Task CheckClientesAsync()
        {
            if (!_context.Clientes.Any())
            {
                _context.Clientes.Add(new Cliente
                {
                    NomUsuario = "Administrador",
                    Cedula = "123456789",
                    Telefono = "555-1234",
                    Correo = "admin@admin.com",
                    Direccion = "Dirección1"
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
