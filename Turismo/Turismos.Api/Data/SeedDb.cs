using Microsoft.EntityFrameworkCore;
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
            await CheckComentariosAsync();
            await CheckFacturasAsync();
            await CheckHotelesAsync();
            await CheckTipoPagosAsync();
            await CheckTransportesAsync();
            await CheckViajesAsync();
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

        private async Task CheckComentariosAsync()
        {
            if (!_context.Comentarios.Any())
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync();

                if (cliente != null)
                {
                    _context.Comentarios.Add(new Comentario
                    {
                        Calificacion = "5",
                        Descripcion = "¡Excelente servicio!",
                        ClienteId = cliente.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckFacturasAsync()
        {
            if (!_context.Facturas.Any())
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync();
                var tipoPago = await _context.TipoPagos.FirstOrDefaultAsync();

                if (cliente != null && tipoPago != null)
                {
                    _context.Facturas.Add(new Factura
                    {
                        Fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                        Total = "100.00",
                        Detalle = "Pago por servicios",
                        ClienteId = cliente.Id,
                        TipoPagoId = tipoPago.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckHotelesAsync()
        {
            if (!_context.Hoteles.Any())
            {
                _context.Hoteles.Add(new Hotel
                {
                    NombreHotel = "Hotel Ejemplo",
                    Habitaciones = "50",
                    Telefono = "555-5678"
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckTipoPagosAsync()
        {
            if (!_context.TipoPagos.Any())
            {
                _context.TipoPagos.Add(new TipoPago
                {
                    TCredito = "**** **** **** 1234",
                    TDebito = "**** **** **** 5678",
                    Efectivo = "Sí",
                    PSE = "Sí"
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckTransportesAsync()
        {
            if (!_context.Transportes.Any())
            {
                _context.Transportes.Add(new Transporte
                {
                    Compania = "Transporte Rápido",
                    FechaRecogida = DateTime.Now.ToString("yyyy-MM-dd"),
                    FechaFinal = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd")
                });
            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckViajesAsync()
        {
            if (!_context.Viajes.Any())
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync();
                var hotel = await _context.Hoteles.FirstOrDefaultAsync();
                var transporte = await _context.Transportes.FirstOrDefaultAsync();

                if (cliente != null && hotel != null && transporte != null)
                {
                    _context.Viajes.Add(new Viaje
                    {
                        Origen = "Ciudad Origen",
                        Destino = "Ciudad Destino",
                        FechaInicio = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"),
                        FechaFin = DateTime.Now.AddDays(14).ToString("yyyy-MM-dd"),
                        Puestos = "20",
                        ClienteId = cliente.Id,
                        HotelId = hotel.Id,
                        TransporteId = transporte.Id
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
