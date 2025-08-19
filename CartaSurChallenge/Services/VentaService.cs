
using CartaSurChallenge.Entities;
using CartaSurChallenge.Repository;
using Microsoft.EntityFrameworkCore;

namespace CartaSurChallenge.Services
{
    public interface IVentaService
    {
        Task<DateTime> GetDiaConMasVentas();
    }
    public class VentaService : IVentaService
    {
        private readonly IAsyncRepository<Venta> _ventaRepository;
        public VentaService(IAsyncRepository<Venta> ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task<DateTime> GetDiaConMasVentas()
        {
            return await _ventaRepository.GetSet().GroupBy(v => v.FechaVenta).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefaultAsync();
        }
    }
}
